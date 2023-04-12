using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EatZ.Infra.Data.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly EatzDbContext _context;

        public StateRepository(EatzDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<State>> GetStatesByCountryIdAsync(long countryId)
        {
            return await _context.States.Where(x => x.CountryId == countryId).ToListAsync();
        }
    }
}
