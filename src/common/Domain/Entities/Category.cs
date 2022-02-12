namespace Common.Domain.Entities;

public record Category : AuditableEntity, IHasDomainEvent
{
    public Guid Id { get; init; }
    public string Name { get; set; } = default!;
    public ICollection<Article>? Articles { get; set; }

    public List<DomainEvent> DomainEvents { get; init; } = new();
}