using Volo.Abp;
using Volo.Abp.Testing;

namespace Rubrum.Abp.Keycloak;

public class RubrumAbpKeycloakTestBase : AbpIntegratedTest<RubrumAbpKeycloakTestModule>
{
    protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
    {
        options.UseAutofac();
    }
}
