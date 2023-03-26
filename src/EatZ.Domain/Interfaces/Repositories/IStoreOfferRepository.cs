using EatZ.Domain.Entities;

namespace EatZ.Domain.Interfaces.Repositories
{
    public interface IStoreOfferRepository
    {
        Task InsertOfferAsync(StoreOffers offer);

        Task<StoreOffers> GetOfferByIdAsync(string id);

        void DeleteOffer(StoreOffers offer);

        Task<IEnumerable<StoreOffers>> SearchOffersByStoreAsync(string storeId);

        Task<IEnumerable<StoreOffers>> SearchOffersByCityAsync(long cityId);
    }
}