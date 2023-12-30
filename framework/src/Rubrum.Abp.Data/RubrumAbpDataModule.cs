using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Data;

[DependsOn(typeof(AbpDataModule))]
public class RubrumAbpDataModule : AbpModule;
