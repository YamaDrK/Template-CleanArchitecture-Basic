using Domain.EntityAbstractions;

namespace Application.Interfaces.Base
{
    public interface IGetService<TModel, TGetDTO>
        where TModel : BaseEntity
        where TGetDTO : class
    {
        Task<List<TGetDTO>> GetAllAsync();
        Task<List<TGetDTO>> GetAllWithDeletedAsync();

        Task<TGetDTO?> GetByIdAsync(int id);
    }
}
