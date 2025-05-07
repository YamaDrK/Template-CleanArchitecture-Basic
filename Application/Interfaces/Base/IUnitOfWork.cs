using Application.Interfaces.Repositories;
using Domain.EntityAbstractions;

namespace Application.Interfaces.Base
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IGenericRepository<T> Repository<T>(bool isCached = false) where T : Entity;
        Task<int> SaveChangeAsync();
    }
}
