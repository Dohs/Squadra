using WebApi.DTOs;

namespace WebApi.Services
{
    public interface IUserService
    {
        Task<UserDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, UserUpdateDto dto);
        Task<UserRatingDto> GetRatingsAsync(int id);
    }
}