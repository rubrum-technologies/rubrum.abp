using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Types.Ddd;

namespace Rubrum.Abp.LanguageManagement;

public class CreateSystemLanguageInputType : InputObjectType<CreateSystemLanguageInput>, IGraphqlType
{
    protected override void Configure(IInputObjectTypeDescriptor<CreateSystemLanguageInput> descriptor)
    {
        descriptor.ExtensibleObject();
    }
}
