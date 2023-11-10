using Volo.Abp;
using Volo.Abp.Testing;

namespace Rubrum.Abp.Graphql;

public class RubrumAbpGraphqlTestBase : AbpIntegratedTest<RubrumAbpGraphqlTestModule>
{
    protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
    {
        options.UseAutofac();
    }
}