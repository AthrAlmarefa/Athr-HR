using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athr.Domain.BuildingBlocks;
using Athr.Domain.Users.Authorization;

namespace Athr.Domain.Users.Events
{
    public sealed record UserPermissionAssignedDomainEvent(
    AccountId UserId,
    BusinessRolesPermission Permission) : IDomainEvent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;
    }
}
