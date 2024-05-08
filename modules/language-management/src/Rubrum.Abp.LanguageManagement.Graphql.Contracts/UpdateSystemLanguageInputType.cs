using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Types.Ddd;
using static Rubrum.Abp.LanguageManagement.SystemLanguageConstants;

namespace Rubrum.Abp.LanguageManagement;

public class UpdateSystemLanguageInputType : InputObjectType<UpdateSystemLanguageInput>, IGraphqlType
{
    protected override void Configure(IInputObjectTypeDescriptor<UpdateSystemLanguageInput> descriptor)
    {
        descriptor.UpdateInput<string>(TypeName);
        descriptor.ExtensibleObject();
    }
}
