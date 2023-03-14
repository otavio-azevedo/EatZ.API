using EatZ.Domain.Entities;
using EatZ.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace EatZ.Infra.CrossCutting.IoC
{
    public static class IdentityInjection
    {
        public static void AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.User.RequireUniqueEmail = true;
            })
           .AddEntityFrameworkStores<EatzDbContext>()
           .AddDefaultTokenProviders();
        }
    }
}