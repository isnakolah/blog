using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AuthorConfigurations : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.Ignore(a => a.DomainEvents);

        builder.HasOne(a => a.Person)
            .WithOne(p => p.Author)
            .HasForeignKey<Person>(p => p.Id);
    }
}