using Common.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PersonConfigurations : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Ignore(x => x.DomainEvents);

        builder.Property(p => p.OtherNames)
            .HasConversion(otherNames => string.Join(" ", otherNames ?? Array.Empty<string>()), otherNamesRaw => otherNamesRaw.Split(" ", StringSplitOptions.None).AsEnumerable());
    }
}