using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.LanguageManagement;

public class SystemLanguageMutationType : ObjectTypeExtension, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.EntityMutation<SystemLanguageDto, string, ISystemLanguageGraphqlService, CreateSystemLanguageInput,
            UpdateSystemLanguageInput>(SystemLanguageConstants.TypeName, "SystemLanguage");
    }
}
