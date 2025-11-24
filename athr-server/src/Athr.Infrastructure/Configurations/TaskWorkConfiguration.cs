using Athr.Domain.TaskWork;
using Athr.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Linq;
namespace Athr.Infrastructure.Configurations
{
    public class TaskWorkConfiguration : IEntityTypeConfiguration<TaskWork>
    {

        public void Configure(EntityTypeBuilder<TaskWork> builder)
        {

            builder.ToTable("task_works");

            builder.HasKey(tw => tw.Id);

            builder.Property(tw => tw.Id)
                   .HasConversion(
                       id => id.Value,
                       value => TaskWorkId.Create(value))
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(t => t.Name)
                   .HasMaxLength(200)
                   .IsRequired()
                   .HasColumnName("Name");

            builder.Property(t => t.UserId)
                   .HasConversion(
                       id => id.Value,
                       value => AccountId.Create(value))
                   .HasColumnName("UserId")
                   .IsRequired();

            builder.OwnsOne(t => t.Priority, p =>
              {
                p.Property(pp => pp.Key)
                 .HasColumnName("PriorityKey")
                 .IsRequired();

            p.Property(pp => pp.Value)
                 .HasColumnName("PriorityValue")
                 .HasMaxLength(20)
                 .IsRequired();
                 });

            builder.Property(s => s.StartDate)
                   .HasColumnName("StartDate")
                   .IsRequired();

            builder.Property(s => s.EndDate)
                   .HasColumnName("EndDate")
                   .IsRequired();

   
           builder.OwnsOne(t => t.Description, d =>
            {
                d.Property(dd => dd.Value)
                 .HasColumnName("Description")
                 .HasMaxLength(1000)
                 .IsRequired(false);
                 });

           builder.Property(t => t.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("IsDeleted");

            builder.Property(t => t.DeletedAt)
              .HasColumnName("DeletedAt")
              .IsRequired(false);

             builder.Property(t => t.DeletedBy)
               .HasColumnName("DeletedBy")
               .HasMaxLength(100)
              .IsRequired(false);

            builder.Property(t => t.IsActive).HasDefaultValue(false);
            builder.HasQueryFilter(t => !t.IsDeleted);

        }
    }
}
