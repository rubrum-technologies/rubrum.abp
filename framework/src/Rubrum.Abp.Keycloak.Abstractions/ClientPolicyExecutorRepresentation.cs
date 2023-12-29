namespace Rubrum.Abp.Keycloak;

public class ClientPolicyExecutorRepresentation
{
    public string? Executor { get; set; }

    public List<object>? Configuration { get; set; }
}
