using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Squadra.UI.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Squadra.UI.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task Login(LoginDto loginDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginDto);
        response.EnsureSuccessStatusCode(); // Throws on error

        var result = await response.Content.ReadFromJsonAsync<LoginResult>();
        if (result == null || string.IsNullOrEmpty(result.Token))
            throw new System.Exception("Token not found in response.");

        await _localStorage.SetItemAsync("authToken", result.Token);
        ((CustomAuthStateProvider)_authenticationStateProvider).NotifyUserAuthentication(result.Token);
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        ((CustomAuthStateProvider)_authenticationStateProvider).NotifyUserLogout();
    }

    public async Task Register(RegisterDto registerDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/register", registerDto);
        response.EnsureSuccessStatusCode(); // Throws on error

        var result = await response.Content.ReadFromJsonAsync<LoginResult>();
        if (result == null || string.IsNullOrEmpty(result.Token))
            throw new System.Exception("Token not found in response.");

        await _localStorage.SetItemAsync("authToken", result.Token);
        ((CustomAuthStateProvider)_authenticationStateProvider).NotifyUserAuthentication(result.Token);
    }
}