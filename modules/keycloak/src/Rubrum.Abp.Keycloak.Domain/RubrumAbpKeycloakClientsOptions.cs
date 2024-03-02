namespace Rubrum.Abp.Keycloak;

public class RubrumAbpKeycloakClientsOptions
{
    public IReadOnlyDictionary<string, GatewayOptions>? Gateways { get; set; }

    public IReadOnlyDictionary<string, KeycloakClientOptions>? Microservices { get; set; }

    public IReadOnlyDictionary<string, KeycloakClientOptions>? Apps { get; set; }

    public KeycloakClientOptions? Swagger { get; set; }
}
