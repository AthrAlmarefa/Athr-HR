using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.BusinessRoles.Events;

public sealed class BusinessRolesCreatedDomainEvent : IDomainEvent
{
    public BusinessRolesCreatedDomainEvent(Guid roleId, string roleName)
    {
        RoleId = roleId;
        RoleName = roleName;
    }

    public BusinessRolesCreatedDomainEvent()
    {
    }

    public Guid RoleId { get; set; }
    public string RoleName { get; set; }
}
