using WebApi.Models;

namespace WebApi.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public List<string> SportsPreferes { get; set; }
        public string Ville { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public DateTime DateInscription { get; set; }
    }
}