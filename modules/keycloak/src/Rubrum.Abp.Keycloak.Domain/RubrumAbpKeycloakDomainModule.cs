using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Keycloak;

[DependsOn(typeof(AbpDddDomainModule))]
[DependsOn(typeof(RubrumAbpKeycloakAbstractionsModule))]
[DependsOn(typeof(RubrumAbpKeycloakDomainSharedModule))]
public class RubrumAbpKeycloakDomainModule : AbpModule
{
}
