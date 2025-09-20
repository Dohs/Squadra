using WebApi.Models;

namespace WebApi.DTOs
{
    public class UserUpdateDto
    {
        public string Nom { get; set; }
        public List<string> SportsPreferes { get; set; }
        public string Ville { get; set; }
        public SkillLevel? SkillLevel { get; set; }
    }
}