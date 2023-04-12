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

            return cities.Select(x => new SearchCityResponse(x.Id, x.Name, x.Latitude, x.Longitude, x?.State?.Acronym, x.State?.Country?.Acronym));
        }

        public static IEnumerable<GetStatesByCountryResponse> Map(IEnumerable<State> states)
        {
            if (states.IsNullOrEmpty())
            {
                return Enumerable.Empty<GetStatesByCountryResponse>();
            }

            return states.Select(x => new GetStatesByCountryResponse(x.Id, x.Name)).OrderBy(x => x.Id);
        }

        public static IEnumerable<GetCitiesByStateResponse> MapCities(IEnumerable<City> cities)
        {
            if (cities.IsNullOrEmpty())
            {
                return Enumerable.Empty<GetCitiesByStateResponse>();
            }

            return cities.Select(x => new GetCitiesByStateResponse(x.Id, x.Name)).OrderBy(x=>x.Id);
        }
    }
}
