using Athr.Domain.BusinessRoles.Events;
using Athr.Domain.Common.Account;
using Athr.Domain.Users;

namespace Athr.Domain.BusinessRoles;

public sealed class BusinessRole : Account
{
    private readonly List<AllowedPermission> _allowedPermissions = [];

    private BusinessRole(AccountId id) : base(id)
    {
        Id = id;
    }

    private BusinessRole()
    {
    }

    public string Name { get; private set; }

    public string Alias { get; private set; }
    public IReadOnlyCollection<AllowedPermission> AllowedPermissions => _allowedPermissions.ToList();
    public bool IsVerified { get; private set; }

    public static BusinessRole CreateInstance(AccountId id, string businessRoleName, string alias, bool isActive)
    {
        var business = new BusinessRole(id)
        { Name = businessRoleName, Alias = alias };
        business.Activate();

        business.RaiseDomainEvent(new BusinessRolesCreatedDomainEvent(business.Id.Value, alias));
        return business;
    }
    public void ChangeAllowedPermissions(IEnumerable<AllowedPermission> permissions)
    {
        //business rules
        _allowedPermissions.Clear();
        _allowedPermissions.AddRange(permissions);
    }
    public void ChangeBasics(string name, string alias, bool isActive)
    {
        Name = name;
        Alias = alias;
    }
}
