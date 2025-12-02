using System.Reflection.Metadata.Ecma335;
using Asp.Versioning;
using Athr.Application.Exceptions;
using Athr.Application.User.UserRegister;
using Athr.Application.Users.LogInUser;
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

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<Guid> Register(
        [FromBody] UserRegisterRequest request,
        CancellationToken cancellationToken)
    {
        UserRegisterCommand command = request;
        var userId = await _sender.Send(command, cancellationToken);

        return userId;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(AccessTokenResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login(
        [FromBody] UserLoginRequest request,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine($"ModelState Error: {error.ErrorMessage}");
            }
            return BadRequest(ModelState);
        }
        try
        {
            var command = new UserLoginCommand(request.Email, request.Password);
            var result = await _sender.Send(command, cancellationToken);

            return Ok(result);
        }
        catch (ApplicationFlowException ex)
        {
            return Unauthorized(new
            {
                message = ex.Message,
                errors = ex.Errors
            });
        }

    }
}
