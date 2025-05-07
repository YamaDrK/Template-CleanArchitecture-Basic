using System.ComponentModel.DataAnnotations;
using Domain.EntityAbstractions;
using Domain.Enums;
using Domain.EntityAnnotations;

namespace Domain.Models
{
    public class User : AuditableEntity
    {
        [MessageMaxLength(100)]
        [MessageRequired]
        [EmailAddress(ErrorMessage = "Email must be in correct form")]
        public string Email { get; set; } = string.Empty;

        [MessageRequired]
        public string Password { get; set; } = string.Empty;

        public RoleEnum Role { get; set; } = RoleEnum.User;
    }
}