using Squadra.DTOs;

namespace Squadra.Services
{
    public interface IUserService
    {
        Task<UserDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, UserUpdateDto dto);
        Task<UserRatingDto> GetRatingsAsync(int id);
    }
}