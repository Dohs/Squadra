using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Rating
    {
        public int Id { get; set; }

        [Required]
        public int MatchId { get; set; }
        public Match Match { get; set; }

        [Required]
        public int ReviewerId { get; set; }
        public User Reviewer { get; set; }

        [Required]
        public int ParticipantId { get; set; }
        public User Participant { get; set; }

        [Range(1, 5)]
        public int Rate { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}