using BudgetApi.Models;

namespace BudgetApi.Services
{
    public interface IBudgetService
    {
        Task<List<Budget>> GetAllBudgetAsync();
        Task<Budget> CreateBudgetAsync(Budget budget);
        Task<Budget?> GetBudgetByIdAsync(int id);
        Task<bool> UpdateBudgetAsync(int id, Budget budget);
        Task<bool> DeleteBudgetAsync(int id);
    }
}
