using Common.Domain.Events;

namespace Common.Domain.Entities;

public sealed record Author : AuditableEntity, IHasDomainEvent
{
    public Guid Id { get; init; }
    public bool IsActivated { get; private set; }
    
    public Person Person { get; set; } = default!;
    public ICollection<Article>? Articles { get; set; }

    public List<DomainEvent> DomainEvents { get; init; } = default!;

    public void Activate()
    {
        IsActivated = true;

        DomainEvents.Add(new AuthorCreatedEvent(this));
    }
}