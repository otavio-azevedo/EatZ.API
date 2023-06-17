using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EatZ.Infra.Data.Repositories
{
    public class StoreOfferRepository : IStoreOfferRepository
    {
        private readonly EatzDbContext _context;

        public StoreOfferRepository(EatzDbContext context)
        {
            _context = context;
        }

        public void DeleteOffer(StoreOffers offer)
        {
            _context.Remove(offer);
        }

        public async Task<StoreOffers> GetOfferByIdAsync(string id)
        {
            return await _context.StoreOffers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertOfferAsync(StoreOffers offer)
        {
            await _context.StoreOffers.AddAsync(offer);
        }

        public async Task<IEnumerable<StoreOffers>> SearchOffersByCityAsync(long cityId)
        {
            return await _context.StoreOffers
                                 .Include(x => x.Store)
                                    .ThenInclude(x => x.City)
                                 .AsNoTracking()
                                 .Where(x => x.Store.City.Id == cityId)
                                 .OrderByDescending(x => x.CreationDate)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<StoreOffers>> SearchOffersByStoreAsync(string storeId)
        {
            return await _context.StoreOffers
                           .AsNoTracking()
                           .Where(x => x.StoreId == storeId)
                           .ToListAsync();
        }
    }

}