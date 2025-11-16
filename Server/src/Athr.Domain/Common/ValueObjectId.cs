using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Common;

public abstract record ValueObjectId : ValueObjectId<Guid>
{
    protected ValueObjectId(Guid value) : base(value)
    {
        if (value.Equals(Guid.Empty))
            throw new BusinessRuleException([ValueObjectIdErrors.InvalidCredential]);
    }
    protected ValueObjectId()
    {
    }
}

public abstract record ValueObjectId<T> : ValueObject
{
    public T Value { get; protected set; }

    protected ValueObjectId(T value)
    {

        Value = value;
    }

    protected ValueObjectId()
    {
    }

    public static implicit operator T(ValueObjectId<T> valueObjectId) => valueObjectId.Value;
}

#region ValueObjectIdErrors
internal static class ValueObjectIdErrors
{
    public static readonly Error InvalidCredential = new("IdentifierType.InvalidCredential",
        "Invalid ID Credential Must Be in Guid Type And not empty");
}
#endregion

