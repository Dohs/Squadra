using Squadra.UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Squadra.UI.Services;

public interface ISportService
{
    Task<List<SportDto>> GetAllSportsAsync();
}
