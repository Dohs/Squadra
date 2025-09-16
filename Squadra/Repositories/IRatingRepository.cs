using Squadra.Models;

namespace Squadra.Repositories
{
    public interface IRatingRepository
    {
        Task AddAsync(Rating rating);
        Task<List<Rating>> GetByMatchIdAsync(int matchId);
    }
}