namespace Common.Domain.Common.Entities;

public abstract record AuditableEntity
{
    public DateTime CreatedOn { get; set; }
    public Guid CreatedById { get; set; }
    public DateTime? EditedOn { get; set; }
    public Guid? EditedById { get; set; }
}