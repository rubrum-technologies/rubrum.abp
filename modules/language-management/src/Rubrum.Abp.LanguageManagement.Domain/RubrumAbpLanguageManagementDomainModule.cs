using Rubrum.Abp.Data;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.LanguageManagement;

[DependsOn(typeof(AbpDddDomainModule))]
[DependsOn(typeof(RubrumAbpDataModule))]
[DependsOn(typeof(RubrumAbpLanguageManagementDomainSharedModule))]
public class RubrumAbpLanguageManagementDomainModule : AbpModule
{
    
}
