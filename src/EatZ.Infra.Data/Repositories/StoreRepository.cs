using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EatZ.Infra.Data.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly EatzDbContext _context;

        public StoreRepository(EatzDbContext context)
        {
            _context = context;
        }

        public void DeleteStore(Store store)
        {
            _context.Remove(store);
        }

        public async Task<Store> GetStoreByIdAsync(string id)
        {
            return await _context.Stores
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertStoreAsync(Store store)
        {
            await _context.Stores.AddAsync(store);
        }

        public async Task<IEnumerable<Store>> SearchStoresByCityAsync(long cityId)
        {
            return await _context.Stores
                           .AsNoTracking()
                           .Where(x => x.CityId == cityId)
                           .ToListAsync();
        }
    }
}
