using Application.Commons;
using Application.Utils;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Abstractions;

namespace WebAPI.Controllers
{
    public class ImageController(AppConfiguration _configuration) : BaseController
    {
        [HttpPost("save-image")]
        public async Task<IActionResult> SaveImage(IFormFile file)
        {
            var image = await ImageUtil.SaveImageAsync(_configuration, typeof(Test), file);
            return Ok(image);
        }

        [HttpGet("get-image")]
        public async Task<IActionResult> GetImage(string name)
        {
            var image = await ImageUtil.GetImageAsync(_configuration, typeof(Test), name);
            return Ok(image);
        }

        [HttpDelete("delete-image")]
        public async Task<IActionResult> DeleteImage(string name)
        {
            var result = await ImageUtil.DeleteImageAsync(_configuration, typeof(Test), name);
            return Ok(result ? "Successfully" : "Failed");
        }
    }

    class Test;
}
