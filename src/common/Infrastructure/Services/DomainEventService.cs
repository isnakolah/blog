using Application.Common.Models;
using Domain.Common.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services;

public class DomainEventService : IDomainEventService
{
    private readonly ILogger<DomainEventService> _logger;
    private readonly IPublisher _mediator;

    public DomainEventService(ILogger<DomainEventService> logger, IPublisher mediator)
    {
        (_logger, _mediator) = (logger, mediator);
    }

    public async Task PublishAsync(DomainEvent domainEvent)
    {
        _logger.LogInformation("Publishing domain event. Event - {Event}", domainEvent.GetType().Name);

        await _mediator.Publish(GetNotificationCorrespondingEvent(domainEvent));
    }

    private static INotification GetNotificationCorrespondingEvent(DomainEvent domainEvent)
    {
        return (INotification) Activator.CreateInstance(
            typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent)!;
    }
}