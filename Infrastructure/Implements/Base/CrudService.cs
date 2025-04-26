using Application.Commons.Exceptions;
using Application.Commons.Mappers;
using Application.Interfaces.Base;
using Application.Utils;
using AutoMapper;
using Domain.EntityAbstractions;

namespace Infrastructure.Implements.Base
{
    public class CrudService<TModel, TCreateDTO, TUpdateDTO, TGetDTO>(
        IUnitOfWork _unitOfWork,
        IMapper _mapper,
        string[]? includes = null,
        bool isCached = false)
/* extend */ : GetService<TModel, TGetDTO>(_unitOfWork, _mapper, includes, isCached),
                ICrudService<TModel, TCreateDTO, TUpdateDTO, TGetDTO>
                    where TModel : BaseEntity
                    where TCreateDTO : MapTo<TModel>
                    where TUpdateDTO : MapTo<TModel>
                    where TGetDTO : class
    {
        public virtual async Task<TGetDTO> CreateAsync(TCreateDTO createDTO)
        {
            var entity = _mapper.Map<TModel>(createDTO);
            entity.TryValidate();

            var resultEntity = await _unitOfWork.Repository<TModel>().AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<TGetDTO>(resultEntity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.Repository<TModel>().GetByIdAsync(id)
                ?? throw new DataNotFoundException(typeof(TModel), id);

            _unitOfWork.Repository<TModel>().Remove(entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public virtual async Task<TGetDTO> UpdateAsync(int id, TUpdateDTO updateDTO)
        {
            var entity = await _unitOfWork.Repository<TModel>().GetByIdAsync(id)
                ?? throw new DataNotFoundException(typeof(TModel), id);

            var updatedEntity = _mapper.Map(updateDTO, entity);
            updatedEntity.TryValidate();

            var resultEntity = _unitOfWork.Repository<TModel>().Update(updatedEntity);
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<TGetDTO>(resultEntity);
        }
    }
}
