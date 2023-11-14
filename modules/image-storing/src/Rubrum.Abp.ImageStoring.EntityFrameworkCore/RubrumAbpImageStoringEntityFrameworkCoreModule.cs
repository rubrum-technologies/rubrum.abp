using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.ImageStoring.EntityFrameworkCore;

[DependsOn(typeof(AbpEntityFrameworkCoreModule))]
[DependsOn(typeof(RubrumAbpImageStoringDomainModule))]
public class RubrumAbpImageStoringEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ImageStoringDbContext>(options =>
        {
            options.AddRepository<ImageInformation, EfCoreImageInformationRepository>();
        });
    }
}
