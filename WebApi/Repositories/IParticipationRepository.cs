using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IParticipationRepository
    {
        Task AddAsync(Participation participation);
        Task<Participation> GetByIdAsync(int id);
        Task<List<Participation>> GetByMatchIdAsync(int matchId);
        Task UpdateAsync(Participation participation);
    }
}