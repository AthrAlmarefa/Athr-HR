using BCrypt.Net;
using Athr.Application.Abstractions.Authentication;
using Athr.Application.Abstractions.Messaging;
using Athr.Application.Exceptions;
using Athr.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Athr.Application.Abstractions.Behaviors;

namespace Athr.Application.Users.LogInUser;

internal sealed class UserLoginCommandHandler : ICommandHandler<UserLoginCommand, AccessTokenResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService jwtService;

    public UserLoginCommandHandler(IJwtService jwtService, IUserRepository userRepository)
    {
        this.jwtService = jwtService;
        _userRepository = userRepository;
    }

    public async Task<AccessTokenResponse> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        string token;

        var user = await _userRepository.All().FirstOrDefaultAsync(u => u.Email.Equals(request.Email), cancellationToken)
                            ?? throw new ApplicationFlowException([UserLoginCommandErrors.InvalidLoginUser]);

        var checkPassword = PasswordHasher.VerifyHashedPassword(user.Password, request.Password);

        if (!checkPassword)
                throw new ApplicationFlowException([UserLoginCommandErrors.InvalidLoginUser]);

        token = await jwtService.GetAccessTokenAsync(user, cancellationToken);

        return new AccessTokenResponse(token);
    }
}
