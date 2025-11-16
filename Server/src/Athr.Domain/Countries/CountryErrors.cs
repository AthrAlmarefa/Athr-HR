using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Countries;

public static class CountryErrors
{
    public static readonly Error NotFound = new("Country.NotFound",
        "The Country with the specified identifier was not found");

    public static readonly Error InvalidCountryIsoCode = new("Student.InvalidIsoCode",
    "The Country IsoCode Con't be Empty and Must Be Unique");

    public static readonly Error NameNotUnique = new("Country.NameNotUnique", "The Country name is not unique");

    public static readonly Error NotFoundName = new(
        "Country.NotFoundName", "The Country with the specified name was not found");

    public static readonly Error NoCountryName = new(
        "Country.NoCountryName", "The Country must have at least one name");

    public static readonly Error InvalidDefaultName = new(
        "Country.InvalidDefaultName", "The Country must have exactly one default name");

}
