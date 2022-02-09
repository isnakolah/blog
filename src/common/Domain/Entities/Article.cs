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
    public ICollection<Like> Likes { get; set; } = default!;
    public ICollection<Category> Categories { get; set; } = default!;

    public List<DomainEvent> DomainEvents { get; init; } = default!;
}