using Application.Interfaces.Base;
using AutoMapper;
using Domain.EntityAbstractions;

namespace Infrastructure.Implements.Base
{
    public class GetService<TModel, TGetDTO>(IUnitOfWork _unitOfWork,
        IMapper _mapper,
        string[]? includes = null,
        bool isCached = false)
/* extend */ : IGetService<TModel, TGetDTO>
                where TModel : BaseEntity
                where TGetDTO : class
    {
        public virtual async Task<List<TGetDTO>> GetAllAsync()
        {
            var entities = await _unitOfWork.Repository<TModel>(isCached).GetAllAsync(includes);
            return _mapper.Map<List<TGetDTO>>(entities);
        }

        public virtual async Task<List<TGetDTO>> GetAllWithDeletedAsync()
        {
            var entities = await _unitOfWork.Repository<TModel>(isCached).GetAllWithDeletedAsync(includes);
            return _mapper.Map<List<TGetDTO>>(entities);
        }

        public virtual async Task<TGetDTO?> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.Repository<TModel>().GetByIdAsync(id, includes);
            return entity != null ? _mapper.Map<TModel, TGetDTO>(entity) : null;
        }
    }
}
