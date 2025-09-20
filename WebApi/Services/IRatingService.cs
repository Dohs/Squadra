using WebApi.DTOs;

namespace WebApi.Services
{
    public interface IRatingService
    {
        Task<RatingDto> CreateAsync(int matchId, int reviewerId, RatingCreateDto dto);
        Task<List<RatingDto>> GetByMatchIdAsync(int matchId);
    }
}