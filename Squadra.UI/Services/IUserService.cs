using Squadra.UI.Models;
using System.Threading.Tasks;

namespace Squadra.UI.Services;

public interface IUserService
{
    Task<UserDto> GetMyProfileAsync();
    Task UpdateMyProfileAsync(UserUpdateDto userUpdateDto);
}