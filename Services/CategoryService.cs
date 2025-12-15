using BudgetApi.Data;
using BudgetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await  _context.SaveChangesAsync();

            return category;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var existingCategory = await _context.Categories.FindAsync(id);
            if(existingCategory == null)
            {
                return false;
            }
            _context.Categories.Remove(existingCategory);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Category>> GetAllCategoryAsync()
            => await _context.Categories.ToListAsync();

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            var existingCategory =  await _context.Categories.FindAsync(id);

            return existingCategory;
        }

        public async Task<bool> UpdateCategoryAsync(int id, Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(id);
            if(existingCategory == null)
            {
                return false;
            }
            existingCategory.Name = category.Name;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
