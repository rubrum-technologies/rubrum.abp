namespace Rubrum.Abp.Keycloak;

public class ManagementPermissionReference
{
    public bool? Enabled { get; set; }
    public string? Resource { get; set; }
    public Dictionary<string, string>? ScopePermissions { get; set; }
}
