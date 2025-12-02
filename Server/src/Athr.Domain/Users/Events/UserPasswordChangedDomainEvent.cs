using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Users.Events
{
    public sealed record UserPasswordChangedDomainEvent(
    AccountId UserId) : IDomainEvent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;
    }
}
