using Squadra.Models;

namespace Squadra.Repositories
{
    public interface IMessageRepository
    {
        Task AddAsync(Message message);
        Task<List<Message>> GetByMatchIdAsync(int matchId);
    }
}