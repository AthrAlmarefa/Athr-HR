
using Athr.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athr.Infrastructure.Configurations;

internal class CategoryConfiguration() : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasConversion(id => id.Value, value => value);
        builder.HasIndex(u => u.Name).IsUnique();

        builder.Property(c => c.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
        builder.Property(c => c.DeletedAt).HasColumnName("deleted_at").IsRequired(false);
        builder.Property(c => c.DeletedBy).HasColumnName("deleted_by").IsRequired(false);

        builder.HasQueryFilter(c => !c.IsDeleted);

        builder.Property(u => u.Name).HasMaxLength(128);
    }
}
