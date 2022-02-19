using Common.Domain.Entities;

namespace Common.Application.Articles.Commands.DTOs.Resolvers;

public class AuthorResolver : IValueResolver<ArticleCreateDTO, Article, Author>
{
    private readonly IApplicationDbContext _context;

    public AuthorResolver(IApplicationDbContext context)
    {
        _context = context;
    }

    public Author Resolve(ArticleCreateDTO source, Article destination, Author destMember, ResolutionContext context)
    {
        var author = _context.Authors.Find(source.AuthorID);

        author ??= new Author
        {
            Id = Guid.NewGuid(),
            Person = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = $"Sergy {Random.Shared.Next(3000)}",
                LastName = "Campbell",
                ProfilePhotoUri =
                    new Uri(
                        "https://preview.colorlib.com/theme/magdesign/images/xperson_1.jpg.pagespeed.ic.Zebptmx_f8.webp"),
                Occupation = new Occupation
                {
                    Id = Guid.NewGuid(),
                    Name = "CEO and Founder"
                }
            }
        };

        return author;
    }
}