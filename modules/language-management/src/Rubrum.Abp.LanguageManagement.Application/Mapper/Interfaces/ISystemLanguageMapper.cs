using System.Linq.Expressions;
using Mapster;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.LanguageManagement.Mapper.Interfaces;

[Mapper]
public interface ISystemLanguageMapper : ITransientDependency
{
    Expression<Func<SystemLanguage, SystemLanguageDto>> Expression { get; }

    SystemLanguageDto Map(SystemLanguage language);
}
