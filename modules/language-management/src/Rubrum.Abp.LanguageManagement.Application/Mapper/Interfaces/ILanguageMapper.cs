using System.Linq.Expressions;
using Mapster;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.LanguageManagement.Mapper.Interfaces;

[Mapper]
public interface ILanguageMapper : ITransientDependency
{
    LanguageDto Map(Language language);

    Expression<Func<Language, LanguageDto>> Expression { get; }
}
