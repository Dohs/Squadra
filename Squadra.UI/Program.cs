using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Squadra.UI;
using Blazored.LocalStorage;
using Squadra.UI.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register the custom handler
builder.Services.AddTransient<AuthHeaderHandler>();

// Configure HttpClient to use the handler
builder.Services.AddHttpClient("WebApi", client => client.BaseAddress = new Uri("https://localhost:7064"))
    .AddHttpMessageHandler<AuthHeaderHandler>();

// Create a temporary HttpClient for services that need it directly (like AuthService)
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WebApi"));

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISportService, SportService>();
builder.Services.AddScoped<IMatchService, MatchService>();

await builder.Build().RunAsync();
