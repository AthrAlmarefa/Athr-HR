using Athr.Domain.BuildingBlocks;
namespace Athr.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(string CreatedById) : IDomainEvent
{
    public Guid Id { get; } = new Guid();
    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;
}
