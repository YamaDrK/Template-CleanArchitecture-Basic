using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Abstractions
{
    public abstract class CrudController<TCreateDTO, TUpdateDTO> : GetController
    {
        [HttpPost]
        public abstract Task<IActionResult> Create([FromBody] TCreateDTO createDTO);

        [HttpPut("{id}")]
        public abstract Task<IActionResult> Update([FromRoute] int id, [FromBody] TUpdateDTO updateDTO);

        [HttpDelete("{id}")]
        public abstract Task<IActionResult> Delete([FromRoute] int id);
    }
}
