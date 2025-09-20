using WebApi.Models;
using System.Threading.Tasks;

namespace WebApi.Repositories
{
    public interface ILogRepository
    {
        Task AddAsync(Log log);
    }
}
