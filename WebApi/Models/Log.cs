using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public enum ApplicationLogLevel
    {
        Information,
        Warning,
        Error,
        Critical
    }

    public class Log
    {
        public int Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public ApplicationLogLevel Level { get; set; }

        [Required]
        public string Message { get; set; } = null!;

        public string? StackTrace { get; set; }
        
        public string? Exception { get; set; }
    }
}
