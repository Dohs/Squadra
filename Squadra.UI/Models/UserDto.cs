using System.Collections.Generic;

namespace Squadra.UI.Models;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Ville { get; set; }
    public SkillLevel SkillLevel { get; set; }
    public List<SportDto> PreferredSports { get; set; } = new List<SportDto>();
    // TODO: Add ratings when those models are created.
}