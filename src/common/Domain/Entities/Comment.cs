using Common.Domain.Events;

namespace Common.Domain.Entities;

public sealed record Comment : AuditableEntity, IHasDomainEvent
{
    public Guid Id { get; init; }
    public string Text { get; set; } = default!;
    public bool Disabled { get; private set; }

    public Article Article { get; set; } = default!;
    public Person Person { get; set; } = default!;

    public List<DomainEvent> DomainEvents { get; init; } = default!;

    public void Disable()
    {
        Disabled = true;

        DomainEvents.Add(new CommentDisabledEvent(this));
    }

}