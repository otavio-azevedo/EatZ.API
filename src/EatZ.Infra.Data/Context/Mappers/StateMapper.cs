using EatZ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatZ.Infra.Data.Context.Mappers
{
    public class StateMapper : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("STATES");
            builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
            builder.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Acronym).HasColumnName("ACRONYM").HasMaxLength(2).IsRequired();
            builder.Property(x => x.CountryId).HasColumnName("COUNTRY_ID").IsRequired();
            builder.HasOne(x => x.Country)
                   .WithMany(x => x.States)
                   .HasForeignKey(x => x.CountryId)
                   .HasConstraintName("FK_STATE_COUNTRY")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
