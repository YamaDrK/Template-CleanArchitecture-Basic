using AutoMapper;
using Domain.EntityAbstractions;

namespace Application.Commons.Mappers
{
    public abstract class MapFrom<T> : IMapFrom<T> where T : Entity
    {
        public virtual void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
