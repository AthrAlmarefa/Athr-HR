using Athr.Domain.BusinessRoles;
using Athr.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athr.Infrastructure.Configurations;

internal sealed class BusinessRoleConfiguration : IEntityTypeConfiguration<BusinessRole>
{

    public void Configure(EntityTypeBuilder<BusinessRole> builder)
    {

        builder.ToTable("businessRoles");

        builder.HasKey(t => t.Id);
        builder.Property(i => i.Id).HasConversion(id => id.Value, value => AccountId.Create(value))
            .ValueGeneratedNever().IsRequired();

        builder.OwnsMany(b => b.AllowedPermissions, ap =>
        {
            ap.ToTable("business_allowed_permissions");
            ap.WithOwner().HasForeignKey("business_id");
            ap.Property(p => p.PermissionId)
                .HasConversion(id => id.Value, value => value)
                .IsRequired();
            ap.Property(p => p.Name).HasColumnName("name").IsRequired();
            ap.Property<Guid>("Id").ValueGeneratedOnAdd();
            ap.HasKey("Id");
        });
    }
}
