using System.ComponentModel.DataAnnotations;

namespace Squadra.Models
{
    public class Participation
    {
        public int Id { get; set; }

        [Required]
        public int MatchId { get; set; }
        public Match Match { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        public string Message { get; set; }

        [Required]
        public string Status { get; set; } = "Pending"; // Pending, Accepted, Rejected

        public DateTime DateInscription { get; set; } = DateTime.UtcNow;
    }
}