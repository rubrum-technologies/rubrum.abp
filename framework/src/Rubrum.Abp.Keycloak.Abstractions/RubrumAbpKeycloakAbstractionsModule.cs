using Volo.Abp.Modularity;
using Volo.Abp.Serialization;

namespace Rubrum.Abp.Keycloak;

[DependsOn(typeof(AbpSerializationModule))]
public class RubrumAbpKeycloakAbstractionsModule : AbpModule;
