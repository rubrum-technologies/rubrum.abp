using Volo.Abp.Application;
using Volo.Abp.FluentValidation;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Keycloak;

[DependsOn(typeof(AbpDddApplicationModule))]
[DependsOn(typeof(AbpFluentValidationModule))]
[DependsOn(typeof(RubrumAbpKeycloakApplicationContractsModule))]
[DependsOn(typeof(RubrumAbpKeycloakDomainModule))]
public class RubrumAbpKeycloakApplicationModule : AbpModule;
