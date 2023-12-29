using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.LanguageManagement;

public class SystemLanguageQueryType : EntityQueryType<SystemLanguageDto, string, ISystemLanguageGraphqlService>
{
    protected override string TypeName => SystemLanguageConstants.TypeName;

    protected override string TypeNameSingular => "SystemLanguage";

    protected override string TypeNameInPlural => "SystemLanguages";

    protected override bool IsAddFieldByAll => true;
}
