using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Keycloak;

[DependsOn(typeof(AbpDddDomainSharedModule))]
public class RubrumAbpKeycloakDomainSharedModule : AbpModule
{
    
}
