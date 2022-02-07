namespace Domain.Entities;

public sealed record Like : AuditableEntity
{
    public Guid Id { get; init; }

    public Article Article { get; set; } = default!;
    public Person Person { get; set; } = default!;
}