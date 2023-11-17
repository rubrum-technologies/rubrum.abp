using System.Text.Json.Serialization;

namespace Rubrum.Abp.Keycloak;

public class CertConf
{
    [JsonPropertyName("x5t#S256")]
    public string? X5Ts256 { get; set; }
}
