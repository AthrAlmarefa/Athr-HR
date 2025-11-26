using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Users.Events
{
    public record AccountDeletedDomainEvent(AccountId AccountId, string DeletedByUserId) : IDomainEvent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;
    }
}
