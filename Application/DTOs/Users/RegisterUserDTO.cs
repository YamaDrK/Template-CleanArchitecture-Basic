using Application.Commons.Mappers;
using Domain.Models;

namespace Application.DTOs.Users
{
    public class RegisterUserDTO : MapTo<User>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
