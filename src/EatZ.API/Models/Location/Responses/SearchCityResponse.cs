namespace EatZ.API.Models.Location.Responses
{
    public class SearchCityResponse
    {
        public SearchCityResponse(long cityId, string cityName, double latitude, double longitude, string stateAcronym, string countryAcronym)
        {
            CityId = cityId;
            CityName = cityName;
            Latitude = latitude;
            Longitude = longitude;
            StateAcronym = stateAcronym;
            CountryAcronym = countryAcronym;
        }

        public long CityId { get; set; }

        public string CityName { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string StateAcronym { get; set; }

        public string CountryAcronym { get; set; }

    }
}
