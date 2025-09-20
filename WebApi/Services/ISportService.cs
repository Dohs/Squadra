using WebApi.DTOs;

namespace WebApi.Services
{
    public interface ISportService
    {
        Task<List<SportDto>> GetAllAsync();
    }
}