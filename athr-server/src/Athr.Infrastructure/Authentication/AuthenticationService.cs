using Athr.Application.Abstractions.Authentication;
using Athr.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Athr.Infrastructure.Authentication;

internal sealed class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> RegisterAsync(
        UserEntity user,
        string password,
        CancellationToken cancellationToken = default)
    {
        // This will be called AFTER user is created in domain
        // Used to create identity in external provider (if needed)
        // For now, return the user's ID as identity
        return user.Id.Value.ToString();
    }

    public async Task<bool> CheckUserExistsAsync(
        string userName,
        string? email = default,
        CancellationToken cancellationToken = default)
    {
        return await _userRepository.All()
            .AnyAsync(u => u.Email == userName || u.Email == email, cancellationToken);
    }
}