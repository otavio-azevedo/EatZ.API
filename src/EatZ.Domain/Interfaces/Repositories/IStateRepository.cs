using EatZ.Domain.Entities;

namespace EatZ.Domain.Interfaces.Repositories
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetStatesByCountryIdAsync(long countryId);
    }
}
