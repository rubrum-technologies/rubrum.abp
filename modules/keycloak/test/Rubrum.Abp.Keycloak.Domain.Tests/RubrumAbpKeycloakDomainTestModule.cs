using Volo.Abp.Modularity;

namespace Rubrum.Abp.Keycloak;

[DependsOn(typeof(RubrumAbpKeycloakTestBaseModule))]
public class RubrumAbpKeycloakDomainTestModule : AbpModule
{
}
