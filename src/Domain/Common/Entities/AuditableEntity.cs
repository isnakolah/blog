using Domain.Entities;

namespace Domain.Common.Entities;

public abstract record AuditableEntity
{
    public DateTime CreatedOn { get; set; }
    public Guid CreatedById { get; set; } = default!;
    public DateTime? EditedOn { get; set; }
    public Guid? EditedById { get; set; }
}