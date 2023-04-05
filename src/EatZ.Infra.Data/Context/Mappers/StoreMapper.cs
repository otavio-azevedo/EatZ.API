using EatZ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatZ.Infra.Data.Context.Mappers
{
    public class StoreMapper : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("STORES");
            builder.Property(x => x.Id).HasColumnName("ID").HasMaxLength(36).IsRequired();
            builder.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();
            builder.Property(x => x.DocumentNumber).HasColumnName("DOCUMENT_NUMBER").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Phone).HasColumnName("PHONE").HasMaxLength(15).IsRequired();
            builder.Property(x => x.ZipCode).HasColumnName("ZIP_CODE").HasMaxLength(10).IsRequired();
            builder.Property(x => x.Street).HasColumnName("STREET").HasMaxLength(50).IsRequired();
            builder.Property(x => x.StreetNumber).HasColumnName("STREET_NUMBER").IsRequired();
            builder.Property(x => x.Neighborhood).HasColumnName("NEIGHBORHOOD").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Complement).HasColumnName("COMPLEMENT").HasMaxLength(50);
            builder.Property(x => x.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
            builder.Property(x => x.Description).HasColumnName("DESCRIPTION").HasMaxLength(500).IsRequired();
            builder.Property(x => x.AdminId).HasColumnName("ADMIN_ID").IsRequired();
            builder.HasOne(x => x.Admin)
                   .WithOne()
                   .HasForeignKey<Store>(v => v.AdminId)
                   .HasConstraintName("FK_USERS_STORE_ID")
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.CityId).HasColumnName("CITY_ID").IsRequired();
            builder.HasOne(x => x.City)
                   .WithMany()
                   .HasForeignKey(v => v.CityId)
                   .HasConstraintName("FK_CITIES_STORE_ID")
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Latitude).HasColumnName("LATITUDE").IsRequired();
            builder.Property(x => x.Longitude).HasColumnName("LONGITUDE").IsRequired();

            builder.Ignore(x => x.AverageReview);
        }
    }
}
