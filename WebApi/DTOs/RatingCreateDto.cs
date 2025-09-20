using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs
{
    public class RatingCreateDto
    {
        [Required]
        public int ParticipantId { get; set; }

        [Range(1, 5)]
        public int Rate { get; set; }

        public string Comment { get; set; }
    }
}