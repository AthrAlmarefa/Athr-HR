
using Athr.Domain.Common.Account;
using Athr.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athr.Infrastructure.Configurations;

//public class AccountConfiguration : IEntityTypeConfiguration<Account>
//{
//    public void Configure(EntityTypeBuilder<Account> builder)
//    {
//        builder.ToTable("accounts");

//        builder.Property(i => i.Id).HasConversion(id => id.Value, value => AccountId.Create(value))
//            .ValueGeneratedNever();

//        builder.Property(i => i.CreatedAtUtc).HasColumnName("created_at_utc").IsRequired();

//        builder.Property(i => i.LastModifiedAtUtc).HasColumnName("last_modified_at_utc").IsRequired(false);

//        builder.Property(i => i.CreatedBy).HasColumnName("created_by").IsRequired();

//        builder.Property(i => i.LastModifiedBy).HasColumnName("last_modified_by").IsRequired(false);


//        builder.Property(i => i.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);

//        builder.Property(i => i.DeletedAt).HasColumnName("deleted_at").IsRequired(false);

//        builder.Property(i => i.DeletedBy).HasColumnName("deleted_by").IsRequired(false);

//        builder.HasQueryFilter(x => !x.IsDeleted);
//    }
//}
