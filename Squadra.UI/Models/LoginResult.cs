using System.Text.Json.Serialization;

namespace Squadra.UI.Models;

public class LoginResult
{
    [JsonPropertyName("token")]
    public string Token { get; set; } = string.Empty;
}
