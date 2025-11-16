using Athr.Domain.Countries;
using Athr.Domain.Common.Account;
using Athr.Domain.Users.Authorization;
using Athr.Domain.Users.Events;

namespace Athr.Domain.Users;

public sealed class UserEntity : Account
{
    private readonly List<BusinessRolesPermission> _businessPermissions = [];
    private readonly List<AccountId> _businessRoles = [];

    private UserEntity(AccountId id) : base(id)
    {
    }

    private UserEntity()
    {
    }

    public string FirstName { get; private set; }
    public string MidName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string? Password { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string IdentityNumber { get; private set; }
    public CountryId DialCodeId { get; private set; }
    public IReadOnlyCollection<BusinessRolesPermission> BusinessPermissions => _businessPermissions.ToList();
    public IReadOnlyCollection<AccountId> BusinessRoles => _businessRoles.ToList();

    public static UserEntity CreateInstance(string FirstName, string MidName, string LastName, string Email, string PhoneNumber, string IdentityNum, string DialCodeId = "SA")
    {
        var user = new UserEntity(AccountId.CreateUnique())
        {
            FirstName = FirstName,
            MidName = MidName,
            LastName = LastName,
            Email = Email,
            PhoneNumber = PhoneNumber,
            IdentityNumber = IdentityNum,
            DialCodeId = CountryId.Create(DialCodeId)
        };
        user.Activate();
        user.RaiseDomainEvent(new UserCreatedDomainEvent { Id = user.Id.Value });

        return user;
    }

    public void ChangePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));
        }
        Password = password;
    }
    public void AssignPermission(BusinessRolesPermission permission)
    {
        if (_businessPermissions.Contains(permission))
        {
            return;
        }

        _businessPermissions.Add(permission);
    }
    public void AssignPermissions(IEnumerable<BusinessRolesPermission> permissions)
    {
        _businessPermissions.AddRange(permissions);
    }
    public void RemovePermission(BusinessRolesPermission permission)
    {
        if (!_businessPermissions.Contains(permission))
        {
            return;
        }

        _businessPermissions.Remove(permission);
    }

    public void AddBusinessRole(AccountId businessId)
    {
        if (_businessRoles.Contains(businessId))
        {
            return;
        }

        _businessRoles.Add(businessId);
    }

    public void RemoveBusiness(AccountId businessId)
    {
        if (!_businessRoles.Contains(businessId))
        {
            return;
        }

        _businessRoles.Remove(businessId);
    }

    public string UserFullName()
    {
        return $"{FirstName} {MidName} {LastName}";
    }

    public void ChangeBasics(string firstName, string midName, string lastName, string email, string phoneNumber, string identityNumber, string dialCodeId = "SA")
    {
        FirstName = firstName;
        MidName = midName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        IdentityNumber = identityNumber;
        DialCodeId = CountryId.Create(DialCodeId);
    }
    public void ChangeAllowedPermissions(IEnumerable<BusinessRolesPermission> businessPermissions)
    {
        _businessPermissions.Clear();
        _businessPermissions.AddRange(businessPermissions);
    }
}
