namespace Rubrum.Abp.Keycloak;

public class ConfigPropertyRepresentation
{
    public string? Name { get; set; }
    public string? Label { get; set; }
    public string? HelpText { get; set; }
    public string? Type { get; set; }
    public object? DefaultValue { get; set; }
    public List<string>? Options { get; set; }
    public bool? Secret { get; set; }
    public bool? ReadOnly { get; set; }
}
