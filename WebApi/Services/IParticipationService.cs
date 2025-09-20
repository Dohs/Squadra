using WebApi.DTOs;

namespace WebApi.Services
{
    public interface IParticipationService
    {
        Task<ParticipationDto> JoinAsync(int matchId, int userId, JoinRequestDto dto);
        Task<List<ParticipationDto>> GetRequestsAsync(int matchId);
        Task AcceptAsync(int matchId, int requestId, int organizerId);
        Task RejectAsync(int matchId, int requestId, int organizerId);
    }
}