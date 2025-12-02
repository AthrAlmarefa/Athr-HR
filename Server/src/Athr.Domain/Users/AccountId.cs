

using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Users;

public sealed record AccountId : ValueObject
{
    private AccountId(Guid value)
    {
        Value = value;
    }

    private AccountId() { }
    public Guid Value { get; }

    public static AccountId CreateUnique()
    {
        return new AccountId(Guid.NewGuid());
    }

    public static AccountId Create(Guid value)
    {
        var accountId = new AccountId(value)
            ?? throw new ArgumentException("UserId Is not valid");
        return accountId;
    }

    public static implicit operator Guid(AccountId accountId) => accountId.Value;
    public static implicit operator AccountId(Guid value) => new AccountId(value);
}
