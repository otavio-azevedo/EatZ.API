using EatZ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatZ.Infra.Data.Context.Mappers
{
    public class ReviewMapper : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("REVIEWS");
            builder.Property(x => x.Id).HasColumnName("ID").HasMaxLength(36).IsRequired();
            builder.Property(x => x.OrderId).HasColumnName("ORDER_ID").HasMaxLength(36).IsRequired();
            builder.Property(x => x.Comment).HasColumnName("COMMENT").HasMaxLength(200);
            builder.Property(x => x.Rating).HasColumnName("RATING");

            builder.HasOne(x => x.Order)
                   .WithOne(x => x.Review)
                   .HasForeignKey<Review>(x => x.OrderId)
                   .HasConstraintName("FK_REVIEW_ORDER")
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
