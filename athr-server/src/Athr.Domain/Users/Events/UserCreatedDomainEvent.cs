using Athr.Domain.BuildingBlocks;
namespace Athr.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(AccountId UserId) : IDomainEvent
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}
