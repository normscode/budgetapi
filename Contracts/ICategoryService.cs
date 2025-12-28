using BudgetApi.Dto;
using BudgetApi.Models;

namespace BudgetApi.Contracts
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoryAsync();
        Task<CreateCategoryResDto> CreateCategoryAsync(CreateCategoryDto category);
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<bool> UpdateCategoryAsync(int id, Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
