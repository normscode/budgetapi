using BudgetApi.Data;
using BudgetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApi.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly AppDbContext _context;

        public BudgetService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Budget> CreateBudgetAsync(Budget budget)
        {
            await _context.Budgets.AddAsync(budget);
            await _context.SaveChangesAsync();

            return budget;
        }

        public async Task<List<Budget>> GetAllBudgetAsync()
         => await _context.Budgets.ToListAsync();  

        public async Task<Budget?> GetBudgetByIdAsync(int id)
        {
            var existingBudget = await _context.Budgets.FindAsync(id);
            if(existingBudget == null)
            {
                return null;
            }
            return existingBudget;
        }

        public async Task<bool> UpdateBudgetAsync(int id, Budget budget)
        {
            var existingBudget = await _context.Budgets.FindAsync(id);
            if(existingBudget == null)
            {
                return false;
            }
            existingBudget.Month = budget.Month;
            existingBudget.Year = budget.Year;
            existingBudget.Amount = budget.Amount;

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteBudgetAsync(int id)
        {
            var existingBudget = await _context.Budgets.FindAsync(id);
            if (existingBudget == null)
            {
                return false;
            }
            _context.Budgets.Remove(existingBudget);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
