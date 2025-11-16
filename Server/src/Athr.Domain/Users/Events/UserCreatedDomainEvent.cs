

using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Users.Events;

public sealed record UserCreatedDomainEvent : IDomainEvent
{
    public Guid Id { get; init; }
}
