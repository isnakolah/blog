using Common.Domain.Common.Entities;

namespace Common.Application.Common.Models;

public sealed class DomainEventNotification<TDomainEvent> : INotification 
    where TDomainEvent : DomainEvent 
{
    public DomainEventNotification(TDomainEvent domainEvent)
    {
        DomainEvent = domainEvent;
    }

    public TDomainEvent DomainEvent { get; }
}