using Athr.Domain.BuildingBlocks;
using Athr.Domain.Common;

namespace Athr.Domain.Countries;

public sealed record CountryId : ValueObjectId<string>
{
    private CountryId(string value) : base(value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new BusinessRuleException([CountryErrors.InvalidCountryIsoCode]);
        Value = value.Trim().ToUpperInvariant();
    }

    public CountryId() { }

    public static CountryId Create(string value) => new CountryId(value);

    public static implicit operator CountryId(string value) => Create(value);
    public static implicit operator string(CountryId id) => id.Value;
}
