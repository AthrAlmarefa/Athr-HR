using Athr.Domain.BuildingBlocks;
using Athr.Domain.Users;
using Athr.Domain.Users.Events;
namespace Athr.Domain.Common.Account;
public abstract class Account : Entity<AccountId>, IAggregateRoot, IAuditableEntity, ITrackableEntity, IRecoverable
{
    protected Account(AccountId id,string createdBy)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        CreatedAtUtc = DateTimeOffset.UtcNow;
        IsActive = false;
        CreatedBy = createdBy;
    }
    protected Account()
    {
    }
    public string IdentityId { get; private set; }
    public DateTimeOffset CreatedAtUtc { get; private set; }
    public DateTimeOffset? LastModifiedAtUtc { get; private set; }
    public string? CreatedBy { get; private set; }
    public string? LastModifiedBy { get; private set; }
    public bool IsActive { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTimeOffset? DeletedAt { get; private set; }
    public string? DeletedBy { get; private set; }
   
    public void SetIdentityId(string identityId)
    {
        if (string.IsNullOrWhiteSpace(identityId))
            throw new BusinessRuleException([UserErrors.IdentityIdRequired]);

        if (!string.IsNullOrEmpty(IdentityId))
            throw new BusinessRuleException([UserErrors.IdentityIdAlreadySet]);

        IdentityId = identityId;
    }
    public void Activate(string activatedByUserId)
    {
        if (IsDeleted)
            throw new BusinessRuleException([UserErrors.CannotActivateDeletedAccount]);
        if (string.IsNullOrEmpty(IdentityId))
            throw new BusinessRuleException([UserErrors.CannotActivateWithoutIdentity]); 
        if (IsActive)
            return; // Idempotent
        if (string.IsNullOrWhiteSpace(activatedByUserId))
            throw new BusinessRuleException([UserErrors.ActivatorRequired]);

        IsActive = true;
        LastModifiedAtUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = activatedByUserId;

        RaiseDomainEvent(new AccountActivatedDomainEvent(Id,activatedByUserId));
    }
    public void Deactivate(string deactivatedByUserId)
    {
        if (!IsActive)
            return; // Idempotent

        IsActive = false;
        LastModifiedAtUtc = LastModifiedAtUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = deactivatedByUserId;

        RaiseDomainEvent(new AccountDeactivatedDomainEvent(Id, deactivatedByUserId));
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
        LastModifiedAtUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = deletedById;

        RaiseDomainEvent(new AccountDeletedDomainEvent(Id, deletedById));
    }
    public void Recover(string recoveredById)
    {
        if (!IsDeleted)
            return; // Idempotent

        IsDeleted = false;
        DeletedAt = null;
        DeletedBy = null;
        LastModifiedAtUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = recoveredById;

        RaiseDomainEvent(new AccountRecoveredDomainEvent(Id, recoveredById));
    }
}
