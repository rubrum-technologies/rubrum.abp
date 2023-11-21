using Rubrum.Abp.Graphql;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Hosting;

[DependsOn(typeof(RubrumAbpGraphqlModule))]
[DependsOn(typeof(RubrumAbpHostingAspNetCoreMicroserviceModule))]
public class RubrumAbpHostingAspNetCoreMicroserviceGraphqlModule : AbpModule
{
}
