using AutoMapper;
using Common.Application.Common.Mappings;
using Common.Domain.Entities;

namespace Common.Application.Categories.Queries.DTOs;

public record CategoryGetDTO : IMapFrom<Category>
{
    public string Name { get; init; } = string.Empty;

    public string Slug { get; init; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Category, CategoryGetDTO>()
            .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => string.Join("-", src.Name.ToLower().Split(" ", StringSplitOptions.TrimEntries))));
    }
}