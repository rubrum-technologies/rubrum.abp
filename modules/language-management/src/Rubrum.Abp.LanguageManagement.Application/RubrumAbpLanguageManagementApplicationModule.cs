using Volo.Abp.Application;
using Volo.Abp.FluentValidation;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.LanguageManagement;

[DependsOn(typeof(AbpDddApplicationModule))]
[DependsOn(typeof(AbpFluentValidationModule))]
[DependsOn(typeof(RubrumAbpLanguageManagementApplicationContractsModule))]
[DependsOn(typeof(RubrumAbpLanguageManagementDomainModule))]
public class RubrumAbpLanguageManagementApplicationModule : AbpModule
{
}
