using Athr.Application.Abstractions.Clock;
using Athr.Application.Abstractions.Tracking;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace Athr.Infrastructure.Tracing;

public class TraceEntry
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public TraceEntry(EntityEntry entry, IDateTimeProvider dateTimeProvider)
    {
        Entry = entry;
        _dateTimeProvider = dateTimeProvider;
    }

    public EntityEntry Entry { get; }
    public string UserId { get; set; }
    public string TableName { get; set; }

    public string InterceptionUniqueId { get; set; }
    public string EntryString { get; set; }
    public Dictionary<string, object?> KeyValues { get; } = new();
    public Dictionary<string, object?> OldValues { get; } = new();
    public Dictionary<string, object?> NewValues { get; } = new();
    public TraceType AuditType { get; set; }
    public List<string> ChangedColumns { get; } = new();

    public TraceLog ToTraceLog()
    {
        var audit = new TraceLog
        {
            UserId = UserId,
            Type = AuditType.ToString(),
            TableName = TableName,
            EntryString = EntryString,
            InterceptionUniqueId = InterceptionUniqueId,
            DateTime = _dateTimeProvider.UtcNow,
            PrimaryKey = JsonConvert.SerializeObject(KeyValues),
            OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
            NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues),
            AffectedColumns = ChangedColumns.Count == 0 ? null : JsonConvert.SerializeObject(ChangedColumns)
        };
        return audit;
    }
}
