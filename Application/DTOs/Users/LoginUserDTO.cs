using Application.Common.Mappers;
using Domain.Models;

namespace Application.DTOs.Users
{
    public class LoginUserDTO : IMapTo<User>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
