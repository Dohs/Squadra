using Squadra.UI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web; // For HttpUtility.ParseQueryString

namespace Squadra.UI.Services;

public class MatchService : IMatchService
{
    private readonly HttpClient _httpClient;

    public MatchService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<MatchDto>> GetAllMatchesAsync(string? sport = null, string? ville = null, DateTime? date = null)
    {
        var uriBuilder = new UriBuilder(_httpClient.BaseAddress! + "api/matches");
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);

        if (!string.IsNullOrEmpty(sport))
        {
            query["sport"] = sport;
        }
        if (!string.IsNullOrEmpty(ville))
        {
            query["ville"] = ville;
        }
        if (date.HasValue)
        {
            query["date"] = date.Value.ToString("yyyy-MM-dd");
        }

        uriBuilder.Query = query.ToString();
        var url = uriBuilder.ToString();

        var matches = await _httpClient.GetFromJsonAsync<List<MatchDto>>(url);
        return matches ?? new List<MatchDto>();
    }
}
