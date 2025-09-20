using Microsoft.AspNetCore.Components.Authorization;
using Squadra.UI.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Linq;

namespace Squadra.UI.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public UserService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider)
    {
        _httpClient = httpClient;
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<UserDto> GetMyProfileAsync()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            throw new System.Exception("User ID not found in token.");
        }

        var profile = await _httpClient.GetFromJsonAsync<UserDto>($"api/users/{userId}");
        
        if (profile == null)
        {
            throw new System.Exception("Failed to retrieve user profile.");
        }

        return profile;
    }

    public async Task UpdateMyProfileAsync(UserUpdateDto userUpdateDto)
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            throw new System.Exception("User ID not found in token.");
        }

        var response = await _httpClient.PutAsJsonAsync($"api/users/{userId}", userUpdateDto);
        response.EnsureSuccessStatusCode();
    }
}