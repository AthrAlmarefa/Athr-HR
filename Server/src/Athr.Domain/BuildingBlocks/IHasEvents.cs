namespace Athr.Domain.BuildingBlocks;

public interface IHasEvents
{
    public void ClearDomainEvents();
    public IReadOnlyList<IDomainEvent> GetDomainEvents();
}
