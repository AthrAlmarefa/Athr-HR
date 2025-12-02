namespace Athr.Domain.BuildingBlocks;

public interface IAuditableEntity
{
    DateTime CreatedAtUtc { get; set; }
    DateTime? LastModifiedAtUtc { get; set; }
    string? CreatedBy { get; set; }

    string? LastModifiedBy { get; set; }
}
