using Squadra.DTOs;
using Squadra.Models;
using Squadra.Repositories;

namespace Squadra.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IParticipationRepository _participationRepository;

        public RatingService(IRatingRepository ratingRepository, IMatchRepository matchRepository, IParticipationRepository participationRepository)
        {
            _ratingRepository = ratingRepository;
            _matchRepository = matchRepository;
            _participationRepository = participationRepository;
        }

        public async Task<RatingDto> CreateAsync(int matchId, int reviewerId, RatingCreateDto dto)
        {
            var match = await _matchRepository.GetByIdAsync(matchId);
            if (match == null) throw new Exception("Match not found");

            // Check if reviewer and participant are in the match (simplified, add more checks if needed)
            var rating = new Rating
            {
                MatchId = matchId,
                ReviewerId = reviewerId,
                ParticipantId = dto.ParticipantId,
                Rate = dto.Rate,
                Comment = dto.Comment
            };

            await _ratingRepository.AddAsync(rating);

            return new RatingDto
            {
                Id = rating.Id,
                ReviewerId = rating.ReviewerId,
                ParticipantId = rating.ParticipantId,
                Rate = rating.Rate,
                Comment = rating.Comment,
                CreatedAt = rating.CreatedAt
            };
        }

        public async Task<List<RatingDto>> GetByMatchIdAsync(int matchId)
        {
            var ratings = await _ratingRepository.GetByMatchIdAsync(matchId);
            return ratings.Select(r => new RatingDto
            {
                Id = r.Id,
                ReviewerId = r.ReviewerId,
                ParticipantId = r.ParticipantId,
                Rate = r.Rate,
                Comment = r.Comment,
                CreatedAt = r.CreatedAt
            }).ToList();
        }
    }
}