using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.Testing;

namespace Rubrum.Abp.Keycloak;

public class RubrumAbpKeycloakTestBase<TModule> : AbpIntegratedTest<TModule>
    where TModule : IAbpModule
{
    protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
    {
        options.UseAutofac();
    }
}
