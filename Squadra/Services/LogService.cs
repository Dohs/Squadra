using Squadra.Models;
using Squadra.Repositories;
using System;
using System.Threading.Tasks;

namespace Squadra.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task Log(ApplicationLogLevel level, string message, Exception? ex = null)
        {
            var log = new Log
            {
                Timestamp = DateTime.UtcNow,
                Level = level,
                Message = message,
                Exception = ex?.ToString(),
                StackTrace = ex?.StackTrace
            };
            await _logRepository.AddAsync(log);
        }

        public Task LogInformation(string message) => Log(ApplicationLogLevel.Information, message);
        public Task LogWarning(string message) => Log(ApplicationLogLevel.Warning, message);
        public Task LogError(string message, Exception? ex = null) => Log(ApplicationLogLevel.Error, message, ex);
        public Task LogCritical(string message, Exception? ex = null) => Log(ApplicationLogLevel.Critical, message, ex);
    }
}
