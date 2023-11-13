using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.LanguageManagement.EntityFrameworkCore;

[DependsOn(typeof(AbpEntityFrameworkCoreModule))]
[DependsOn(typeof(RubrumAbpLanguageManagementDomainModule))]
public class RubrumAbpLanguageManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<LanguageManagementDbContext>(options =>
        {
            options.AddDefaultRepositories<ILanguageManagementDbContext>();
        });
    }
}
