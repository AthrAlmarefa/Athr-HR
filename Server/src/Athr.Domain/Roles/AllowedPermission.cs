using Athr.Domain.BuildingBlocks;
using Athr.Domain.Permissions;

namespace Athr.Domain.BusinessRoles;

public sealed record AllowedPermission : ValueObject
{
    private AllowedPermission(PermissionId permissionId, string name)
    {
        PermissionId = permissionId;
        Name = name;
    }

    private AllowedPermission() { }

    public PermissionId PermissionId { get; init; }
    public string Name { get; init; }
    public static AllowedPermission Create(PermissionId permissionId, string name)
    {
        return new AllowedPermission(permissionId, name);
    }
}
