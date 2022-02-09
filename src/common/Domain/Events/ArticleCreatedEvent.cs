namespace Common.Domain.Events;

public record ArticleCreatedEvent(Article Article) : DomainEvent;