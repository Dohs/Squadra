using Microsoft.EntityFrameworkCore;
using Squadra.Data;
using Squadra.Models;

namespace Squadra.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _context;

        public RatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Rating rating)
        {
            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Rating>> GetByMatchIdAsync(int matchId)
        {
            return await _context.Ratings
                .Include(r => r.Reviewer)
                .Include(r => r.Participant)
                .Where(r => r.MatchId == matchId)
                .ToListAsync();
        }
    }
}