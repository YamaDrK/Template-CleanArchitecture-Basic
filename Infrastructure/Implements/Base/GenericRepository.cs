using Application.Interfaces.Base;
using Domain.EntityAbstractions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implements.Base
{
    public class GenericRepository<T>(ApplicationDbContext _dbContext) : IGenericRepository<T> where T : Entity
    {
        public virtual async Task<List<T>> GetAllAsync(string[]? includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return typeof(AuditableEntity).IsAssignableFrom(typeof(T))
                ? await query.AsNoTracking().Where(entity => !(entity as AuditableEntity)!.IsDeleted).ToListAsync()
                : await query.AsNoTracking().ToListAsync();
        }

        public virtual async Task<List<T>> GetAllWithDeletedAsync(string[]? includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id, string[]? includes = null)
        {
            if (!typeof(BaseEntity).IsAssignableFrom(typeof(T)))
            {
                return null;
            }

            IQueryable<T> query = _dbContext.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            var entity = await query.FirstOrDefaultAsync(entity => (entity as BaseEntity)!.Id == id);
            if (entity is AuditableEntity auditEntity && auditEntity.IsDeleted)
            {
                return null;
            }

            return entity;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            if (entity is AuditableEntity auditableEntity)
            {
                auditableEntity.SetAuditableProperties();
            }

            var result = await _dbContext.Set<T>().AddAsync(entity);
            return result.Entity;
        }

        public virtual async Task AddRangeAsync(List<T> entities)
        {
            if (typeof(AuditableEntity).IsAssignableFrom(typeof(T)))
            {
                foreach (var entity in entities.Cast<AuditableEntity>())
                {
                    entity.SetAuditableProperties();
                }
            }
            
            await _dbContext.Set<T>().AddRangeAsync(entities);
        }

        public virtual void Remove(T entity)
        {
            if (entity is AuditableEntity auditableEntity)
            {
                auditableEntity.DeleteEntity();
                _dbContext.Set<T>().Update(entity);
            }
            else
            {
                _dbContext.Set<T>().Remove(entity);
            }
        }

        public virtual T Update(T entity)
        {
            if (entity is AuditableEntity auditableEntity)
            {
                auditableEntity.UpdateAuditableProperties();
            }

            var result = _dbContext.Set<T>().Update(entity);
            return result.Entity;
        }

        public virtual void UpdateRange(List<T> entities)
        {
            if (typeof(AuditableEntity).IsAssignableFrom(typeof(T)))
            {
                foreach (var entity in entities.Cast<AuditableEntity>())
                {
                    entity.UpdateAuditableProperties();
                }
            }

            _dbContext.Set<T>().UpdateRange(entities);
        }
    }
}
