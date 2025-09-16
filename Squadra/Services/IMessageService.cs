using Squadra.DTOs;

namespace Squadra.Services
{
    public interface IMessageService
    {
        Task<MessageDto> SendAsync(int matchId, int userId, MessageCreateDto dto);
        Task<List<MessageDto>> GetByMatchIdAsync(int matchId);
    }
}