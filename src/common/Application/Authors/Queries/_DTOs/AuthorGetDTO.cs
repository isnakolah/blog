using AutoMapper;
using Common.Application.Common.Mappings;
using Common.Domain.Entities;

namespace Common.Application.Authors.Queries.DTOs;

public record AuthorGetDTO : IMapFrom<Author>
{
    public bool IsActivated { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string? OtherNames { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string ProfilePhotoUrl { get; init; } = string.Empty;
    public string OccupationName { get; init; } = string.Empty;
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Author, AuthorGetDTO>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Person.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Person.LastName))
            .ForMember(dest => dest.OtherNames, opt => opt.MapFrom(src => string.Join(" ", src.Person.OtherNames ?? Array.Empty<string>())))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Person.FirstName} {src.Person.LastName}"))
            .ForMember(dest => dest.ProfilePhotoUrl, opt => opt.MapFrom(src => src.Person.ProfilePhotoUri != null ? src.Person.ProfilePhotoUri.ToString() : string.Empty))
            .ForMember(dest => dest.OccupationName, opt => opt.MapFrom(src => src.Person.Occupation != null ? src.Person.Occupation.Name : string.Empty));
    }
}