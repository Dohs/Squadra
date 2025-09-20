using Blazored.LocalStorage;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Squadra.UI.Services;

public class AuthHeaderHandler : DelegatingHandler
{
    private readonly ILocalStorageService _localStorage;

    public AuthHeaderHandler(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (await _localStorage.ContainKeyAsync("authToken"))
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
