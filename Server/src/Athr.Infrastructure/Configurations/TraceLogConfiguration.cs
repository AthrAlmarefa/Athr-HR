using Athr.Application.Abstractions.Tracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athr.Infrastructure.Configurations;

public class TraceLogConfiguration : IEntityTypeConfiguration<TraceLog>
{
    public void Configure(EntityTypeBuilder<TraceLog> builder)
    {
        builder.ToTable("trace_logs");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserId).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Type).HasMaxLength(50).IsRequired();
        builder.Property(x => x.TableName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.DateTime).IsRequired();
        builder.Property(x => x.OldValues);
        builder.Property(x => x.NewValues);
        builder.Property(x => x.AffectedColumns);
        builder.Property(x => x.PrimaryKey);
    }
}
