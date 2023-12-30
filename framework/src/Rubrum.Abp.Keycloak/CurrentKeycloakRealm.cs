using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.Keycloak;

public class CurrentKeycloakRealm(
    ICurrentKeycloakRealmAccessor accessor,
    IOptions<RubrumAbpKeycloakOptions> options)
    : ICurrentKeycloakRealm, ITransientDependency
{
    private readonly RubrumAbpKeycloakOptions _options = options.Value;

    public string RealmName => accessor.Current?.RealmName ?? _options.DefaultRealmName ?? "master";

    public IDisposable Change(string realmName)
    {
        var parentScope = accessor.Current;
        accessor.Current = new BasicKeycloakRealmInfo(realmName);

        return new DisposeAction<(ICurrentKeycloakRealmAccessor, BasicKeycloakRealmInfo?)>(
            static state =>
            {
                var (currentTenantAccessor, parentScope) = state;
                currentTenantAccessor.Current = parentScope;
            },
            (accessor, parentScope));
    }
}
