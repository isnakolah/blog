namespace Common.Domain.Events;

public record ArticleAddedToCategoryEvent(Category Category, Article Article) : DomainEvent;
