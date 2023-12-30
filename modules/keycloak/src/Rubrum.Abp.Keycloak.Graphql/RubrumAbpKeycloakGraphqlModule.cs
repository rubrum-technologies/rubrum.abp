using Rubrum.Abp.Graphql;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Keycloak;

[DependsOn(typeof(RubrumAbpGraphqlModule))]
[DependsOn(typeof(RubrumAbpKeycloakApplicationModule))]
[DependsOn(typeof(RubrumAbpKeycloakGraphqlContractsModule))]
public class RubrumAbpKeycloakGraphqlModule : AbpModule;
