using EatZ.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EatZ.Infra.Data.Context
{
    public class EatzDbContext : IdentityDbContext<User>
    {
        private readonly IConfiguration _configuration;

        public DbSet<Store> Stores { get; set; }

        public DbSet<StoreImages> StoreImages { get; set; }

        public DbSet<StoreOffers> StoreOffers { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        public EatzDbContext(DbContextOptions<EatzDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString: _configuration.GetConnectionString("Default"));

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(EatzDbContext).Assembly);
        }
    }
}
