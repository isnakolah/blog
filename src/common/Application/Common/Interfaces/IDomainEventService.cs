using Domain.Common.Entities;

namespace Application.Common.Interfaces;

public interface IDomainEventService
{
    Task PublishAsync(DomainEvent domainEvent);
}