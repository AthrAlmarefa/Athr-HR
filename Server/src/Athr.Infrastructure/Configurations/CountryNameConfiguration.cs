using Athr.Domain.Common;
using Athr.Domain.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athr.Infrastructure.Configurations;

public class CountryNameConfiguration : IEntityTypeConfiguration<CountryName>
{
    public void Configure(EntityTypeBuilder<CountryName> builder)
    {
        builder.ToTable("country_names");
        builder.HasKey(n => n.Id);

        builder.Property(n => n.Id)
               .HasConversion(id => id.Value, val => LocalizedNameId.Create(val))
               .ValueGeneratedOnAdd()
               .IsRequired();

        builder.Property(n => n.CountryId)
               .HasConversion(id => id.Value, val => CountryId.Create(val))
               .IsRequired();

        builder.Property(n => n.Value)
               .HasColumnName("name")
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(n => n.Culture)
               .HasColumnName("culture")
               .HasMaxLength(10)
               .HasConversion(c => c.Code, code => Culture.FromCode(code));

        builder.Property(n => n.IsDefault)
               .HasColumnName("is_default")
               .IsRequired();

        builder.HasOne<Country>()
               .WithMany(c => c.Names)
               .HasForeignKey(n => n.CountryId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
