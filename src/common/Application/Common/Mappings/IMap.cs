using AutoMapper;

namespace Common.Application.Common.Mappings;

public interface IMapFrom<in T> where T : class
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}

public interface IMapTo<out T> where T : class
{
    void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));

    T MapToEntity(IMapper mapper)
    {
        return mapper.Map<T>(this);
    }
}