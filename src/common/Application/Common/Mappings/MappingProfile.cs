using System.Reflection;

namespace Common.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i =>
            i.IsGenericType && (i.GetGenericTypeDefinition() == typeof(IMapFrom<>) || i.GetGenericTypeDefinition() == typeof(IMapTo<>))));

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var iMapMethodInfo = type.GetMethod("Mapping") 
                 ?? type.GetInterface("IMapFrom`1")?.GetMethod("Mapping")
                 ?? type.GetInterface("IMapTo`1")?.GetMethod("Mapping");

            iMapMethodInfo?.Invoke(instance, new object?[] { this });
        }
    }
}