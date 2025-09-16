using Squadra.DTOs;

namespace Squadra.Services
{
    public interface IRatingService
    {
        Task<RatingDto> CreateAsync(int matchId, int reviewerId, RatingCreateDto dto);
        Task<List<RatingDto>> GetByMatchIdAsync(int matchId);
    }
}