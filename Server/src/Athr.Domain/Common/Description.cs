using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Common;

public sealed record Description : ValueObject
{
    private Description(string value)
    {
        Value = value;
    }

    private Description()
    {
    }

    public string Value { get; private set; }

    public static Description Create(string value)
    {
        return new Description(value);
    }

    public static implicit operator string(Description description) => description.Value;

    public static implicit operator Description(string value) => Create(value);
}
