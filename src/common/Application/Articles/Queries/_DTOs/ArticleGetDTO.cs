using AutoMapper;
using Common.Application.Authors.Queries.DTOs;
using Common.Application.Categories.Queries.DTOs;
using Common.Application.Common;
using Common.Application.Common.Mappings;
using Common.Domain.Entities;

namespace Common.Application.Articles.Queries.DTOs;

public record ArticleGetDTO : IMapFrom<Article>
{
    public string Title { get; set; } = string.Empty;
    public string Slug { get; init; } = string.Empty;
    public string Content { get; init; } = string.Empty;
    public string Excerpt { get; init; } = string.Empty;
    public string? FeaturedImageUri { get; init; }
    public string ReleaseDate { get; init; } = string.Empty;
    public DateTime CreatedOn { get; init; }
    public AuthorGetDTO Author { get; init; } = new();
    public IEnumerable<CategoryGetDTO>? Categories { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Article, ArticleGetDTO>()
            .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate.ToShortDateString()))
            .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => src.Title.CreateSlug()));
    }
}
