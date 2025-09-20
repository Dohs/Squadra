using WebApi.DTOs;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new Exception("User not found");

            return new UserDto
            {
                Id = user.Id,
                Nom = user.Nom,
                Email = user.Email,
                SportsPreferes = user.SportsPreferes,
                Ville = user.Ville,
                SkillLevel = user.SkillLevel,
                DateInscription = user.DateInscription
            };
        }

        public async Task UpdateAsync(int id, UserUpdateDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new Exception("User not found");

            if (!string.IsNullOrEmpty(dto.Nom)) user.Nom = dto.Nom;
            if (dto.SportsPreferes != null) user.SportsPreferes = dto.SportsPreferes;
            if (!string.IsNullOrEmpty(dto.Ville)) user.Ville = dto.Ville;
            if (dto.SkillLevel.HasValue) user.SkillLevel = dto.SkillLevel.Value;

            await _userRepository.UpdateAsync(user);
        }

        public async Task<UserRatingDto> GetRatingsAsync(int id)
        {
            var average = await _userRepository.GetAverageRatingAsync(id);
            var ratings = await _userRepository.GetRatingsForUserAsync(id);

            return new UserRatingDto
            {
                AverageRating = average,
                Ratings = ratings.Select(r => new RatingDto
                {
                    Id = r.Id,
                    ReviewerId = r.ReviewerId,
                    ParticipantId = r.ParticipantId,
                    Rate = r.Rate,
                    Comment = r.Comment,
                    CreatedAt = r.CreatedAt
                }).ToList()
            };
        }
    }
}