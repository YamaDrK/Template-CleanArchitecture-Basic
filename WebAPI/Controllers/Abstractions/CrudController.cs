using Application.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Abstractions
{
    public abstract class CrudController<TModel, TCreateDTO, TUpdateDTO, TGetDTO>
        (ICrudService<TModel, TCreateDTO, TUpdateDTO, TGetDTO> crudService) 
            : GetController<TModel, TGetDTO>(crudService)
    {
        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync([FromBody] TCreateDTO createDTO)
        {
            return Ok(await crudService.CreateAsync(createDTO));
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] TUpdateDTO updateDTO)
        {
            return Ok(await crudService.UpdateAsync(updateDTO));
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await crudService.DeleteAsync(id);
            return NoContent();
        }
    }
}
