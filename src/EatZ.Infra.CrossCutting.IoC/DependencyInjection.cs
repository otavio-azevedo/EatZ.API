using EatZ.Domain.DomainServices.Authentication;
using EatZ.Domain.Interfaces.DomainServices;
using Microsoft.Extensions.DependencyInjection;

namespace EatZ.Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
