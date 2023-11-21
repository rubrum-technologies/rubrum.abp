using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace Rubrum.Abp.Hosting;

[DependsOn(typeof(AbpSwashbuckleModule))]
[DependsOn(typeof(AbpAspNetCoreSerilogModule))]
[DependsOn(typeof(RubrumAbpHostingModule))]
public class RubrumAbpHostingAspNetCoreModule : AbpModule
{
}
