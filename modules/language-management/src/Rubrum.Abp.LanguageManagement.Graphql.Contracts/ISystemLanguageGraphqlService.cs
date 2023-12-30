using Rubrum.Abp.Graphql.Services;

namespace Rubrum.Abp.LanguageManagement;

public interface ISystemLanguageGraphqlService :
    ISystemLanguageAppService,
    IReadOnlyGraphqlService<SystemLanguageDto, string>;
