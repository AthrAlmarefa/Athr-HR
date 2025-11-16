using BCrypt.Net;
using Athr.Application.Abstractions.Authentication;
using Athr.Application.Abstractions.Messaging;
using Athr.Application.Exceptions;
using Athr.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Athr.Application.Users.LogInUser;

internal sealed class LogInUserCommandHandler : ICommandHandler<LogInUserCommand, AccessTokenResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService jwtService;

    public LogInUserCommandHandler(IJwtService jwtService, IUserRepository userRepository)
    {
        this.jwtService = jwtService;
        _userRepository = userRepository;
    }

    public async Task<AccessTokenResponse> Handle(LogInUserCommand request, CancellationToken cancellationToken)
    {
        string token;

        var user = await _userRepository.All().FirstOrDefaultAsync(u => u.Email.Equals(request.Email), cancellationToken)
                            ?? throw new ApplicationFlowException([LogInUserCommandErrors.InvalidLoginUser]);

        var checkPassword = user.Password is not null && BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

        if (!checkPassword)
                throw new ApplicationFlowException([LogInUserCommandErrors.InvalidLoginUser]);

        token = await jwtService.GetAccessTokenAsync(user, cancellationToken);

        return new AccessTokenResponse(token);
    }
}
