namespace Domain.Entities;

public sealed record Person : AuditableEntity, IHasDomainEvent
{
    public Guid Id { get; init; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? OtherNames { get; set; }

    public ICollection<Like>? Likes { get; set; }
    public ICollection<Comment>? Comments { get; set; }

    public List<DomainEvent> DomainEvents { get; init; } = default!;
}