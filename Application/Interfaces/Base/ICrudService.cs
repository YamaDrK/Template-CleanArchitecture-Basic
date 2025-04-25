using Application.Commons.Mappers;
using Domain.EntityAbstractions;

namespace Application.Interfaces.Base
{
    public interface ICrudService<TModel, TCreateDTO, TUpdateDTO, TGetDTO> : IGetService<TModel, TGetDTO>
        where TModel : BaseEntity
        where TCreateDTO : MapTo<TModel>
        where TUpdateDTO : MapTo<TModel>
        where TGetDTO : class
    {
        Task<TGetDTO> CreateAsync(TCreateDTO createDTO);
        Task<TGetDTO> UpdateAsync(int id, TUpdateDTO updateDTO);
        Task DeleteAsync(int id);
    }
}
