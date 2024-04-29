using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Caching;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.Serialization;

namespace Rubrum.Abp.Translator;

[DependsOn(typeof(AbpSerializationModule))]
[DependsOn(typeof(AbpHttpClientModule))]
[DependsOn(typeof(AbpCachingModule))]
[DependsOn(typeof(RubrumAbpTranslatorAbstractionsModule))]
public class RubrumAbpTranslatorLibreTranslateModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        Configure<LibreTranslateOptions>(options => configuration.GetSection("libreTranslate").Bind(options));
    }
}
