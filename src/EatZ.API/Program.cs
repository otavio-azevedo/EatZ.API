using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.IoC;
using EatZ.Infra.CrossCutting.Settings;
using EatZ.Infra.CrossCutting.Utility.Filters.Notification;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using EatZ.Infra.Data.Context;
using EatZ.Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace EatZ.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configs
            ConfigurationManager configuration = builder.Configuration;

            // Settings
            builder.Services.Configure<JwtSettings>((options => configuration.GetSection(nameof(JwtSettings)).Bind(options)));

            // DbContext
            builder.Services.AddDbContext<EatzDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Default")));

            // HttpContextAccessor
            builder.Services.AddHttpContextAccessor();

            // Identity
            builder.Services.AddIdentityServices();

            // JWT
            builder.Services.AddJwtServices(configuration);

            // Domain Services
            builder.Services.AddDomainServices();

            // Repositories
            builder.Services.AddRepositories();

            // IoW
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Notifications
            builder.Services.AddScoped<INotificationContext, NotificationContext>();

            // MediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("EatZ.Domain")));

            // Controllers
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(typeof(NotificationFilter));
            })
           .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // Swagger
            builder.Services.AddSwaggerServices();

            builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            RunApplication(builder);
        }

        private static void RunApplication(WebApplicationBuilder builder)
        {
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers().RequireAuthorization();

            app.Run();
        }
    }
}