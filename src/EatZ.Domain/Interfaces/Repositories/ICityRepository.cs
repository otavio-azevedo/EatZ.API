using EatZ.Domain.Entities;

namespace EatZ.Domain.Interfaces.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> SearchCitiesByNameAsync(string name, int offset, int limit);
    }
}
