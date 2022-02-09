namespace Common.Domain.Events;

public record PersonCreatedEvent(Person Person) : DomainEvent;