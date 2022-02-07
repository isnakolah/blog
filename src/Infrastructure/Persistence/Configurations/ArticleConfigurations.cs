using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ArticleConfigurations : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.Ignore(a => a.DomainEvents);

        builder.HasMany(a => a.Categories)
            .WithMany(c => c.Articles);

        builder.HasIndex(a => a.Title)
            .IsUnique()
            .HasFilter(null);
    }
}