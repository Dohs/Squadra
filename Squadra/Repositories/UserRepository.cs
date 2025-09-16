using Microsoft.EntityFrameworkCore;
using Squadra.Data;
using Squadra.Models;

namespace Squadra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<double> GetAverageRatingAsync(int userId)
        {
            return await _context.Ratings
                .Where(r => r.ParticipantId == userId)
                .AverageAsync(r => (double?)r.Rate) ?? 0;
        }

        public async Task<List<Rating>> GetRatingsForUserAsync(int userId)
        {
            return await _context.Ratings
                .Where(r => r.ParticipantId == userId)
                .ToListAsync();
        }
    }
}