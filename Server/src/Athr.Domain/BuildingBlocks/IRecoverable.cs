namespace Athr.Domain.BuildingBlocks;

public interface IRecoverable
{
    public bool IsDeleted { get; }
    public DateTimeOffset? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
