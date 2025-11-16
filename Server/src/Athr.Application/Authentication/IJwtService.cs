using Athr.Domain.Users;

namespace Athr.Application.Abstractions.Authentication;

public interface IJwtService
{
    Task<string> GetAccessTokenAsync(UserEntity user, CancellationToken cancellationToken = default);
}
