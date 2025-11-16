using Athr.Domain.BusinessRoles;
using Athr.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Athr.Infrastructure.Repositories;

internal sealed class BusinessRoleRepository : Repository<BusinessRole, AccountId>, IBusinessRoleRepository
{
    public BusinessRoleRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public override Task AddAsync(BusinessRole entity)
    {
        return base.AddAsync(entity);
    }

    public async Task<BusinessRole?> GetByIdWithSubEntities(AccountId id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<BusinessRole>()
            .Include(x => x.AllowedPermissions)
            .FirstOrDefaultAsync(entity => entity.Id.Equals(id), cancellationToken);
    }
}
