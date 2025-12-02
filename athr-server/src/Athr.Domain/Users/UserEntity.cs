//using Athr.Domain.Countries;
using Athr.Domain.Common.Account;
using Athr.Domain.Users.Authorization;
using Athr.Domain.Users.Events;
using Athr.Domain.BuildingBlocks;
using Athr.Domain.Users.Rules;
using Athr.Domain.Common;

namespace Athr.Domain.Users;

public sealed class UserEntity : Account
{
    private readonly List<BusinessRolesPermission> _businessPermissions = [];
    private readonly List<AccountId> _businessRoles = [];

    //delete createdBy or keep it?
    private UserEntity(AccountId id,
    string firstName,
    string midName,
    string lastName,
    string email,
    string password,
    string phoneNumber,
    string identityNum) : base(id)
    {
        CheckRule(new EmailFormatRule(email));
        CheckRule(new PhoneNumberFormatRule(phoneNumber));

        FirstName = firstName;
        MidName = midName;
        LastName = lastName;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        IdentityNumber = identityNum;
    }

    private UserEntity()
    {
    }

    public string FirstName { get; private set; } = null!;
    public string MidName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public string PhoneNumber { get; private set; } = null!;
    public string IdentityNumber { get; private set; } = null!;
    //public CountryId DialCodeId { get; private set; }
    public IReadOnlyCollection<BusinessRolesPermission> BusinessPermissions => _businessPermissions.ToList();
    public IReadOnlyCollection<AccountId> BusinessRoles => _businessRoles.ToList();

    public static UserEntity CreateInstance(string firstName, string midName, string lastName, string email, string password, string phoneNumber, string identityNum, string dialCodeId = "SA")
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new BusinessRuleException([UserErrors.FirstNameRequired]);
        if (string.IsNullOrWhiteSpace(midName))
            throw new BusinessRuleException([UserErrors.MidNameRequired]);
        if (string.IsNullOrWhiteSpace(lastName))
            throw new BusinessRuleException([UserErrors.LastNameRequired]);
        if (string.IsNullOrWhiteSpace(password))
            throw new BusinessRuleException([UserErrors.PasswordRequired]);

        var user = new UserEntity(AccountId.CreateUnique(), firstName, midName, lastName, email, password, phoneNumber, identityNum);
            //DialCodeId = CountryId.Create(DialCodeId)

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }

    public void ChangePassword(string newPassword) 
    {
        if (newPassword == null)
            throw new BusinessRuleException([UserErrors.PasswordRequired]);

        Password = newPassword;
        RaiseDomainEvent(new UserPasswordChangedDomainEvent(Id));
    }
    public void AssignPermission(BusinessRolesPermission permission)
    {
        if (permission == null)
            throw new ArgumentNullException(nameof(permission));

        if (_businessPermissions.Contains(permission))
            return;

        _businessPermissions.Add(permission);
        RaiseDomainEvent(new UserPermissionAssignedDomainEvent(Id, permission));
    }
    public void AssignPermissions(IEnumerable<BusinessRolesPermission> permissions)
    {
        _businessPermissions.AddRange(permissions);
        foreach(var permission in _businessPermissions)
        {
            _businessPermissions.Add(permission);
            RaiseDomainEvent(new UserPermissionAssignedDomainEvent(Id, permission));
        }  
    }
    public void RemovePermission(BusinessRolesPermission permission)
    {
        if (!_businessPermissions.Contains(permission))
        {
            return;
        }

        _businessPermissions.Remove(permission);
        RaiseDomainEvent(new UserPermissionRemovedDomainEvent(Id,permission));
    }

    public void AddBusinessRole(AccountId businessId)
    {
        if (businessId == null)
            throw new ArgumentNullException(nameof(businessId));

        if (_businessRoles.Contains(businessId))
            return;

        _businessRoles.Add(businessId);
        RaiseDomainEvent(new UserBusinessRoleAddedDomainEvent(Id, businessId));
    }

    public void RemoveBusinessRole(AccountId businessId)
    {
        if (!_businessRoles.Contains(businessId))
            return;

        _businessRoles.Remove(businessId);
        _businessPermissions.RemoveAll(p => p.BusinessRoleId == businessId);

        RaiseDomainEvent(new UserBusinessRoleRemovedDomainEvent(Id, businessId));
    }

    public string UserFullName()
    {
        return $"{FirstName} {MidName} {LastName}";
    }

    public void ChangeBasics(string firstName, string midName, string lastName,
    string email, string phoneNumber, string identityNumber)  
    {
        if (IsDeleted)
            throw new BusinessRuleException([UserErrors.CannotUpdateDeletedUser]);
        if (string.IsNullOrWhiteSpace(firstName))
            throw new BusinessRuleException([UserErrors.FirstNameRequired]);
        if (string.IsNullOrWhiteSpace(lastName))
            throw new BusinessRuleException([UserErrors.LastNameRequired]);

        CheckRule(new EmailFormatRule(email));
        CheckRule(new PhoneNumberFormatRule(phoneNumber));

        FirstName = firstName;
        MidName = midName ?? string.Empty;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        IdentityNumber = identityNumber;

        LastModifiedAtUtc = DateTime.UtcNow;
        //LastModifiedBy = modifiedByUserId;

        RaiseDomainEvent(new UserBasicsChangedDomainEvent(Id));
    }
    public void ChangeAllowedPermissions(IEnumerable<BusinessRolesPermission> businessPermissions)
    {
        _businessPermissions.Clear();
        _businessPermissions.AddRange(businessPermissions);
    }

}
