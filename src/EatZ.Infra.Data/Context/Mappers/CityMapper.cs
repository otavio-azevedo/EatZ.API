using EatZ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatZ.Infra.Data.Context.Mappers
{
    public class CityMapper : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("CITIES");
            builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
            builder.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Latitude).HasColumnName("LATITUDE").IsRequired();
            builder.Property(x => x.Longitude).HasColumnName("LONGITUDE").IsRequired();
            builder.Property(x => x.StateId).HasColumnName("STATE_ID").IsRequired();
            builder.HasOne(x => x.State)
                   .WithMany(x => x.Cities)
                   .HasForeignKey(x => x.StateId)
                   .HasConstraintName("FK_CITY_STATE")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
