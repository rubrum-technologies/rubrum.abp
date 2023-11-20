using System.Text.Json.Serialization;

namespace Rubrum.Abp.Keycloak;

internal class OAuth2Token
{
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; set; }
}
