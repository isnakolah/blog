namespace Domain.Events;

public record AuthorCreatedEvent(Author Author) : DomainEvent;