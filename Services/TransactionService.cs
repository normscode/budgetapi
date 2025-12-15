using BudgetApi.Data;
using BudgetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApi.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetAllTransactionAsync()
           => await _context.Transactions.ToListAsync();

        public async Task<Transaction?> GetTransactionByIdAsync(int id)
        {
            var existingTrx = await _context.Transactions.FindAsync(id);

            return existingTrx;
        }

        public async Task<Transaction> CreateTransactionAsync(Transaction transaction)
        {
            await _context.AddAsync(transaction);
            await _context.SaveChangesAsync();

            return transaction;
        }

        public async Task<bool> UpdateTransactionAsync(int id, Transaction transaction)
        {
            var existingTrx = await _context.Transactions.FindAsync(id);
            if (existingTrx == null)
            {
                return false;
            }
            existingTrx.Note = transaction.Note;
            existingTrx.Amount = transaction.Amount;
            existingTrx.Category = transaction.Category;
            existingTrx.TransactionDate = transaction.TransactionDate;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTransactionAsync(int id)
        {
            var existingTrx = await _context.Transactions.FindAsync(id);
            if (existingTrx == null)
            {
                return false;
            }
            _context.Transactions.Remove(existingTrx);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
