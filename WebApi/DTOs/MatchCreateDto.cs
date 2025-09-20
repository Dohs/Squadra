using System.ComponentModel.DataAnnotations;
using WebApi.Models;

namespace WebApi.DTOs
{
    public class MatchCreateDto
    {
        [Required]
        public int SportId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Lieu { get; set; }

        [Required]
        public int CapaciteMax { get; set; }

        public SkillLevel RequiredLevel { get; set; }
    }
}