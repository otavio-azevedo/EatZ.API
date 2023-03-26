using EatZ.Domain.Entities;
using EatZ.Infra.CrossCutting.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatZ.Infra.Data.Context.Mappers
{
    public class StoreOffersMapper : IEntityTypeConfiguration<StoreOffers>
    {
        public void Configure(EntityTypeBuilder<StoreOffers> builder)
        {
            builder.ToTable("STORE_OFFERS");
            builder.Property(x => x.Id).HasColumnName("ID").HasMaxLength(36).IsRequired();
            builder.Property(x => x.Description).HasColumnName("DESCRIPTION").HasMaxLength(200).IsRequired();
            builder.Property(x => x.NetUnitPrice).HasColumnName("NET_UNIT_PRICE").IsRequired();
            builder.Property(x => x.GrossUnitPrice).HasColumnName("GROSS_UNIT_PRICE").IsRequired();
            builder.Property(x => x.Quantity).HasColumnName("QUANTITY").IsRequired();
            builder.Property(x => x.Taste)
                            .HasColumnName("TASTE")
                            .HasConversion(
                             x => (int)x,
                             x => (EFoodTaste)x)
                             .IsRequired();

            builder.Property(x => x.CreationDate).HasColumnName("CREATION_DATE").IsRequired();
            builder.Property(x => x.ExpirationDate).HasColumnName("EXPIRATION_DATE").IsRequired();
            builder.Property(x => x.PickUpDate).HasColumnName("PICK_UP_DATE").IsRequired();

            builder.Property(x => x.StoreId).HasColumnName("STORE_ID").HasMaxLength(36).IsRequired();
            builder.HasOne(x => x.Store)
                   .WithMany(x => x.Offers)
                   .HasForeignKey(x => x.StoreId)
                   .HasConstraintName("FK_STORE_OFFERS")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
