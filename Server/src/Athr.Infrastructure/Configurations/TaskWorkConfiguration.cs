using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athr.Domain.Common;
using Athr.Domain.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            // Configuration for Priority record - store as owned entity
            builder.OwnsOne(t => t.Priority, p =>
            {
                p.Property(pp => pp.Value)
                 .HasColumnName("PriorityValue")
                 .IsRequired();

                p.Property(pp => pp.Name)
                 .HasColumnName("PriorityName")
                 .HasMaxLength(20)
                 .IsRequired();
            });

            builder.Property(s => s.StartDate)
                   .HasColumnName("StartDate")
                   .IsRequired();

            builder.Property(s => s.EndDate)
                   .HasColumnName("EndDate")
                   .IsRequired();

            // Description as owned entity
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

            // Add query filter for soft delete
            builder.HasQueryFilter(t => !t.IsDeleted);

        }

    }
}

