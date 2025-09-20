using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class ParticipationRepository : IParticipationRepository
    {
        private readonly ApplicationDbContext _context;

        public ParticipationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Participation participation)
        {
            _context.Participations.Add(participation);
            await _context.SaveChangesAsync();
        }

        public async Task<Participation> GetByIdAsync(int id)
        {
            return await _context.Participations
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Participation>> GetByMatchIdAsync(int matchId)
        {
            return await _context.Participations
                .Include(p => p.User)
                .Where(p => p.MatchId == matchId)
                .ToListAsync();
        }

        public async Task UpdateAsync(Participation participation)
        {
            _context.Participations.Update(participation);
            await _context.SaveChangesAsync();
        }
    }
}