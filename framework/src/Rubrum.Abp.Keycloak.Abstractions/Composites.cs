namespace Rubrum.Abp.Keycloak;

public class Composites
{
    public List<string>? Realm { get; set; }

    public Dictionary<string, List<object>>? Client { get; set; }

    public Dictionary<string, List<object>>? Application { get; set; }
}
