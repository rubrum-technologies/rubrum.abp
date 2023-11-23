using HotChocolate.Types;
using Rubrum.Abp.Graphql.Application.Inputs;
using Rubrum.Abp.Graphql.Types.Ddd;

namespace Rubrum.Abp.Graphql.Types;

public class UpdateCountryInputType : InputObjectType<UpdateCountryInput>, IGraphqlType
{
    protected override void Configure(IInputObjectTypeDescriptor<UpdateCountryInput> descriptor)
    {
        descriptor.AddFieldKey<UpdateCountryInput, Guid>(CountryConstants.TypeName);
    }
}
