using Athr.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Athr.Infrastructure.Authentication;

internal sealed class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IServiceProvider _serviceProvider;
    public UserContext(IHttpContextAccessor httpContextAccessor, IServiceProvider serviceProvider)
    {
        _httpContextAccessor = httpContextAccessor;
        _serviceProvider = serviceProvider;
    }

    public ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

    public Guid UserId => User?.GetUserId() ?? throw new ApplicationException("User context is unavailable");

    public bool IsAuthenticated => User?.Identity?.IsAuthenticated ?? throw new ApplicationException("User context is unavailable");

    public string IdentityId => User.GetIdentityId() ?? throw new ApplicationException("User context is unavailable");

    public string RoleName => User.GetRoleType() ?? throw new ApplicationException("User context is unavailable");

    public bool IsInRole(string role) => User.IsInRole(role);

    public string UserIdOrDefault(string defaultValue = "system")
    {
        return User?.GetUserId()?.ToString() ?? defaultValue;
    }

    public async Task<bool> HasPermissionAsync(string permission)
    {
        return true; // For now, we assume all users have permission. This can be replaced with actual permission logic.
        //using IServiceScope scope = _serviceProvider.CreateScope();

        //AuthorizationService authorizationService = scope.ServiceProvider.GetRequiredService<AuthorizationService>();

        //HashSet<string> permissions = await authorizationService.GetPermissionsForUserAsync(IdentityId);
        //return await Task.FromResult(permissions.Contains(permission));
    }
}
