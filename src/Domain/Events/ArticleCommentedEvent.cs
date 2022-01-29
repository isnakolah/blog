namespace Domain.Events;

public record ArticleCommentedEvent(Article Article, Comment Comment) : DomainEvent;
