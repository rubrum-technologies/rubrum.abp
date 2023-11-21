using Rubrum.Abp.Graphql;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Keycloak;

[DependsOn(typeof(RubrumAbpGraphqlContractsModule))]
[DependsOn(typeof(RubrumAbpKeycloakApplicationContractsModule))]
public class RubrumAbpKeycloakGraphqlContractsModule : AbpModule
{
}
