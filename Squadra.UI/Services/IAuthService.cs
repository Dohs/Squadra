using Squadra.UI.Models;
using System.Threading.Tasks;

namespace Squadra.UI.Services;

public interface IAuthService
{
    Task Register(RegisterDto registerDto);
    Task Login(LoginDto loginDto);
    Task Logout();
}
