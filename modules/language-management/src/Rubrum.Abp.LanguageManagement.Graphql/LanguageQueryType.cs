using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.LanguageManagement;

public class LanguageQueryType : EntityQueryType<LanguageDto, string, ILanguageGraphqlService>
{
    protected override string TypeName => LanguageConstants.TypeName;
    protected override string TypeNameSingular => "Language";
    protected override string TypeNameInPlural => "Languages";
}
