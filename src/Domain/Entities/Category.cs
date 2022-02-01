namespace Domain.Entities;

public record Category : AuditableEntity, IHasDomainEvent
{
    public Guid Id { get; init; }
    public string Name { get; set; } = default!;
    public string Slug => string.Join("-", Name.Split(" ").Select(s => s.ToLower()));

    public ICollection<Article>? Articles { get; set; }
    
    public List<DomainEvent> DomainEvents { get; init; } = default!;
}