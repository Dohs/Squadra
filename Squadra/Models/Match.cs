using System.ComponentModel.DataAnnotations;

namespace Squadra.Models
{
    public class Match
    {
        public int Id { get; set; }

        [Required]
        public int SportId { get; set; }
        public Sport Sport { get; set; } = null!;

        [Required]
        public int CreatorId { get; set; }
        public User Creator { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(100)]
        public string Lieu { get; set; } = null!;

        [Required]
        public int CapaciteMax { get; set; }

        public SkillLevel RequiredLevel { get; set; }

        [Required]
        public string Statut { get; set; } = "Ouvert"; // Ouvert, Terminé
    }
}