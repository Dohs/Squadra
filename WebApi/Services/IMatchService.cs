using WebApi.DTOs;

namespace WebApi.Services
{
    public interface IMatchService
    {
        Task<MatchDto> CreateAsync(MatchCreateDto dto, int creatorId);
        Task<List<MatchDto>> GetAllAsync(string sport, string ville, DateTime? date);
        Task<MatchDto> GetByIdAsync(int id);
    }
}