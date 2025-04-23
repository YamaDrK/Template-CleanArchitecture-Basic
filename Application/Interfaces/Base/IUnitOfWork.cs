namespace Application.Interfaces.Base
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>();
        Task<int> SaveChangeAsync();
    }
}
