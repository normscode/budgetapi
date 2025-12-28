using BudgetApi.Models;

namespace BudgetApi.Contracts
{
    public interface IUserService
    {
        Task<List<User>> GetAllUserAsync();
        Task<User> CreateUserAsync(User user);
        Task<User?> GetUserByIdAsync(int id);
        Task<bool> UpdateUserAsync(int id, User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
