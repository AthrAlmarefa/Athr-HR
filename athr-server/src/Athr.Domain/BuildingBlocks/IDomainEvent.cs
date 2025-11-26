using MediatR;

namespace Athr.Domain.BuildingBlocks;

public interface IDomainEvent : INotification
{
    public Guid Id { get; }
    public DateTimeOffset OccurredOn { get; }
}
