using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using static Rubrum.Abp.LanguageManagement.LanguageConstants;

namespace Rubrum.Abp.LanguageManagement;

public class UpdateLanguageInputType : InputObjectType<UpdateLanguageInput>, IGraphqlType
{
    protected override void Configure(IInputObjectTypeDescriptor<UpdateLanguageInput> descriptor)
    {
        descriptor.AddFieldKey<UpdateLanguageInput, StringType>(TypeName);
    }
}
