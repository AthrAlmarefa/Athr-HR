using Athr.Domain.Countries;
using Athr.Domain.Permissions;
using Athr.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athr.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{

    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("users");

        builder.HasKey(t => t.Id);
        builder.Property(i => i.Id).HasConversion(id => id.Value, value => AccountId.Create(value))
            .ValueGeneratedNever();

        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.MidName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(u => u.IdentityNumber)
                .IsRequired()
                .HasMaxLength(100);

        // Country dialCode_id (CountryId DialCode)
        builder.Property(s => s.DialCodeId)
            .HasColumnName("dialCode_id")
            .HasConversion(
                id => id.Value,
                value => CountryId.Create(value))
            .HasDefaultValue(CountryId.Create("SA")) // Default to Saudi Arabia
            .IsRequired();

        // RolesPermissions Configuration
        builder.OwnsMany(
            u => u.BusinessPermissions,
            permissionsBuilder =>
            {
                permissionsBuilder.ToTable("user_roles_permissions");
                permissionsBuilder.WithOwner().HasForeignKey("user_id");

                // Configure PermissionId conversion
                permissionsBuilder.Property(p => p.PermissionId)
                    .HasConversion(
                        id => id.Value,
                        value => PermissionId.Create(value) // Explicit constructor call
                    );

                // Configure BusinessRoleId conversion
                permissionsBuilder.Property(p => p.BusinessRoleId)
                    .HasConversion(
                        id => id.Value,
                        value => AccountId.Create(value) // Explicit constructor call
                    );

                permissionsBuilder.Property<Guid>("Id")
                    .ValueGeneratedOnAdd();

                permissionsBuilder.HasKey("Id");

                builder.Property(bp => bp.IsActive)
                    .HasDefaultValue(true);
            });

        builder.OwnsMany(b => b.BusinessRoles, _businessRoles =>
        {
            _businessRoles.ToTable("user_businesses");
            _businessRoles.WithOwner().HasForeignKey("user_id");
            _businessRoles.Property(e => e.Value).HasColumnName("business_id").IsRequired();
            _businessRoles.Property<Guid>("Id").ValueGeneratedOnAdd();
            _businessRoles.HasKey("Id");
        });

    }
}
