using Athr.Application.Exceptions;
using Athr.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Athr.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<UserEntity, AccountId>, IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
    public UserRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task UniqueConflicts(AccountId accountId, string Email, string PhoneNumber, string IdentityNumber, CancellationToken cancellationToken)
    {
        var conflictExists = await _dbContext.Set<UserEntity>()
            .AsNoTracking()
            .Where(a => !a.Id.Equals(accountId))
            .Where(a =>
                (a.Email.ToLower().Equals(Email))
                || (a.PhoneNumber.Equals(PhoneNumber))
                || (a.IdentityId.Equals(IdentityNumber))
            )
            .Select(a => new
            {
                a.Email,
                a.PhoneNumber,
                a.IdentityNumber
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (conflictExists is null)
            return; // all clear

        var conflicts = new List<ApplicationError>();
        if (conflictExists.Email.Equals(Email, StringComparison.OrdinalIgnoreCase)) conflicts.Add(new ApplicationError(nameof(UserEntity.Email), "Email Is Used Before"));
        if (conflictExists.PhoneNumber!.Equals(PhoneNumber, StringComparison.OrdinalIgnoreCase)) conflicts.Add(new ApplicationError(nameof(UserEntity.PhoneNumber), "PhoneNumber Is Used Before"));
        if (conflictExists.IdentityNumber!.Equals(PhoneNumber, StringComparison.OrdinalIgnoreCase)) conflicts.Add(new ApplicationError(nameof(UserEntity.IdentityNumber), "PhoneNumber Is Used Before"));

        throw new ApplicationFlowException(conflicts);
    }
}
