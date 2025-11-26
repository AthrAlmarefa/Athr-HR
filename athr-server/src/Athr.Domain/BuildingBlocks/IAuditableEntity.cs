namespace Athr.Domain.BuildingBlocks;

public interface IAuditableEntity
{
    DateTimeOffset CreatedAtUtc { get; set; }
    DateTimeOffset? LastModifiedAtUtc { get; set; }
    string? CreatedBy { get; set; }

    string? LastModifiedBy { get; set; }
}
