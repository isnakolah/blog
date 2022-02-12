using Common.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence;

public static class ApplicationDbContextSeed
{
    public static void AddDatabaseSeed(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();

        var serviceProvider = scope.ServiceProvider;

        try
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            SeedArticlesAsync(context).GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            var logger = serviceProvider.GetRequiredService<ILogger<ApplicationDbContext>>();
            
            logger.LogError(ex, "An error occurred while seeding the database");

            throw;
        }
    }

    private static async Task SeedArticlesAsync(ApplicationDbContext context)
    {
        context.Articles.AddRange(Enumerable.Range(0, 6).Select(_ =>
        {
            var article =  new Article
            {
                Id = Guid.NewGuid(),
                Title = "Your most unhappy customers are your greatest source of learning.",
                Excerpt = "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts.",
                FeaturedImageUri = new Uri("https://preview.colorlib.com/theme/magdesign/images/ximg_2.jpg.pagespeed.ic.fbbBEgB1Q6.webp"),
                Content = "This is dope",
                Author = new Author
                {
                    Id = Guid.NewGuid(),
                    Person = new Person
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Sergy",
                        LastName = "Campbell",
                        Occupation = new Occupation
                        {
                            Id = Guid.NewGuid(),
                            Name = "CEO and Founder"
                        }
                    }
                },
                CreatedOn = DateTime.Now
            };

            article.AddCategory(new Category {Id = Guid.NewGuid(), Name = "Business"});
            article.AddCategory(new Category {Id = Guid.NewGuid(), Name = "Travel"});

            return article;
        }));

        await context.SaveChangesAsync();
    }
}