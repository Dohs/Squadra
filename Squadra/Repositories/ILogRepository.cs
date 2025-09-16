using Squadra.Models;
using System.Threading.Tasks;

namespace Squadra.Repositories
{
    public interface ILogRepository
    {
        Task AddAsync(Log log);
    }
}
