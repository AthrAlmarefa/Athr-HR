using Athr.Application.Abstractions.Authentication;
using Athr.Application.Abstractions.Clock;
using Athr.Domain.BuildingBlocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Athr.Infrastructure.Interceptors;

public sealed class AuditingInterceptor(IUserContext userContext, IDateTimeProvider dateTimeProvider)
    : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = new())
    {
        DbContext? context = eventData.Context;
        if (context is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        IEnumerable<EntityEntry<IAuditableEntity>> entries = context.ChangeTracker.Entries<IAuditableEntity>();
        foreach (EntityEntry<IAuditableEntity> entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAtUtc = dateTimeProvider.UtcNow;
                entry.Entity.CreatedBy = userContext?.IdentityId ?? userContext?.UserIdOrDefault();
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.LastModifiedAtUtc = dateTimeProvider.UtcNow;
                entry.Entity.LastModifiedBy = userContext?.IdentityId ?? userContext?.UserIdOrDefault();
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
