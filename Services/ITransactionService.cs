using BudgetApi.Models;

namespace BudgetApi.Services
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetAllTransactionAsync();
        Task<Transaction> CreateTransactionAsync(Transaction transaction);
        Task<Transaction?> GetTransactionByIdAsync(int id);
        Task<bool> UpdateTransactionAsync(int id, Transaction transaction);
        Task<bool> DeleteTransactionAsync(int id);
    }
}
