using Application.DTOs.Users;
using Application.Interfaces.Services;

namespace Infrastructure.Implements.Services
{
    public class AuthService : IAuthService
    {
        public async Task<string> LoginAsync(LoginUserDTO loginUserDTO)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(RegisterUserDTO registerUserDTO)
        {
            throw new NotImplementedException();
        }
    }
}
