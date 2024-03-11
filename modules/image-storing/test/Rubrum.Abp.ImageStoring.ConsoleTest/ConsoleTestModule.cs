using Rubrum.Abp.Hosting;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.ImageStoring;

[DependsOn(typeof(RubrumAbpHostingAspNetCoreMicroserviceModule))]
[DependsOn(typeof(RubrumAbpImageStoringHttpApiModule))]
public class ConsoleTestModule : AbpModule
{
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();

        app.UseRouting();

        app.UseConfiguredEndpoints();
    }
}
