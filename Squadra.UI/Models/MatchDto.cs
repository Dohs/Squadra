using System;
using System.Collections.Generic;

namespace Squadra.UI.Models;

public class MatchDto
{
    public int Id { get; set; }
    public SportDto Sport { get; set; } = new SportDto();
    public string Ville { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int Capacity { get; set; }
    public int RequiredLevel { get; set; }
    public UserDto Organizer { get; set; } = new UserDto();
    public List<UserDto> Participants { get; set; } = new List<UserDto>();
    public int CurrentParticipants => Participants.Count;
    public bool IsFull => CurrentParticipants >= Capacity;
    public bool IsOrganizer { get; set; } // Will be set on client-side based on current user
    public bool HasJoined { get; set; } // Will be set on client-side based on current user
}
