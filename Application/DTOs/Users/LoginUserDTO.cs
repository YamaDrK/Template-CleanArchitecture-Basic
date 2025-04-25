using Application.Commons.Mappers;
using Domain.Models;

namespace Application.DTOs.Users
{
    public class LoginUserDTO : MapTo<User>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
