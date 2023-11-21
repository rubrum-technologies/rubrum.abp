using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Hosting;

[DependsOn(typeof(AbpAutofacModule))]
public class RubrumAbpHostingModule : AbpModule
{
    
}
