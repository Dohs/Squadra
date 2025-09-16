using Squadra.DTOs;
using Squadra.Models;
using Squadra.Repositories;

namespace Squadra.Services
{
    public class ParticipationService : IParticipationService
    {
        private readonly IParticipationRepository _participationRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IUserRepository _userRepository;

        public ParticipationService(IParticipationRepository participationRepository, IMatchRepository matchRepository, IUserRepository userRepository)
        {
            _participationRepository = participationRepository;
            _matchRepository = matchRepository;
            _userRepository = userRepository;
        }

        public async Task<ParticipationDto> JoinAsync(int matchId, int userId, JoinRequestDto dto)
        {
            var match = await _matchRepository.GetByIdAsync(matchId);
            if (match == null) throw new Exception("Match not found");

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) throw new Exception("User not found");

            if (user.SkillLevel < match.RequiredLevel)
            {
                throw new Exception("User skill level is not sufficient for this match.");
            }

            var participation = new Participation
            {
                MatchId = matchId,
                UserId = userId,
                Message = dto.Message
            };

            await _participationRepository.AddAsync(participation);

            return new ParticipationDto
            {
                Id = participation.Id,
                UserId = participation.UserId,
                Message = participation.Message,
                Status = participation.Status,
                DateInscription = participation.DateInscription
            };
        }

        public async Task<List<ParticipationDto>> GetRequestsAsync(int matchId)
        {
            var requests = await _participationRepository.GetByMatchIdAsync(matchId);
            return requests.Select(p => new ParticipationDto
            {
                Id = p.Id,
                UserId = p.UserId,
                Message = p.Message,
                Status = p.Status,
                DateInscription = p.DateInscription
            }).ToList();
        }

        public async Task AcceptAsync(int matchId, int requestId, int organizerId)
        {
            var match = await _matchRepository.GetByIdAsync(matchId);
            if (match == null || match.CreatorId != organizerId) throw new Exception("Unauthorized or match not found");

            var participation = await _participationRepository.GetByIdAsync(requestId);
            if (participation == null || participation.MatchId != matchId) throw new Exception("Request not found");

            participation.Status = "Accepted";
            await _participationRepository.UpdateAsync(participation);
        }

        public async Task RejectAsync(int matchId, int requestId, int organizerId)
        {
            var match = await _matchRepository.GetByIdAsync(matchId);
            if (match == null || match.CreatorId != organizerId) throw new Exception("Unauthorized or match not found");

            var participation = await _participationRepository.GetByIdAsync(requestId);
            if (participation == null || participation.MatchId != matchId) throw new Exception("Request not found");

            participation.Status = "Rejected";
            await _participationRepository.UpdateAsync(participation);
        }
    }
}