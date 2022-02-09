using Common.Domain.Common.Entities;

namespace Common.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task PublishAsync(DomainEvent domainEvent);
}