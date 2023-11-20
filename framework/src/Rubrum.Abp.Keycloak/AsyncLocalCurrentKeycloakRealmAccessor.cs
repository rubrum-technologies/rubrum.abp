namespace Rubrum.Abp.Keycloak;

public class AsyncLocalCurrentKeycloakRealmAccessor : ICurrentKeycloakRealmAccessor
{
    private readonly AsyncLocal<BasicKeycloakRealmInfo?> _currentScope = new();

    private AsyncLocalCurrentKeycloakRealmAccessor()
    {
    }

    public static AsyncLocalCurrentKeycloakRealmAccessor Instance { get; } = new();

    public BasicKeycloakRealmInfo? Current
    {
        get => _currentScope.Value;
        set => _currentScope.Value = value;
    }
}
