﻿namespace Rubrum.Abp.Keycloak;

#nullable disable

public class RubrumAbpKeycloakClientsOptions
{
    public IReadOnlyDictionary<string, GatewayOptions> Gateways { get; set; }
    public IReadOnlyDictionary<string, KeycloakClientOptions> Microservices { get; set; }
    public IReadOnlyDictionary<string, KeycloakClientOptions> Apps { get; set; }
    public SwaggerClientOptions Swagger { get; set; }
}