using EatZ.API.Models.Stores.Responses;
using EatZ.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace EatZ.API.Models.Stores
{
    public static class StoresMappers
    {
        public static IEnumerable<SearchStoresResponse> Map(IEnumerable<Store> stores)
        {
            if (stores.IsNullOrEmpty())
                return Enumerable.Empty<SearchStoresResponse>();

            return stores.Select(s => new SearchStoresResponse(
                s.Id,
                s.Name,
                s.Phone,
                s.ZipCode,
                s.Country,
                s.State,
                s.City,
                s.Neighborhood,
                s.Street,
                s.StreetNumber,
                s.Complement
                ));
        }
    }
}
