using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Users.Events
{
    public record AccountActivatedDomainEvent(AccountId AccountId, string ActivatedByUserId) : IDomainEvent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;

    }
}
