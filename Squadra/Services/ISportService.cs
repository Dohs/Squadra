using Squadra.DTOs;

namespace Squadra.Services
{
    public interface ISportService
    {
        Task<List<SportDto>> GetAllAsync();
    }
}