using System.Collections.Generic;

namespace Squadra.UI.Models;

public class UserUpdateDto
{
    public string Name { get; set; } = string.Empty;
    public string? Ville { get; set; }
    public int SkillLevel { get; set; }
    public List<int> PreferredSportIds { get; set; } = new List<int>();
}