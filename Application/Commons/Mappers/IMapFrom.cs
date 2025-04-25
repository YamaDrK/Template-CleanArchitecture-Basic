using AutoMapper;
using Domain.EntityAbstractions;

namespace Application.Commons.Mappers
{
    public interface IMapFrom<T> where T : Entity
    {
        void Mapping(Profile profile);
    }
}
