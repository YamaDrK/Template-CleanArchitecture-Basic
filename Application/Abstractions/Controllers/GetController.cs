using Application.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace Application.Abstractions.Controllers
{
    public abstract class GetController<TModel, TGetDTO>(IGetService<TModel, TGetDTO> getService) : BaseController
    {
        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            return Ok(await getService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            return Ok(await getService.GetByIdAsync(id));
        }
    }
}
