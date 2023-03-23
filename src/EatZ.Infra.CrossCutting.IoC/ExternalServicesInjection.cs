using EatZ.Domain.Interfaces.ExternalServices;
using EatZ.ExternalServices.Google.Services.Geocoding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EatZ.Infra.CrossCutting.IoC
{
    public static class ExternalServicesInjection
    {
        public static void AddExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IGoogleGeocodingApi, GoogleGeocodingApi>(client =>
            {
                client.BaseAddress = new Uri(configuration.GetValue<string>($"ExternalServices:{nameof(GoogleGeocodingApi)}:BaseAddress"));
            });
        }
    }
}
