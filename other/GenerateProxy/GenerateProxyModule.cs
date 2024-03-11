using Rubrum.Abp.Hosting;
using Rubrum.Abp.ImageStoring;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace GenerateProxy;

[DependsOn(typeof(RubrumAbpHostingAspNetCoreMicroserviceModule))]
[DependsOn(typeof(RubrumAbpImageStoringHttpApiModule))]
public class GenerateProxyModule : AbpModule
{
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();

        app.UseRouting();
        app.UseConfiguredEndpoints();
    }
}
