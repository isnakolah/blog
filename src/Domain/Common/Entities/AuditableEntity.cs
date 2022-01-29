using Domain.Entities;

namespace Domain.Common.Entities;

public abstract record AuditableEntity
{
    public DateTime CreatedOn { get; set; }
    public Person CreatedBy { get; set; } = default!;
    public DateTime? EditedOn { get; set; }
    public Person? EditedBy { get; set; }
}