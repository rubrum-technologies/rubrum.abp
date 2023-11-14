using Microsoft.Extensions.DependencyInjection;
using Rubrum.Abp.Imaging.MagickNet;
using Volo.Abp;
using Volo.Abp.Authorization;
using Volo.Abp.Autofac;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;
using Volo.Abp.VirtualFileSystem;

namespace Rubrum.Abp.ImageStoring;

[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(AbpTestBaseModule))]
[DependsOn(typeof(AbpAuthorizationModule))]
[DependsOn(typeof(AbpVirtualFileSystemModule))]
[DependsOn(typeof(AbpBlobStoringFileSystemModule))]
[DependsOn(typeof(RubrumAbpImagingMagickNetModule))]
[DependsOn(typeof(RubrumAbpImageStoringDomainModule))]
public class RubrumAbpImageStoringTestBaseModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<RubrumAbpImageStoringTestBaseModule>();
        });

        Configure<AbpBlobStoringOptions>(options =>
        {
            options.Containers.ConfigureDefault(container =>
            {
                container.IsMultiTenant = false;
                container.UseFileSystem(fileSystem =>
                {
                    fileSystem.BasePath = Path.Combine(AppContext.BaseDirectory, "data");
                });
            });
        });

        context.Services.AddAlwaysAllowAuthorization();
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        SeedTestData(context);
    }

    private static void SeedTestData(ApplicationInitializationContext context)
    {
        AsyncHelper.RunSync(async () =>
        {
            using var scope = context.ServiceProvider.CreateScope();
            await scope.ServiceProvider
                .GetRequiredService<IDataSeeder>()
                .SeedAsync();
        });
    }
}
