using Common.Application.Articles.Commands.DTOs.Resolvers;
using Common.Application.Common.Mappings;
using Common.Domain.Entities;

namespace Common.Application.Articles.Commands.DTOs;

public class ArticleCreateDTO : MapTo<Article>, IMapTo<Article>
{
    public ArticleCreateDTO()
    {
    }
    
    public ArticleCreateDTO(
        string title, string content, string excerpt, Guid authorId, DateTime releaseDate, string? featuredImageUri, IEnumerable<Guid> categoryIDs)
    {
        (Title, Content, Excerpt, AuthorID, ReleaseDate, FeaturedImageUri, CategoryIDs) =
            (title, content, excerpt, authorId, releaseDate, featuredImageUri, categoryIDs);
    }

    public string Title { get; init; } = string.Empty;
    public string Content { get; init; } = string.Empty;
    public string Excerpt { get; init; } = string.Empty;
    public string? FeaturedImageUri { get; init; }
    public Guid AuthorID { get; init; }
    public DateTime ReleaseDate { get; init; }
    public IEnumerable<Guid> CategoryIDs { get; init; } = Array.Empty<Guid>();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ArticleCreateDTO, Article>()
            .ForMember(dest => dest.Author, opt => opt.MapFrom<AuthorResolver>());
    }
}