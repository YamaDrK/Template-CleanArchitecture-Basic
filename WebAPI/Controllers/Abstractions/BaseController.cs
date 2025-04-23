using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Abstractions
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase;
}
