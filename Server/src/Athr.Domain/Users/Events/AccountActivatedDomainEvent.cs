using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Users.Events
{
    public record AccountActivatedDomainEvent(AccountId AccountId) : IDomainEvent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

    }
}
