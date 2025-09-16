using Squadra.DTOs;

namespace Squadra.Services
{
    public interface IMatchService
    {
        Task<MatchDto> CreateAsync(MatchCreateDto dto, int creatorId);
        Task<List<MatchDto>> GetAllAsync(string sport, string ville, DateTime? date);
        Task<MatchDto> GetByIdAsync(int id);
    }
}