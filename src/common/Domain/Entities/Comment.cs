namespace Domain.Entities;

public sealed record Comment : AuditableEntity
{
    public Guid Id { get; init; }
    public string Text { get; set; } = default!;

    public Person Person { get; set; } = default!;
}