using Rubrum.Abp.Data;
using Rubrum.Abp.Imaging;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.ImageStoring;

[DependsOn(typeof(AbpDddDomainModule))]
[DependsOn(typeof(AbpBlobStoringModule))]
[DependsOn(typeof(RubrumAbpDataModule))]
[DependsOn(typeof(RubrumAbpImagingAbstractionsModule))]
[DependsOn(typeof(RubrumAbpImageStoringDomainSharedModule))]
public class RubrumAbpImageStoringDomainModule : AbpModule
{
}
