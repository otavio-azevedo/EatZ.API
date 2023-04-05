using EatZ.Domain.DTOs;
using EatZ.Domain.Entities;

namespace EatZ.Domain.Interfaces.Repositories
{
    public interface IReviewRepository
    {
        Task InsertReviewAsync(Review review);

        IEnumerable<StoreAverageReviewDto> GetAverageStoreRatingByCity(long cityId);
    }
}
