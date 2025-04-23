using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository 
    {
        Task<bool> IsEmailExistAsync(string email);
        Task<User> GetByEmailAsync(string email);
    }
}
