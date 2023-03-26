using EatZ.Domain.DomainServices.Authentication;
using EatZ.Domain.Interfaces.DomainServices;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EatZ.Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IStoreOfferRepository, StoreOfferRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
        }
    }
}
