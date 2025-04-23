using AutoMapper;

namespace Application.Common.Mappers
{
    public interface IMapTo<T>
    {
        void Mapping(Profile proifle) => proifle.CreateMap(GetType(), typeof(T));   
    }
}
