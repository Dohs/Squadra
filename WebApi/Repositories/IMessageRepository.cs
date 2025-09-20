using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IMessageRepository
    {
        Task AddAsync(Message message);
        Task<List<Message>> GetByMatchIdAsync(int matchId);
    }
}