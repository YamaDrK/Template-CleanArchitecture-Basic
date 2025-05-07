using Application.Interfaces.Base;
using Application.Interfaces.Services;
using Domain.EntityAbstractions;
using Infrastructure.Data;
using Microsoft.Extensions.Caching.Distributed;

namespace Infrastructure.Implements.Base
{
    public class UnitOfWork(ApplicationDbContext dbContext,
        IDistributedCache cache,
        ICurrentUserService currentUserService)
            : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        private readonly IDistributedCache _cache = cache;
        private readonly Dictionary<Type, dynamic> _repositories = [];

        public IGenericRepository<T> Repository<T>(bool isCached = false) where T : Entity
        {
            var entityType = typeof(T);
            if (_repositories.TryGetValue(entityType, out dynamic? repository))
            {
                return repository;
            }

            var newRepository = isCached
                ? Activator.CreateInstance(typeof(CachedRepository<>).MakeGenericType(typeof(T)), _dbContext, _cache)
                : Activator.CreateInstance(typeof(GenericRepository<>).MakeGenericType(typeof(T)), _dbContext);

            if (newRepository == null)
                throw new NullReferenceException("Repository should not be null");

            _repositories.Add(entityType, newRepository);

            return (IGenericRepository<T>)newRepository;
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync(currentUserService.UserId != 0
                ? currentUserService.UserId.ToString()
                : null);
        }
    }
}
