using AutoMapper;
using Common.Application.Articles.Commands.DTOs.Resolvers;
using Common.Application.Common.Mappings;
using Common.Domain.Entities;

namespace Common.Application.Articles.Commands.DTOs;

public class ArticleCreateDTO : MapTo<Article>, IMapTo<Article>
{
    public ArticleCreateDTO(string title, string content, string excerpt, Guid authorId, DateTime releaseDate, string? featuredImageUri)
    {
        (Title, Content, Excerpt, AuthorID, ReleaseDate, FeaturedImageUri) =
            (title, content, excerpt, authorId, releaseDate, featuredImageUri);
    }

    public string Title { get; init; }
    public string Content { get; init; }
    public string Excerpt { get; init; }
    public string? FeaturedImageUri { get; init; }
    public Guid AuthorID { get; init; }
    public DateTime ReleaseDate { get; init; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ArticleCreateDTO, Article>()
            .ForMember(dest => dest.Author, opt => opt.MapFrom<AuthorResolver>());
    }
}