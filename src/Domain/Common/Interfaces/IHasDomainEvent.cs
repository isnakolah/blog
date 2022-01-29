namespace Domain.Common.Interfaces;

public interface IHasDomainEvent
{
    List<DomainEvent> DomainEvents { get; init; }
}