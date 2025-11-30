using Athr.Domain.Users;

namespace Athr.Application.Abstractions.Authentication;

public interface IAuthenticationService
{
    Task<string> RegisterAsync(UserEntity user, string password, CancellationToken cancellationToken = default);

    Task<bool> CheckUserExistsAsync(string userName, string? email = default,
        CancellationToken cancellationToken = default);
}
