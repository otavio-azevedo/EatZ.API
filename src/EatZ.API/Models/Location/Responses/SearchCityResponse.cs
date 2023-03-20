namespace EatZ.API.Models.Location.Responses
{
    public class SearchCityResponse
    {
        public SearchCityResponse(long cityId, string cityName, double latitude, double longitude, string stateName, string countryName)
        {
            CityId = cityId;
            CityName = cityName;
            Latitude = latitude;
            Longitude = longitude;
            StateName = stateName;
            CountryName = countryName;
        }

        public long CityId { get; set; }
        
        public string CityName { get; set; }

        public double Latitude { get; set; }
        
        public double Longitude { get; set; }

        public string StateName { get; set; }
        
        public string CountryName { get; set; }

    }
}
