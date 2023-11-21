using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Types.Ddd;
using static Rubrum.Abp.LanguageManagement.LanguageConstants;

namespace Rubrum.Abp.LanguageManagement;

public class UpdateLanguageInputType : InputObjectType<UpdateLanguageInput>, IGraphqlType
{
    protected override void Configure(IInputObjectTypeDescriptor<UpdateLanguageInput> descriptor)
    {
        descriptor
            .UpdateEntity<UpdateLanguageInput, StringType>(TypeName)
            .ExtraProperties();
    }
}
