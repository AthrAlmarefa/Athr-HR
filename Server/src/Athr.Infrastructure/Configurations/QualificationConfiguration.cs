using Athr.Domain.Qualification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athr.Infrastructure.Configurations;

public class QualificationConfiguration : IEntityTypeConfiguration<Qualification>
{
    public void Configure(EntityTypeBuilder<Qualification> builder)
    {
        builder.ToTable("qualifications");
        builder.HasKey(n => n.Id);

        builder.Property(n => n.Id)
               .HasConversion(id => id.Value, val => QualificationId
               .Create(val))
               .ValueGeneratedOnAdd()
               .IsRequired();

        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
    }
}
