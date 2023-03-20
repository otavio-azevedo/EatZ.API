using EatZ.API.Models.Stores.Responses;
using EatZ.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace EatZ.API.Models.Stores
{
    public static class StoresMappers
    {
        public static IEnumerable<SearchStoresByCityResponse> Map(IEnumerable<Store> stores)
        {
            if (stores.IsNullOrEmpty())
                return Enumerable.Empty<SearchStoresByCityResponse>();

            return stores.Select(s => new SearchStoresByCityResponse(
                s.Id,
                s.Name,
                s.Latitude,
                s.Longitude));
        }
    }
}
