namespace Application.Interfaces.Base
{
    public interface IGetService<TModel, TGetDTO>
    {
        string[]? Includes { get; set; }

        Task<List<TGetDTO>> GetAllAsync();
        Task<List<TGetDTO>> GetAllWithDeletedAsync();

        Task<TGetDTO?> GetByIdAsync(int id);
    }
}
