using Rubrum.Abp.Languages;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace Rubrum.Abp.Translator;

[DependsOn(typeof(AbpThreadingModule))]
[DependsOn(typeof(RubrumAbpLanguagesModule))]
public class RubrumAbpTranslatorAbstractionsModule : AbpModule
{
}
