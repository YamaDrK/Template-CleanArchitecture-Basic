using AutoMapper;
using Domain.EntityAbstractions;

namespace Application.Commons.Mappers
{
    public abstract class MapTo<T> : IMapTo<T> where T : Entity
    {
        public virtual void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
    }
}
