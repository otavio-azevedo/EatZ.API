using EatZ.API.Models.Location.Responses;
using EatZ.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace EatZ.API.Models.Location
{
    public static class LocationMappers
    {
        public static IEnumerable<SearchCityResponse> Map(IEnumerable<City> cities)
        {
            if (cities.IsNullOrEmpty())
            {
                return Enumerable.Empty<SearchCityResponse>();
            }

            return cities.Select(x => new SearchCityResponse(x.Name, x.Latitude, x.Longitude, x?.State?.Name, x.State?.Country?.Name));
        }
    }
}
