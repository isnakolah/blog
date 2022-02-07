namespace Domain.Common.Entities;

public abstract record DomainEvent
{
    protected DomainEvent()
    {
        DateOccurred = DateTimeOffset.UtcNow;
    }

    public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;
    public bool IsPublished { get; set; }
}