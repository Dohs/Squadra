using Squadra.Models;

namespace Squadra.Repositories
{
    public interface ISportRepository
    {
        Task<List<Sport>> GetAllAsync();
    }
}