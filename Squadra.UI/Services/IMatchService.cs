using Squadra.UI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Squadra.UI.Services;

public interface IMatchService
{
    Task<List<MatchDto>> GetAllMatchesAsync(string? sport = null, string? ville = null, DateTime? date = null);
}
