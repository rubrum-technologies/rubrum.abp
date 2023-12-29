using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Rubrum.Abp.ImageStoring;

[DependsOn(typeof(AbpHttpClientModule))]
[DependsOn(typeof(RubrumAbpImageStoringApplicationContractsModule))]
public class RubrumAbpImageStoringHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddStaticHttpClientProxies(
            typeof(RubrumAbpImageStoringApplicationContractsModule).Assembly,
            ImageStoringRemoteServiceConstants.RemoteServiceName);

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<RubrumAbpImageStoringHttpApiClientModule>();
        });
    }
}
