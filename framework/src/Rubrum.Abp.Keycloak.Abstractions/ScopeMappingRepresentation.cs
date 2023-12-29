namespace Rubrum.Abp.Keycloak;

public class ScopeMappingRepresentation
{
    public string? Self { get; set; }

    public string? Client { get; set; }

    public string? ClientTemplate { get; set; }

    public string? ClientScope { get; set; }

    public List<string>? Roles { get; set; }
}
