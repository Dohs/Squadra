using Microsoft.EntityFrameworkCore;
using Squadra.Data;
using Squadra.Models;

namespace Squadra.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly ApplicationDbContext _context;

        public MatchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Match match)
        {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
        }

        public async Task<Match> GetByIdAsync(int id)
        {
            return await _context.Matches
                .Include(m => m.Sport)
                .Include(m => m.Creator)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Match>> GetAllAsync(string sport = null, string ville = null, DateTime? date = null)
        {
            var query = _context.Matches
                .Include(m => m.Sport)
                .Include(m => m.Creator)
                .AsQueryable();

            if (!string.IsNullOrEmpty(sport))
            {
                query = query.Where(m => m.Sport.Nom.Contains(sport));
            }

            if (!string.IsNullOrEmpty(ville))
            {
                query = query.Where(m => m.Lieu.Contains(ville));
            }

            if (date.HasValue)
            {
                query = query.Where(m => m.Date.Date == date.Value.Date);
            }

            return await query.ToListAsync();
        }
    }
}