using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task<double> GetAverageRatingAsync(int userId);
        Task<List<Rating>> GetRatingsForUserAsync(int userId);
    }
}