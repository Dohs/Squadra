using WebApi.DTOs;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<MessageDto> SendAsync(int matchId, int userId, MessageCreateDto dto)
        {
            var message = new Message
            {
                MatchId = matchId,
                UserId = userId,
                Content = dto.Content
            };

            await _messageRepository.AddAsync(message);

            return new MessageDto
            {
                Id = message.Id,
                UserId = message.UserId,
                Content = message.Content,
                Timestamp = message.Timestamp
            };
        }

        public async Task<List<MessageDto>> GetByMatchIdAsync(int matchId)
        {
            var messages = await _messageRepository.GetByMatchIdAsync(matchId);
            return messages.Select(msg => new MessageDto
            {
                Id = msg.Id,
                UserId = msg.UserId,
                Content = msg.Content,
                Timestamp = msg.Timestamp
            }).ToList();
        }
    }
}