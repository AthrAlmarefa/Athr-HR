using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace Athr.Infrastructure.Authentication;

internal static class ClaimsPrincipalExtensions
{
    public static Guid? GetUserId(this ClaimsPrincipal? principal)
    {
        string? userId = principal?.FindFirstValue(JwtRegisteredClaimNames.Sub);

        return Guid.TryParse(userId, out Guid parsedUserId) ? parsedUserId : null;
    }

    public static string GetIdentityId(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    public static string GetRoleType(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue(ClaimTypes.Role);
    }
}
