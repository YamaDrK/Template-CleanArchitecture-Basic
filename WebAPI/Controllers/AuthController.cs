using Application.DTOs.Users;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Abstractions;

namespace WebAPI.Controllers
{
    public class AuthController(IAuthService authService) : BaseController
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
    }
}
