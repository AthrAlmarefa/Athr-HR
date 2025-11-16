using Athr.Domain.Listings.Rules;
using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Countries;

public sealed class Country : Entity<CountryId>
{
    private readonly List<CountryName> _names = [];

    private Country(CountryId id, CountryName defaultName, string dialCode) : base(id)
    {
        DialCode = dialCode.Trim();
        _names.Add(defaultName);
    }

    private Country()
    {
    }

    public IReadOnlyList<CountryName> Names => _names.AsReadOnly();
    public string DialCode { get; private set; }

    public static Country CreateInstance(CountryId countryId, string dialCode, CountryName defaultName)
    {
        var country = new Country(countryId, defaultName, dialCode);

        return country;
    }
    public void ChangeBasics(CountryName updatedName, string dialCode)
    {
        CountryName existingName = _names.Single(n => n.Id == updatedName.Id);

        if (updatedName.IsDefault && !existingName.IsDefault)
        {
            CheckRule(new CountryMustHaveOneDefaultNameRule(
                _names.Where(n => n.Id != updatedName.Id).Concat(new[] { updatedName })));
        }
        // Update properties directly instead of removing and re-adding
        existingName.ChangeBasics(updatedName.Value, updatedName.Culture, updatedName.IsDefault);

        DialCode = dialCode.Trim();
    }
    public void AddName(CountryName newName)
    {
        if (newName.IsDefault)
            CheckRule(new CountryMustHaveOneDefaultNameRule(
                _names.Where(n => n.Id != newName.Id).Concat(new[] { newName })));

        _names.Add(newName);
    }

}
