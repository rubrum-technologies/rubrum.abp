using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace Rubrum.Abp.Translator;

[DependsOn(typeof(AbpThreadingModule))]
public class RubrumAbpTranslatorAbstractionsModule : AbpModule
{
}
