using BudgetApi.Models;

namespace BudgetApi.Services
{
    public interface ICategoryService
    {
        Task<Category> GetAllCategoryAsync();
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> GetCategoryByIdAsync(int id);
        Task<bool> UpdateCategoryAsync(int id, Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
