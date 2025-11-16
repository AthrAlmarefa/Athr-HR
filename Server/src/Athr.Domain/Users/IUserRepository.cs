namespace Athr.Domain.Users;

public interface IUserRepository
{
    Task<UserEntity?> GetByIdAsync(
        AccountId userId,
        CancellationToken cancellationToken = default);
    IQueryable<UserEntity> All();

    Task UniqueConflicts(AccountId accountId, string Email, string PhoneNumber, string IdentityNumber, CancellationToken cancellationToken);

    Task AddAsync(UserEntity user);

    void Update(UserEntity user);
}
