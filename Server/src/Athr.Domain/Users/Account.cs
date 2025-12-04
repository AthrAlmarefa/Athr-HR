
using Athr.Domain.BuildingBlocks;
using Athr.Domain.Enumerations;
using Athr.Domain.Users;

namespace Athr.Domain.Common.Account;

public abstract class Account : Entity<AccountId>, IAggregateRoot, IAuditableEntity, ITrackableEntity, IRecoverable
{

    protected Account(AccountId id)
    {
        Id = id;
    }

    protected Account()
    {
    }

    public string? IdentityId { get; private set; }
    public DateTime CreatedAtUtc { get; set; }

    public DateTime? LastModifiedAtUtc { get; set; }

    public string? CreatedBy { get; set; }

    public string? LastModifiedBy { get; set; }
    public bool IsActive { get; private set; }
    public void SetIdentityId(IdentityType identityType)
    {
        if (!string.IsNullOrEmpty(IdentityId))
            return;

        var random = new Random().NextInt64(100, 999);
        IdentityId = $"{identityType!.Name}-{DateTime.Today.ToString("yyMMdd")}{random}";
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void MarkAsDeleted()
    {

        IsDeleted = true;
    }
    public void Recover()
    {
        IsDeleted = false;
    }

    public bool IsDeleted { get; private set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
