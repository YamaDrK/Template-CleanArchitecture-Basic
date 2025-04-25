using Domain.EntityAbstractions;

namespace Application.Interfaces.Base
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>(bool isCached = false) where T : Entity;
        Task<int> SaveChangeAsync();
    }
}
