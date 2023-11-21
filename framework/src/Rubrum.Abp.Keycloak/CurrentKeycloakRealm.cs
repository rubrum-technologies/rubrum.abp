using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.Keycloak;

public class CurrentKeycloakRealm : ICurrentKeycloakRealm, ITransientDependency
{
    private readonly ICurrentKeycloakRealmAccessor _accessor;
    private readonly RubrumAbpKeycloakOptions _options;

    public CurrentKeycloakRealm(
        ICurrentKeycloakRealmAccessor accessor,
        IOptions<RubrumAbpKeycloakOptions> options)
    {
        _accessor = accessor;
        _options = options.Value;
    }

    public string RealmName => _accessor.Current?.RealmName ?? _options.DefaultRealmName ?? "master";

    public IDisposable Change(string realmName)
    {
        var parentScope = _accessor.Current;
        _accessor.Current = new BasicKeycloakRealmInfo(realmName);

        return new DisposeAction<ValueTuple<ICurrentKeycloakRealmAccessor, BasicKeycloakRealmInfo?>>(static state =>
            {
                var (currentTenantAccessor, parentScope) = state;
                currentTenantAccessor.Current = parentScope;
            },
            (_accessor, parentScope));
    }
}
