using Athr.Domain.BuildingBlocks;
using Athr.Domain.Enumerations;
using Athr.Domain.Users;
using Athr.Domain.Users.Events;
namespace Athr.Domain.Common.Account;
public abstract class Account : Entity<AccountId>, IAggregateRoot, IAuditableEntity, ITrackableEntity, IRecoverable
{
    protected Account(AccountId id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        CreatedAtUtc = DateTime.UtcNow;
        IsActive = false;
    }
    protected Account()
    {
    }
    public string IdentityId { get; private set; } = null!;
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? LastModifiedAtUtc { get; set; }
    public string CreatedBy { get; set; } = null!;
    public string? LastModifiedBy { get; set; }
    public bool IsActive { get; private set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }

    public void SetIdentityId(IdentityType identityType)
    {
        if (!string.IsNullOrEmpty(IdentityId))
            return;

        var random = new Random().NextInt64(100, 999);
        IdentityId = $"{identityType!.Name}-{DateTime.Today.ToString("yyMMdd")}{random}";
    }
    public void Activate()
    {
        if (IsDeleted)
            throw new BusinessRuleException([UserErrors.CannotActivateDeletedAccount]);
        if (string.IsNullOrEmpty(IdentityId))
            throw new BusinessRuleException([UserErrors.CannotActivateWithoutIdentity]); 
        if (IsActive)
            return; // Idempotent
        //if (string.IsNullOrWhiteSpace(activatedByUserId))
        //    throw new BusinessRuleException([UserErrors.ActivatorRequired]);

        IsActive = true;
        LastModifiedAtUtc = DateTime.UtcNow;
        //LastModifiedBy = activatedByUserId;

        //RaiseDomainEvent(new AccountActivatedDomainEvent(Id,activatedByUserId));
    }
    public void Deactivate(string deactivatedByUserId)
    {
        if (!IsActive)
            return; // Idempotent

        IsActive = false;
        LastModifiedAtUtc = DateTime.UtcNow;
        LastModifiedBy = deactivatedByUserId;

        RaiseDomainEvent(new AccountDeactivatedDomainEvent(Id));
    }
    public void MarkAsDeleted(string deletedById)
    {
        if (IsDeleted)
            return; // Idempotent

        if (string.IsNullOrWhiteSpace(deletedById))
            throw new BusinessRuleException([UserErrors.DeleterRequired]);

        IsDeleted = true;
        IsActive = false;
        DeletedAt = DateTimeOffset.UtcNow;
        DeletedBy = deletedById;
        LastModifiedAtUtc = DateTime.UtcNow;
        LastModifiedBy = deletedById;

        RaiseDomainEvent(new AccountDeletedDomainEvent(Id));
    }
    public void Recover(string recoveredById)
    {
        if (!IsDeleted)
            return; // Idempotent
        if (string.IsNullOrWhiteSpace(recoveredById))
            throw new BusinessRuleException([UserErrors.RecovererRequired]);

        IsDeleted = false;
        DeletedAt = null;
        DeletedBy = null;
        LastModifiedAtUtc = DateTime.UtcNow;
        LastModifiedBy = recoveredById;

        RaiseDomainEvent(new AccountRecoveredDomainEvent(Id, recoveredById));
    }
}
