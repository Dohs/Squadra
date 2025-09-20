using Squadra.UI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Squadra.UI.Services;

public class SportService : ISportService
{
    private readonly HttpClient _httpClient;

    public SportService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<SportDto>> GetAllSportsAsync()
    {
        var sports = await _httpClient.GetFromJsonAsync<List<SportDto>>("api/sports");
        return sports ?? new List<SportDto>();
    }
}
