using Application.DTOs.Users;

namespace Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginUserDTO loginUserDTO);
        Task RegisterAsync(RegisterUserDTO registerUserDTO);
    }
}
