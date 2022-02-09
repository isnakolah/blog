namespace Common.Domain.Events;

public record ArticleLikedEvent(Article Article, Like Like) : DomainEvent;