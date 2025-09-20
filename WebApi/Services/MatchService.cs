using WebApi.DTOs;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;

        public MatchService(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<MatchDto> CreateAsync(MatchCreateDto dto, int creatorId)
        {
            var match = new Match
            {
                SportId = dto.SportId,
                CreatorId = creatorId,
                Date = dto.Date,
                Lieu = dto.Lieu,
                CapaciteMax = dto.CapaciteMax,
                RequiredLevel = dto.RequiredLevel
            };

            await _matchRepository.AddAsync(match);

            return new MatchDto
            {
                Id = match.Id,
                SportId = match.SportId,
                CreatorId = match.CreatorId,
                Date = match.Date,
                Lieu = match.Lieu,
                CapaciteMax = match.CapaciteMax,
                Statut = match.Statut
            };
        }

        public async Task<List<MatchDto>> GetAllAsync(string sport, string ville, DateTime? date)
        {
            var matches = await _matchRepository.GetAllAsync(sport, ville, date);
            return matches.Select(m => new MatchDto
            {
                Id = m.Id,
                SportId = m.SportId,
                CreatorId = m.CreatorId,
                Date = m.Date,
                Lieu = m.Lieu,
                CapaciteMax = m.CapaciteMax,
                Statut = m.Statut,
                RequiredLevel = m.RequiredLevel
            }).ToList();
        }

        public async Task<MatchDto> GetByIdAsync(int id)
        {
            var match = await _matchRepository.GetByIdAsync(id);
            if (match == null) throw new Exception("Match not found");

            return new MatchDto
            {
                Id = match.Id,
                SportId = match.SportId,
                CreatorId = match.CreatorId,
                Date = match.Date,
                Lieu = match.Lieu,
                CapaciteMax = match.CapaciteMax,
                Statut = match.Statut,
                RequiredLevel = match.RequiredLevel
            };
        }
    }
}