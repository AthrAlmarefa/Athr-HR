using Athr.Domain.Users;

namespace Athr.Domain.BusinessRoles;

public interface IBusinessRoleRepository
{
    Task<BusinessRole?> GetByIdAsync(AccountId id, CancellationToken cancellationToken = default);
    //Task<BusinessRole?> GetByIdWithInstructorsAsync(AccountId id, CancellationToken cancellationToken = default);
    //Task<BusinessRole?> GetByIdWithSubEntities(AccountId id, CancellationToken cancellationToken = default);

    IQueryable<BusinessRole> All();

    Task AddAsync(BusinessRole businessRole);
    void Update(BusinessRole businessRole);
}
