using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Types.Ddd;

namespace Rubrum.Abp.LanguageManagement;

public class CreateLanguageInputType : InputObjectType<CreateLanguageInput>, IGraphqlType
{
    protected override void Configure(IInputObjectTypeDescriptor<CreateLanguageInput> descriptor)
    {
        descriptor.ExtraProperties();
    }
}
