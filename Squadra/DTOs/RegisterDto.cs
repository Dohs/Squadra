using System.ComponentModel.DataAnnotations;
using Squadra.Models;

namespace Squadra.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Nom { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public SkillLevel SkillLevel { get; set; }
    }
}