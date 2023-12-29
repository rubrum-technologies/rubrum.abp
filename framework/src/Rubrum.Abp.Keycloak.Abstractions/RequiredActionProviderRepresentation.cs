namespace Rubrum.Abp.Keycloak;

public class RequiredActionProviderRepresentation
{
    public string? Alias { get; set; }

    public string? Name { get; set; }

    public string? ProviderId { get; set; }

    public bool? Enabled { get; set; }

    public bool? DefaultAction { get; set; }

    public int? Priority { get; set; }

    public Dictionary<string, string>? Config { get; set; }
}
