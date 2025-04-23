namespace Application.Interfaces.Base
{
    public interface ICrudService<TModel, TCreateDTO, TUpdateDTO, TGetDTO> : IGetService<TModel, TGetDTO>
    {
        Task<TModel> CreateAsync(TCreateDTO createDTO);
        Task<TModel> UpdateAsync(TUpdateDTO updateDTO);
        Task DeleteAsync(int id);
    }
}
