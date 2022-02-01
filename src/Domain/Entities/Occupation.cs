namespace Domain.Entities;

public record Occupation
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;

    public ICollection<Person> Persons { get; set; } = default!;
}