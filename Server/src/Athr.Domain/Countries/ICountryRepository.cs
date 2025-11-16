namespace Athr.Domain.Countries;

public interface ICountryRepository
{
    Task<Country?> GetByIdAsync(CountryId id, CancellationToken cancellationToken = default);

    IQueryable<Country> All();

    Task AddAsync(Country Country);
    void Update(Country Country);
}
