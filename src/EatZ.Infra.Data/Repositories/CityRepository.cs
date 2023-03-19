using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EatZ.Infra.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly EatzDbContext _context;

        public CityRepository(EatzDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> SearchCitiesByNameAsync(string name, int offset, int limit)
        {
            return await _context.Cities
                           .Include(x => x.State)
                           .ThenInclude(x => x.Country)
                           .AsNoTracking()
                           .Where(x => EF.Functions.ILike(x.Name, $"%{name}%"))
                           .OrderBy(x => x.State.CountryId)
                           .ThenBy(x => x.StateId)
                           .ThenBy(x => x.Id)
                           .Skip(offset)
                           .Take(limit)
                           .ToListAsync();
        }
    }
}
