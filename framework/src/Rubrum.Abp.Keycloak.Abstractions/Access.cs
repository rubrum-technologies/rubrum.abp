using System.Text.Json.Serialization;

namespace Rubrum.Abp.Keycloak;

public class Access
{
    public List<string>? Roles { get; set; }

    [JsonPropertyName("verify_caller")]
    public bool? VerifyCaller { get; set; }
}
