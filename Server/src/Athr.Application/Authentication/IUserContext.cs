using System.Security.Claims;

namespace Athr.Application.Abstractions.Authentication;

public interface IUserContext
{
    ClaimsPrincipal? User { get; }
    Guid UserId { get; }

    public bool IsAuthenticated { get; }

    string IdentityId { get; }
    string RoleName { get; }

    string UserIdOrDefault(string defaultValue = "system");

    bool IsInRole(string role);

    Task<bool> HasPermissionAsync(string permission);
}
