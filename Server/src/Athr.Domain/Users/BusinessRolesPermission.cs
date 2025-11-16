using Athr.Domain.BuildingBlocks;
using Athr.Domain.Permissions;

namespace Athr.Domain.Users.Authorization;

public sealed record BusinessRolesPermission : ValueObject
{
    private BusinessRolesPermission(PermissionId permissionId, AccountId businessId, string name)
    {
        PermissionId = permissionId;
        Name = name;
        BusinessRoleId = businessId;
    }

    private BusinessRolesPermission() { }

    public PermissionId PermissionId { get; init; }
    public string Name { get; init; }
    public AccountId BusinessRoleId { get; init; }

    public static BusinessRolesPermission Create(PermissionId permissionId, AccountId businessId, string name)
    {
        return new BusinessRolesPermission(permissionId, businessId, name);
    }
}
