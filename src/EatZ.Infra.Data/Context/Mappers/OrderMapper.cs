using EatZ.Domain.Entities;
using EatZ.Infra.CrossCutting.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatZ.Infra.Data.Context.Mappers
{
    public class OrderMapper : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("ORDERS");
            builder.Property(x => x.Id).HasColumnName("ID").HasMaxLength(36).IsRequired();
            builder.Property(x => x.StoreId).HasColumnName("STORE_ID").HasMaxLength(36).IsRequired();
            builder.Property(x => x.ClientUserId).HasColumnName("CLIENT_USER_ID").HasMaxLength(36).IsRequired();
            builder.Property(x => x.OfferId).HasColumnName("OFFER_ID").HasMaxLength(36).IsRequired();
            builder.Property(x => x.CreationDate).HasColumnName("CREATION_DATE").IsRequired();
            builder.Property(x => x.ConfirmationDate).HasColumnName("CONFIRMATION_DATE");
            builder.Property(x => x.PickUpDate).HasColumnName("PICK_UP_DATE");
            builder.Property(x => x.Status)
                   .HasColumnName("STATUS")
                   .HasConversion(x => (int)x, x => (EOrderStatus)x)
                   .IsRequired();

            builder.HasOne(x => x.Store)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.StoreId)
                   .HasConstraintName("FK_ORDERS_STORE")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Client)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.ClientUserId)
                   .HasConstraintName("FK_ORDERS_CLIENT")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Offer)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.OfferId)
                   .HasConstraintName("FK_ORDERS_OFFER")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
