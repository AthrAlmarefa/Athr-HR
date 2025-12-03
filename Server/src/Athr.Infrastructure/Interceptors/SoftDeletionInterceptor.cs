using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Athr.Domain.BuildingBlocks;
using Athr.Application.Abstractions.Authentication;

namespace Athr.Infrastructure.Interceptors;

internal sealed class SoftDeletionInterceptor (IUserContext userContext): SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
        {
            return ValueTask.FromResult(result);
        }
        
        foreach (EntityEntry<IRecoverable> entry in eventData.Context.ChangeTracker.Entries<IRecoverable>())
        {
            IRecoverable entity = entry.Entity;
            if (entity is not { IsDeleted: true })
            {
                continue;
            }
            entity.DeletedAt = DateTimeOffset.UtcNow;
            entity.DeletedBy = userContext.UserId.ToString();
        }
        return ValueTask.FromResult(result);
    }
}
