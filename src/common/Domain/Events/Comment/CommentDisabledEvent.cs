namespace Common.Domain.Events;

public record CommentDisabledEvent(Comment Comment) : DomainEvent;
