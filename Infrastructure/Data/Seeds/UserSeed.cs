using Domain.Models;
using Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Application.Utils;

namespace Infrastructure.Data.Seeds
{
    public static class UserSeed
    {
        public static DataBuilder GenarateUserSeed(this EntityTypeBuilder entity)
        {
            User[] userSeed = [
                new User { Id = 1, Email = "Admin@Admin.com", Password = "$2a$12$4TyVGg5hnrJ13TQXxKj4WeFMePdYIDWQZ1SALrKYcW2UiUGBMLnyy", Role = RoleEnum.Admin, CreationDate = new DateTime(2004, 10, 30)},
                new User { Id = 2, Email = "User1@User.com", Password = "$2a$12$4TyVGg5hnrJ13TQXxKj4WeFMePdYIDWQZ1SALrKYcW2UiUGBMLnyy", Role = RoleEnum.User, CreationDate = new DateTime(2025, 04, 22)},
                new User { Id = 3, Email = "User2@User.com", Password = "$2a$12$4TyVGg5hnrJ13TQXxKj4WeFMePdYIDWQZ1SALrKYcW2UiUGBMLnyy", Role = RoleEnum.User, CreationDate = new DateTime(2025, 04, 22)},
                new User { Id = 4, Email = "User3@User.com", Password = "$2a$12$4TyVGg5hnrJ13TQXxKj4WeFMePdYIDWQZ1SALrKYcW2UiUGBMLnyy", Role = RoleEnum.User, CreationDate = new DateTime(2025, 04, 22)},
            ];
            return entity.HasData(userSeed);
        }
    }
}
