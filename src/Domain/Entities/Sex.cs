namespace Domain.Entities;

public sealed record Sex
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<Person> Persons { get; set; }
}