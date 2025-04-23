using Application.Common.Mappers;
using Domain.Models;

namespace Application.DTOs.Users
{
    public class RegisterUserDTO : IMapTo<User>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
