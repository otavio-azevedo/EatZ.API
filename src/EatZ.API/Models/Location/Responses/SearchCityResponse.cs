namespace EatZ.API.Models.Location.Responses
{
    public class SearchCityResponse
    {
        public SearchCityResponse(string cityName, double latitude, double longitude, string stateName, string countryName)
        {
            CityName = cityName;
            Latitude = latitude;
            Longitude = longitude;
            StateName = stateName;
            CountryName = countryName;
        }

        public string CityName { get; set; }

        public double Latitude { get; set; }
        
        public double Longitude { get; set; }

        public string StateName { get; set; }
        
        public string CountryName { get; set; }

    }
}
