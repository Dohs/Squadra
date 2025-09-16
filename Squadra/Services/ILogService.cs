using Squadra.Models;
using System;
using System.Threading.Tasks;

namespace Squadra.Services
{
    public interface ILogService
    {
        Task Log(ApplicationLogLevel level, string message, Exception? ex = null);
        Task LogInformation(string message);
        Task LogWarning(string message);
        Task LogError(string message, Exception? ex = null);
        Task LogCritical(string message, Exception? ex = null);
    }
}
