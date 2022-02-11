using Common.Domain.Events;

namespace Common.Domain.Entities;

public sealed record Article : AuditableEntity, IHasDomainEvent
{
    public Guid Id { get; init; }
    public string Title { get; set; } = default!;
    public string Slug => string.Join("-", Title.Split(" ").Select(s => s.ToLower()));
    public string Content { get; set; } = default!;
    public string Excerpt { get; set; } = default!;
    public Uri? FeaturedImageUri { get; set; }
    public DateTime ReleaseDate { get; set; }

    public Author Author { get; set; } = default!;
    public ICollection<Like> Likes { get; private set; } = new List<Like>();
    public ICollection<Category> Categories { get; private set; } = new List<Category>();
    public ICollection<Comment>? Comments { get; private set; } 

    public List<DomainEvent> DomainEvents { get; init; } = new();

    public void AddComment(Comment comment)
    {
        Comments ??= new List<Comment>();

        Comments.Add(comment);

        DomainEvents.Add(new ArticleCommentedEvent(this, comment));
    }

    public void AddLike(Like like)
    {
        Likes.Add(like);

        DomainEvents.Add(new ArticleLikedEvent(this, like));
    }

    public void AddCategory(Category category)
    {
        category.DomainEvents.Add(new ArticleAddedToCategoryEvent(category, this));
        
        Categories.Add(category);
    }
}