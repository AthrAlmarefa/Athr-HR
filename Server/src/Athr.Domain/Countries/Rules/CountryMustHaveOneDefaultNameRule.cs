using Athr.Domain.BuildingBlocks;
using Athr.Domain.Countries;

namespace Athr.Domain.Listings.Rules;

public class CountryMustHaveOneDefaultNameRule(IEnumerable<CountryName> newNames) : IBusinessRule
{
    public bool IsBroken()
    {
        return newNames.Count(n => n.IsDefault) != 1;
    }

    public Error Error => CountryErrors.InvalidDefaultName;
}
