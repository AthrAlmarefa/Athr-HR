using Athr.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace Athr.Infrastructure.Authorization;

internal sealed class CustomClaimsTransformation : IClaimsTransformation
{
    private readonly IServiceProvider _serviceProvider;

    public CustomClaimsTransformation(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        bool isAuthenticated = principal.Identity?.IsAuthenticated is not true;
        bool hasRoles = principal.HasClaim(c => c.Type == ClaimTypes.Role);
        bool hasSubject = principal.HasClaim(c => c.Type == JwtRegisteredClaimNames.Sub);


        //if (!isAuthenticated || (hasRoles && hasSubject))
        //    return principal;

        using IServiceScope scope = _serviceProvider.CreateScope();

        AuthorizationService authorizationService = scope.ServiceProvider.GetRequiredService<AuthorizationService>();

        string identityId = principal.GetIdentityId();

        UserRolePermissionsResponse userRolePermissions = await authorizationService.GetBusinessRolesForUserAsync(identityId);

        var claimsIdentity = new ClaimsIdentity();

        claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, userRolePermissions.UserId.ToString()));

        claimsIdentity.AddClaims(userRolePermissions.BusinessRoles.Select(role =>
            new Claim(ClaimTypes.Role, role.Name)));

        // ✅ Attach enriched identity to the original principal
        principal.AddIdentity(claimsIdentity);

        return principal;
    }
}
