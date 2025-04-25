using System.Reflection;
using AutoMapper;

namespace Application.Commons.Mappers
{
    public class MapperConfigProfile : Profile
    {
        public MapperConfigProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType
                    && (i.GetGenericTypeDefinition() == typeof(IMapFrom<>)
                    || i.GetGenericTypeDefinition() == typeof(IMapTo<>))
                ))
                .Where(t => t.Name != typeof(MapFrom<>).Name && t.Name != typeof(MapTo<>).Name)
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, [this]);
            }
        }
    }
}
