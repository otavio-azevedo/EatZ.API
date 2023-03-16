using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.CrossCutting.Extensions;
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
            return await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertStoreAsync(Store store)
        {
            await _context.Stores.AddAsync(store);
        }

        public async Task<IEnumerable<Store>> SearchStoresAsync(string country, string state, string city, string neighborhood, string street)
        {
            return await _context.Stores
                           .WhereIf(x => x.Country.Contains(country), !string.IsNullOrEmpty(country))
                           .WhereIf(x => x.Country.Contains(state), !string.IsNullOrEmpty(state))
                           .WhereIf(x => x.Country.Contains(city), !string.IsNullOrEmpty(city))
                           .WhereIf(x => x.Country.Contains(neighborhood), !string.IsNullOrEmpty(neighborhood))
                           .WhereIf(x => x.Country.Contains(street), !string.IsNullOrEmpty(street))
                           .ToListAsync();
        }
    }
}
