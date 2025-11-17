using Asp.Versioning;
using Athr.Application.Users.LogInUser;
using Athr.Application.Users.UserRegister;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Athr.Api.Controllers.Users;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/users")]
public class UsersController : ControllerBase
{
    private readonly ISender _sender;

    public UsersController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<Guid> Register(UserRegisterRequest request, CancellationToken cancellationToken)
    {
        UserRegisterCommand command = request;

        Guid accountId = await _sender.Send(command, cancellationToken);

        return accountId;
    }


    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<AccessTokenResponse> LogIn(LogInUserRequest request, CancellationToken cancellationToken)
    {
        var command = new LogInUserCommand(request.Email, request.Password);

        AccessTokenResponse result = await _sender.Send(command, cancellationToken);

        return result;
    }
}
