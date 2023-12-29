using Microsoft.Extensions.DependencyInjection;
using Polly;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Hosting;

[DependsOn(typeof(AbpHttpClientModule))]
[DependsOn(typeof(RubrumAbpHostingAspNetCoreModule))]
public class RubrumAbpHostingAspNetCoreMicroserviceModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<AbpHttpClientBuilderOptions>(options =>
        {
            options.ProxyClientBuildActions.Add((_, clientBuilder) =>
            {
                clientBuilder.AddTransientHttpErrorPolicy(policyBuilder =>
                    policyBuilder.WaitAndRetryAsync(
                        3,
                        i => TimeSpan.FromSeconds(Math.Pow(2, i))));
            });
        });
    }
}
