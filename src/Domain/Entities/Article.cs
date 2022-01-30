namespace Domain.Entities;

public sealed record Article : AuditableEntity, IHasDomainEvent
{
    public Guid Id { get; init; }
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string Excerpt { get; set; } = default!;
    public DateTime ReleaseDate { get; set; }

    public Author Author { get; set; } = default!;
    public ICollection<Like> Likes { get; set; } = default!;

    public List<DomainEvent> DomainEvents { get; init; } = default!;
}