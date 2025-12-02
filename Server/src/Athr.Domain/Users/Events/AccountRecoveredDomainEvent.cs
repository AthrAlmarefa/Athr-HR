using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Users.Events
{
    public record AccountRecoveredDomainEvent(AccountId AccountId, string RecoveredByUserId) : IDomainEvent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }
}
