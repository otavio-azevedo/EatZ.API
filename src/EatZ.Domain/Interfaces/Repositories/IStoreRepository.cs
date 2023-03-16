using EatZ.Domain.Entities;

namespace EatZ.Domain.Interfaces.Repositories
{
    public interface IStoreRepository
    {
        Task InsertStoreAsync(Store store);
        
        Task<Store> GetStoreByIdAsync(string id);

        void DeleteStore(Store store);
        
        Task<IEnumerable<Store>> SearchStoresAsync(string country, string state, string city, string neighborhood, string street);
    }
}
