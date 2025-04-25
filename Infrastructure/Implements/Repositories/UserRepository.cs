using Application.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Implements.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implements.Repositories
{
    public class UserRepository(ApplicationDbContext _dbContext) : GenericRepository<User>(_dbContext), IUserRepository
    {
        public async Task<bool> IsEmailExistAsync(string email)
        {
            return await _dbContext.User.AnyAsync(u => u.Email == email);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.User.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
    