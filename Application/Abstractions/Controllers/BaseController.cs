using Microsoft.AspNetCore.Mvc;

namespace Application.Abstractions.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase;
}
