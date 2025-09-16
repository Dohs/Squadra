using Squadra.DTOs;
using Squadra.Repositories;

namespace Squadra.Services
{
    public class SportService : ISportService
    {
        private readonly ISportRepository _sportRepository;

        public SportService(ISportRepository sportRepository)
        {
            _sportRepository = sportRepository;
        }

        public async Task<List<SportDto>> GetAllAsync()
        {
            var sports = await _sportRepository.GetAllAsync();
            return sports.Select(s => new SportDto { Id = s.Id, Nom = s.Nom }).ToList();
        }
    }
}