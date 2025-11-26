using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Users;

public sealed record Email : ValueObject
{
    public string Value { get; set; }
    private Email(string value)
    {
        Value = value;
    }
    public static Email Create(string email)
    {
        return new Email(email.Trim().ToLowerInvariant());
    }

}
