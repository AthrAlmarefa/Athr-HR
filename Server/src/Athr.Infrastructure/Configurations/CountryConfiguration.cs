
using Athr.Domain.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athr.Infrastructure.Configurations;

internal sealed class CountryConfiguration() : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("countries");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
               .HasConversion(id => id.Value, val => CountryId.Create(val))
               .HasComment("Country IsoCode")
               .IsRequired();

        builder.Property(c => c.DialCode)
               .HasColumnName("dial_code")
               .IsRequired()
               .HasMaxLength(10);

        //
        // CountryName children
        //
        builder.HasMany(c => c.Names)
               .WithOne()                           // assuming CountryName has only CountryId FK
               .HasForeignKey(n => n.CountryId)
               .OnDelete(DeleteBehavior.Cascade);

        // tell EF to use the private backing field
        builder.Navigation(nameof(Country.Names))
               .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
