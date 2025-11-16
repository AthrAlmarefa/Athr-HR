using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.BusinessRoles.Events;

public sealed class PartnerAddedDomainEvent : IDomainEvent
{
    public PartnerAddedDomainEvent(Guid partnerId)
    {
        PartnerId = partnerId;
    }

    public PartnerAddedDomainEvent()
    {
    }
    public Guid PartnerId { get; set; }
}
