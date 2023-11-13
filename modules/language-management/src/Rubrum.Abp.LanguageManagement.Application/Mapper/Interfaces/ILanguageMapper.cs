using System.Linq.Expressions;
using Mapster;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.LanguageManagement.Mapper.Interfaces;

[Mapper]
public interface ILanguageMapper : ITransientDependency
{
    Expression<Func<Language, LanguageDto>> Expression { get; }
    LanguageDto Map(Language language);
}
