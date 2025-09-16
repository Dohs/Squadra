using System.ComponentModel.DataAnnotations;

namespace Squadra.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;

        public List<string> SportsPreferes { get; set; } = new List<string>();

        [StringLength(100)]
        public string? Ville { get; set; }

        public SkillLevel SkillLevel { get; set; }

        public DateTime DateInscription { get; set; } = DateTime.UtcNow;
    }
}