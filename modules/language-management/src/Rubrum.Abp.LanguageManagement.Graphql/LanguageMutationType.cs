using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.LanguageManagement;

public class LanguageMutationType :
    EntityMutationType<LanguageDto, string, ILanguageGraphqlService, CreateLanguageInput, UpdateLanguageInput>
{
    protected override string TypeName => LanguageConstants.TypeName;
    protected override string TypeNameSingular => "Language";
    protected override string TypeNameInPlural => "Languages";
}
