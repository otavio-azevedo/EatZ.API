using EatZ.Domain.DTOs;
using EatZ.Domain.Interfaces.ExternalServices;
using EatZ.ExternalServices.Google.Routes;
using EatZ.ExternalServices.Google.Services.Geocoding.Responses;
using EatZ.Infra.CrossCutting.Extensions;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EatZ.ExternalServices.Google.Services.Geocoding
{
    public class GoogleGeocodingApi : IGoogleGeocodingApi
    {
        private readonly HttpClient _httpClient;
        private readonly INotificationContext _notificationContext;
        private readonly string _apiKey;

        public GoogleGeocodingApi(HttpClient httpClient, INotificationContext notificationContext, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _notificationContext = notificationContext;
            _apiKey = configuration.GetSection($"ExternalServices:{nameof(GoogleGeocodingApi)}:Key").Value;
        }

        public async Task<GetCoordinatesDto> GetCoordinatesAsync(string zipCode, string neighborhood, string street, int streetNumber)
        {
            //TODO: It's necessary new api key
            return new GetCoordinatesDto(-29.684768298947713, -51.12606835789034);

            StringBuilder fullAddress = new StringBuilder();
            fullAddress.AppendJoin(' ', zipCode, neighborhood, street, streetNumber);

            var response = await _httpClient.GetAsync($"{GeocodingApiRoutes.GetCoordinates}?address={fullAddress}&key={_apiKey}");

            if (!response.IsSuccessStatusCode)
            {
                string contentError = response.Content.ReadAsStringAsync().Result;
                _notificationContext.AddNotification($"{response.StatusCode}:{contentError}");
                return default;
            }

            var parsedResponse = await response.Content.ReadAsJsonAsync<GetCoordinatesResponse>();

            if (parsedResponse == default || parsedResponse.Results.IsNullOrEmpty())
            {
                _notificationContext.AddNotification("Falha ao obter as coordenadas geográficas a partir dos dados informados.");
                return default;
            }

            var result = parsedResponse.Results.First();

            return new GetCoordinatesDto(result.Geometry.Location.Lat, result.Geometry.Location.Lng);

        }
    }
}
