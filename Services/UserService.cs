using BudgetApi.Contracts;
using BudgetApi.Data;
using BudgetApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BudgetApi.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUserAsync()
          => await _context.Users.ToListAsync();

        public async Task<User?> GetUserByIdAsync(int id)
        {
           var user = await _context.Users.FindAsync(id);

           return user;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {   
            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser == null)
            {
                return false;
            }

            _context.Users.Remove(existingUser);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateUserAsync(int id, User user)
        {
            var existingUser =  await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return false;
            }

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.PasswordHash = user.PasswordHash;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
