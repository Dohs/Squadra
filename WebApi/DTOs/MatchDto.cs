using WebApi.Models;

namespace WebApi.DTOs
{
    public class MatchDto
    {
        public int Id { get; set; }
        public int SportId { get; set; }
        public int CreatorId { get; set; }
        public DateTime Date { get; set; }
        public string Lieu { get; set; }
        public int CapaciteMax { get; set; }
        public string Statut { get; set; }
        public SkillLevel RequiredLevel { get; set; }
    }
}