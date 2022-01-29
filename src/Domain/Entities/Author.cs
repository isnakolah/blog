using Domain.Events;

namespace Domain.Entities;

public sealed record Author : AuditableEntity, IHasDomainEvent
{
    public Guid Id { get; init; }
    public bool IsActive { get; private set; }
    
    public Person Person { get; set; } = default!;
    public ICollection<Article>? Articles { get; set; }

    public List<DomainEvent> DomainEvents { get; init; } = default!;

    public void Activate()
    {
        IsActive = true;
        DomainEvents.Add(new AuthorCreatedEvent(this));
    }
}