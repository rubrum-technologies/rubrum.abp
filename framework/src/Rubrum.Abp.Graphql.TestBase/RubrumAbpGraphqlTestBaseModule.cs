using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Graphql;

[DependsOn(typeof(AbpTestBaseModule))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(RubrumAbpGraphqlModule))]
public class RubrumAbpGraphqlTestBaseModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddSingleton(sp =>
            new RequestExecutorProxy(sp.GetRequiredService<IRequestExecutorResolver>(), "_Default"));
    }
}
