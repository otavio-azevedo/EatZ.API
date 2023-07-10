using EatZ.ExternalServices.Google.Services.Geocoding;
using EatZ.ExternalServices.Google.Services.Geocoding.Responses;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using System.Net;
using System.Text.Json;

namespace EatZ.ExternalServices.Google.Tests.Services
{
    public class GoogleGeocodingApiTests
    {
        private readonly GoogleGeocodingApi _googleGeocodingApi;
        private readonly HttpClient _httpClient;
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler = new(MockBehavior.Strict);
        private readonly INotificationContext _notificationContext;
        private const string SectionApiKey = $"ExternalServices:{nameof(GoogleGeocodingApi)}:Key";

        public GoogleGeocodingApiTests()
        {
            var mockConfSection = new Mock<IConfigurationSection>();
            mockConfSection.SetupGet(m => m[It.Is<string>(s => s == SectionApiKey)]).Returns("123456");
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(a => a.GetSection(It.Is<string>(s => s == SectionApiKey))).Returns(mockConfSection.Object);
            
            _httpClient = new HttpClient(_mockHttpMessageHandler.Object);
            _httpClient.BaseAddress = new Uri("https://dummy.com");
            
            _notificationContext = new NotificationContext();
            _googleGeocodingApi = new GoogleGeocodingApi(_httpClient, _notificationContext, mockConfiguration.Object);
        }

        [Fact(Skip=("Temp - API KEY"))]
        public async Task Error_BadRequest()
        {
            string mockResponseJson = "{\r\n    \"error_message\": \"Invalid request. Missing the 'address', 'components', 'latlng' or 'place_id' parameter.\",\r\n    \"results\": [],\r\n    \"status\": \"INVALID_REQUEST\"\r\n}";
            SetupMockHttpMessageHandler(HttpStatusCode.BadRequest, mockResponseJson);

            var result = await _googleGeocodingApi.GetCoordinatesAsync(default, default, default, default);

            Assert.Null(result);
            Assert.True(_notificationContext.HasNotifications);
        }

        [Fact(Skip = ("Temp - API KEY"))]
        public async Task Error_InvalidApiKey()
        {
            string mockResponseJson = "{\r\n    \"error_message\": \"The provided API key is invalid. \",\r\n    \"results\": [],\r\n    \"status\": \"REQUEST_DENIED\"\r\n}";
            SetupMockHttpMessageHandler(HttpStatusCode.OK, mockResponseJson);

            var result = await _googleGeocodingApi.GetCoordinatesAsync(default, default, default, default);

            Assert.Null(result);
            Assert.True(_notificationContext.HasNotifications);
        }

        [Fact(Skip = ("Temp - API KEY"))]
        public async Task Error_Null()
        {
            var mockResponse = new GetCoordinatesResponse();
            SetupMockHttpMessageHandler(HttpStatusCode.OK, JsonSerializer.Serialize(mockResponse));

            var result = await _googleGeocodingApi.GetCoordinatesAsync(default, default, default, default);

            Assert.Null(result);
            Assert.True(_notificationContext.HasNotifications);
        }

        [Fact]
        public async Task Success()
        {
            string mockResponseJson = "{\r\n    \"results\": [\r\n        {\r\n            \"address_components\": [\r\n                {\r\n                    \"long_name\": \"221\",\r\n                    \"short_name\": \"221\",\r\n                    \"types\": [\r\n                        \"street_number\"\r\n                    ]\r\n                },\r\n                {\r\n                    \"long_name\": \"Rua Joaquim Pedro Soares\",\r\n                    \"short_name\": \"R. Joaquim Pedro Soares\",\r\n                    \"types\": [\r\n                        \"route\"\r\n                    ]\r\n                },\r\n                {\r\n                    \"long_name\": \"Centro\",\r\n                    \"short_name\": \"Centro\",\r\n                    \"types\": [\r\n                        \"political\",\r\n                        \"sublocality\",\r\n                        \"sublocality_level_1\"\r\n                    ]\r\n                },\r\n                {\r\n                    \"long_name\": \"Novo Hamburgo\",\r\n                    \"short_name\": \"Novo Hamburgo\",\r\n                    \"types\": [\r\n                        \"administrative_area_level_2\",\r\n                        \"political\"\r\n                    ]\r\n                },\r\n                {\r\n                    \"long_name\": \"Rio Grande do Sul\",\r\n                    \"short_name\": \"RS\",\r\n                    \"types\": [\r\n                        \"administrative_area_level_1\",\r\n                        \"political\"\r\n                    ]\r\n                },\r\n                {\r\n                    \"long_name\": \"Brazil\",\r\n                    \"short_name\": \"BR\",\r\n                    \"types\": [\r\n                        \"country\",\r\n                        \"political\"\r\n                    ]\r\n                },\r\n                {\r\n                    \"long_name\": \"93510-320\",\r\n                    \"short_name\": \"93510-320\",\r\n                    \"types\": [\r\n                        \"postal_code\"\r\n                    ]\r\n                }\r\n            ],\r\n            \"formatted_address\": \"R. Joaquim Pedro Soares, 221 - Centro, Novo Hamburgo - RS, 93510-320, Brazil\",\r\n            \"geometry\": {\r\n                \"bounds\": {\r\n                    \"northeast\": {\r\n                        \"lat\": -29.6848585,\r\n                        \"lng\": -51.1259919\r\n                    },\r\n                    \"southwest\": {\r\n                        \"lat\": -29.684967,\r\n                        \"lng\": -51.1260998\r\n                    }\r\n                },\r\n                \"location\": {\r\n                    \"lat\": -29.6849082,\r\n                    \"lng\": -51.1260576\r\n                },\r\n                \"location_type\": \"ROOFTOP\",\r\n                \"viewport\": {\r\n                    \"northeast\": {\r\n                        \"lat\": -29.6835637697085,\r\n                        \"lng\": -51.12476256970849\r\n                    },\r\n                    \"southwest\": {\r\n                        \"lat\": -29.6862617302915,\r\n                        \"lng\": -51.12746053029149\r\n                    }\r\n                }\r\n            },\r\n            \"place_id\": \"ChIJFawBy7FDGZURgL-F5GYnHSg\",\r\n            \"types\": [\r\n                \"premise\"\r\n            ]\r\n        }\r\n    ],\r\n    \"status\": \"OK\"\r\n}";
            SetupMockHttpMessageHandler(HttpStatusCode.OK, mockResponseJson);

            var result = await _googleGeocodingApi.GetCoordinatesAsync(default, default, default, default);

            Assert.NotNull(result);
            Assert.False(_notificationContext.HasNotifications);
        }

        private void SetupMockHttpMessageHandler(HttpStatusCode statusCode, string content)
        {
            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = statusCode,
                    Content = new StringContent(content)
                });
        }
    }
}