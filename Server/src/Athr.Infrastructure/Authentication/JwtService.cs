using Athr.Application.Abstractions.Authentication;
using Athr.Application.Exceptions;
using Athr.Domain.Users;
using Athr.Domain.Users.Authorization;
using Athr.Infrastructure.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static Athr.Domain.BuildingBlocks.Constants;

namespace Athr.Infrastructure.Authentication;

internal sealed class JwtService : IJwtService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly AuthenticationOptions _options;
    private readonly ILogger<JwtService> _logger;

    private static readonly ApplicationError AuthenticationFailed = new("JWT.AuthenticationFailed",
    "Failed to acquire access token do to authentication failure");

    public JwtService(IOptions<AuthenticationOptions> options, ILogger<JwtService> logger, IServiceProvider serviceProvider)
    {
        _options = options.Value;
        _logger = logger;
        _serviceProvider = serviceProvider;
    }
    public async Task<string> GetAccessTokenAsync(UserEntity user, CancellationToken cancellationToken = default)
    {
        try
        {
            var claims = new List<Claim>
            {

                new(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()),
                new(ClaimTypes.NameIdentifier, user.Id.Value.ToString()),
                new(nameof(user.IdentityId), user.IdentityId!),
                new(nameof(user.IdentityNumber), user.IdentityNumber),
                new(ClaimTypes.Name, user.UserFullName()),
                new(nameof(user.FirstName), user.FirstName),
                new(ClaimTypes.Email, user.Email),
                new(nameof(user.PhoneNumber), user.PhoneNumber ?? string.Empty),
                new(ClaimTypes.GivenName, user.FirstName),
            };

            using IServiceScope scope = _serviceProvider.CreateScope();

            AuthorizationService authorizationService = scope.ServiceProvider.GetRequiredService<AuthorizationService>();

            UserRolePermissionsResponse userRolePermissions = await authorizationService.GetBusinessRolesForUserAsync(user.Id.Value.ToString());

            claims.Add(new Claim(ClaimTypes.Role, userRolePermissions.RoleName));

            foreach (BusinessRolesPermission userRolePermission in userRolePermissions.BusinessRoles)
            {
                claims.Add(new Claim(UserRolePermissions, userRolePermission.Name));
            }

            var claimsIdentity = new ClaimsIdentity(claims, "jwt");

            var principal = new ClaimsPrincipal(claimsIdentity);

            principal.AddIdentity(claimsIdentity);

            var jwtToken = authorizationService.GenerateJwtToken(principal, _options);

            return await Task.FromResult(jwtToken);
        }
        catch (HttpRequestException)
        {
            throw new ApplicationFlowException([AuthenticationFailed]);
        }
    }
}
