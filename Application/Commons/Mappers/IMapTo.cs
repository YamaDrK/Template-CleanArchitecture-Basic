using AutoMapper;
using Domain.EntityAbstractions;

namespace Application.Commons.Mappers
{
    public interface IMapTo<T> where T : Entity
    {
        void Mapping(Profile proifle);
    }
}
