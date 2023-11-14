using Volo.Abp;
using Volo.Abp.Testing;

namespace Rubrum.Abp.Imaging.MagickNet;

public abstract class ImagingMagickNetTestBase : AbpIntegratedTest<RubrumAbpImagingMagickNetTestModule>
{
    protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
    {
        options.UseAutofac();
    }
}
