using Athr.Domain.Users.Authorization;

namespace Athr.Infrastructure.Authorization;

internal sealed class UserRolePermissionsResponse
{
    public Guid UserId { get; init; }
    public string RoleName { get; init; }
    public List<BusinessRolesPermission> BusinessRoles { get; init; } = [];
}
