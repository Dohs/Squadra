using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Message>> GetByMatchIdAsync(int matchId)
        {
            return await _context.Messages
                .Include(msg => msg.User)
                .Where(msg => msg.MatchId == matchId)
                .OrderBy(msg => msg.Timestamp)
                .ToListAsync();
        }
    }
}