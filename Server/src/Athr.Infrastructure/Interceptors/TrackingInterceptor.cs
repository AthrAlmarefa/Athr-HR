using Athr.Application.Abstractions.Authentication;
using Athr.Application.Abstractions.Clock;
using Athr.Application.Abstractions.Tracking;
using Athr.Domain.BuildingBlocks;
using Athr.Infrastructure.Tracing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Athr.Infrastructure.Interceptors;

public class TrackingInterceptor(IUserContext userContext, IDateTimeProvider dateTimeProvider) : SaveChangesInterceptor
{
    private readonly string _uniqueId = Guid.NewGuid().ToString();

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        DbContext? context = eventData.Context;
        if (context == null)
        {
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        var traceEntries = context.ChangeTracker.Entries<ITrackableEntity>()
            .Where(entry => entry.State != EntityState.Detached && entry.State != EntityState.Unchanged)
            .Select(CreateTraceEntry).ToList();

        foreach (TraceEntry traceEntry in traceEntries)
        {
            context.Add(traceEntry.ToTraceLog());
        }

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private TraceEntry CreateTraceEntry(EntityEntry<ITrackableEntity> entry)
    {
        var traceEntry = new TraceEntry(entry, dateTimeProvider)
        {
            TableName = entry.Entity.GetType().Name,
            EntryString = entry.ToString(),
            InterceptionUniqueId = _uniqueId,
            UserId = userContext.UserIdOrDefault(),
            AuditType = GetAuditType(entry.State)
        };

        foreach (PropertyEntry property in entry.Properties)
        {
            string propertyName = property.Metadata.Name;

            if (property.Metadata.IsPrimaryKey())
            {
                traceEntry.KeyValues[propertyName] = property.CurrentValue;
                continue;
            }

            if (entry.State == EntityState.Added || entry.State == EntityState.Deleted || property.IsModified)
            {
                TrackPropertyChanges(traceEntry, entry, propertyName, property);
            }
        }


        return traceEntry;
    }

    private void TrackPropertyChanges(TraceEntry traceEntry, EntityEntry entry, string propertyName,
        PropertyEntry property)
    {
        switch (entry.State)
        {
            case EntityState.Added:
                traceEntry.NewValues[propertyName] = property.CurrentValue;
                break;
            case EntityState.Deleted:
                traceEntry.OldValues[propertyName] = property.OriginalValue;
                break;
            case EntityState.Modified when property.IsModified:
                traceEntry.ChangedColumns.Add(propertyName);
                traceEntry.OldValues[propertyName] = property.OriginalValue;
                traceEntry.NewValues[propertyName] = property.CurrentValue;
                break;
        }
    }

    private static TraceType GetAuditType(EntityState state)
    {
        return state switch
        {
            EntityState.Added => TraceType.Create,
            EntityState.Deleted => TraceType.Delete,
            EntityState.Modified => TraceType.Update,
            _ => TraceType.None
        };
    }
}
