using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Abstractions
{
    public abstract class GetController : BaseController
    {
        [HttpGet]
        public abstract Task<IActionResult> GetAll();

        [HttpGet("{id}")]
        public abstract Task<IActionResult> GetById([FromRoute] int id);
    }
}
