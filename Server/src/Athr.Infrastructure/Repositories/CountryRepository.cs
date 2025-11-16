using Athr.Domain.Countries;

namespace Athr.Infrastructure.Repositories;

internal sealed class CountryRepository : Repository<Country, CountryId>, ICountryRepository
{
    public CountryRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

}
