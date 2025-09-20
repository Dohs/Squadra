using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IRatingRepository
    {
        Task AddAsync(Rating rating);
        Task<List<Rating>> GetByMatchIdAsync(int matchId);
    }
}