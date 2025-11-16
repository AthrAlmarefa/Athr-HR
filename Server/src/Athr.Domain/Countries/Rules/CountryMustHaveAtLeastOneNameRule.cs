using Athr.Domain.BuildingBlocks;
using Athr.Domain.Countries;

namespace Athr.Domain.Listings.Rules;

public class CountryMustHaveAtLeastOneNameRule(IEnumerable<CountryName> newNames) : IBusinessRule
{
    public bool IsBroken()
    {
        return !newNames.Any();
    }

    public Error Error => CountryErrors.NoCountryName;
}
