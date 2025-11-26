using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Users.Events
{
    public record AccountDeactivatedDomainEvent(AccountId AccountId, string DeactivatedByUserId) : IDomainEvent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;
    }
}
