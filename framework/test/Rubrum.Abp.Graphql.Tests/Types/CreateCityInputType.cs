using HotChocolate.Types;
using Rubrum.Abp.Graphql.Application.Inputs;

namespace Rubrum.Abp.Graphql.Types;

public class CreateCityInputType : InputObjectType<CreateCityInput>, IGraphqlType
{
    protected override void Configure(IInputObjectTypeDescriptor<CreateCityInput> descriptor)
    {
        descriptor
            .Field(x => x.CountryId)
            .ID();
    }
}