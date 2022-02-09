using Common.Domain.Common.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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