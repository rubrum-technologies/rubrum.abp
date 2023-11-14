using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Rubrum.Abp.Imaging.MagickNet;

[DependsOn(typeof(AbpTestBaseModule))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(AbpVirtualFileSystemModule))]
[DependsOn(typeof(RubrumAbpImagingMagickNetModule))]
public class RubrumAbpImagingMagickNetTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<RubrumAbpImagingMagickNetTestModule>();
        });
    }
}
