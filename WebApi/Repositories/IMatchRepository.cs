using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IMatchRepository
    {
        Task AddAsync(Match match);
        Task<Match> GetByIdAsync(int id);
        Task<List<Match>> GetAllAsync(string sport = null, string ville = null, DateTime? date = null);
    }
}