using Application.Commons;
using Application.DTOs.Users;
using Application.Interfaces.Services;
using Application.Utils;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Abstractions;

namespace WebAPI.Controllers
{
    public class AuthController(IAuthService authService, AppConfiguration configuration) : BaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
            var jwt = await authService.LoginAsync(loginUserDTO);
            return Ok(jwt);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDTO registerUserDTO)
        {
            await authService.RegisterAsync(registerUserDTO);
            return Ok("Register successfully");
        }

        [HttpPost("save-image")]
        public async Task<IActionResult> SaveImage(IFormFile file)
        {
            var image = await ImageUtil.SaveImageAsync(configuration, typeof(Product), file);
            return Ok(image);
        }

        [HttpGet("get-image")]
        public async Task<IActionResult> GetImage(string name)
        {
            var image = await ImageUtil.GetImageAsync(configuration, typeof(Product), name);
            return File(image, "image/jpeg");
        }
    }
}
