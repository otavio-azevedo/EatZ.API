using EatZ.Domain.DTOs;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EatZ.Infra.Data.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly EatzDbContext _context;

        public ReviewRepository(EatzDbContext context)
        {
            _context = context;
        }

        public async Task InsertReviewAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
        }

        public IEnumerable<StoreAverageReviewDto> GetAverageStoreRatingByCity(long cityId)
        {
            return _context.Reviews
                                  .Include(x => x.Order)
                                     .ThenInclude(x => x.Store)
                                  .AsNoTracking()
                                  .Where(x => x.Order.Store.City.Id == cityId)
                                  .GroupBy(x => x.Order.StoreId)
                                  .Select(x => new StoreAverageReviewDto(x.Key, x.Average(x => x.Rating), x.Count()));
        }
    }
}
