using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.LanguageManagement;

public class SystemLanguageQueryType : ObjectTypeExtension, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.EntityQuery<SystemLanguageDto, string>(
            SystemLanguageConstants.TypeName,
            "SystemLanguage",
            "SystemLanguages",
            true);
    }
}
