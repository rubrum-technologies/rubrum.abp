using Volo.Abp.Modularity;

namespace Rubrum.Abp.Keycloak;

[DependsOn(typeof(RubrumAbpKeycloakTestBaseModule))]
[DependsOn(typeof(RubrumAbpKeycloakApplicationModule))]
public class RubrumAbpKeycloakApplicationTestModule : AbpModule
{
}
