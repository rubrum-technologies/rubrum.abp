using Rubrum.Abp.Graphql.Services;

namespace Rubrum.Abp.LanguageManagement;

public interface ILanguageGraphqlService :
    ILanguageAppService,
    IReadOnlyGraphqlService<LanguageDto, string>
{
}
