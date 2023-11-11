using Volo.Abp.Application;
using Volo.Abp.Auditing;
using Volo.Abp.ExceptionHandling;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Graphql;

[DependsOn(typeof(AbpDddApplicationContractsModule))]
[DependsOn(typeof(AbpAuditingContractsModule))]
[DependsOn(typeof(AbpExceptionHandlingModule))]
public class RubrumAbpGraphqlContractsModule : AbpModule
{
}