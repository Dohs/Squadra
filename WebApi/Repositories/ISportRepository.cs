using WebApi.Models;

namespace WebApi.Repositories
{
    public interface ISportRepository
    {
        Task<List<Sport>> GetAllAsync();
    }
}