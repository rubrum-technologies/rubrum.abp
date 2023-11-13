using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Rubrum.Abp.LanguageManagement;

[DependsOn(typeof(AbpHttpClientModule))]
[DependsOn(typeof(RubrumAbpLanguageManagementApplicationContractsModule))]
public class RubrumAbpLanguageManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddStaticHttpClientProxies(
            typeof(RubrumAbpLanguageManagementApplicationContractsModule).Assembly,
            RubrumAbpLanguageManagementRemoteServiceConstants.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<RubrumAbpLanguageManagementHttpApiClientModule>();
        });
    }
}
