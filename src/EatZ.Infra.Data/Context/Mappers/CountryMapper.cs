using EatZ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatZ.Infra.Data.Context.Mappers
{
    public class CountryMapper : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("COUNTRIES");
            builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
            builder.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Acronym).HasColumnName("ACRONYM").HasMaxLength(2).IsRequired();
        }
    }
}
