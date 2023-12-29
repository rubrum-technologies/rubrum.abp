namespace Rubrum.Abp.Keycloak;

public class Permission
{
    public string? Rsid { get; set; }

    public string? Rsname { get; set; }

    public List<string>? Scopes { get; set; }

    public Dictionary<string, List<object>>? Claims { get; set; }
}
