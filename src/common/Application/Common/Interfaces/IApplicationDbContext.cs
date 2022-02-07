using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Person> Persons { get; }
    DbSet<Author> Authors { get; }
    DbSet<Article> Articles { get; }
    DbSet<Category> Categories { get; }
    DbSet<Comment> Comments { get; }
    DbSet<Like> Likes { get; }
    DbSet<Sex> Sexes { get; }
    DbSet<Occupation> Occupations { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}