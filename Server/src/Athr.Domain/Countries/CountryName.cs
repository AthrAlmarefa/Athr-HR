using Athr.Domain.Common;

namespace Athr.Domain.Countries;

public sealed class CountryName : CultureName
{
    private CountryName(CountryId? countryId, string value, Culture culture, bool isDefault)
        : base(value, culture, isDefault)
    {
        CountryId = countryId;
        Value = value;
        Culture = culture;
        IsDefault = isDefault;
    }

    private CountryName()
    {
    }

    public CountryId? CountryId { get; internal set; }
    public string Value { get; private set; }
    public Culture Culture { get; private set; }
    public bool IsDefault { get; private set; }

    public static CountryName Create(CountryId CountryId, string name, Culture culture, bool isDefault)
    {
        return new CountryName(CountryId, name, culture, isDefault);
    }
}
