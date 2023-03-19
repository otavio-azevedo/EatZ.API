using EatZ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatZ.Infra.Data.Context.Mappers
{
    public class StoreImagesMapper : IEntityTypeConfiguration<StoreImages>
    {
        public void Configure(EntityTypeBuilder<StoreImages> builder)
        {
            builder.ToTable("STORE_IMAGES");
            builder.Property(x => x.Id).HasColumnName("ID").HasMaxLength(36).IsRequired();
            builder.Property(x => x.Title).HasColumnName("TITLE").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Content).HasColumnName("CONTENT").IsRequired();
            builder.Property(x => x.StoreId).HasColumnName("STORE_ID").HasMaxLength(36).IsRequired();
            builder.HasOne(x => x.Store)
                   .WithMany(x => x.Images)
                   .HasForeignKey(x => x.StoreId)
                   .HasConstraintName("FK_STORE_IMAGES")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
