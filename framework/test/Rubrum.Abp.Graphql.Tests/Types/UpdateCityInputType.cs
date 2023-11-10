using HotChocolate.Types;
using Rubrum.Abp.Graphql.Application.Inputs;

namespace Rubrum.Abp.Graphql.Types;

public class UpdateCityInputType : InputObjectType<UpdateCityInput>, IGraphqlType
{
    protected override void Configure(IInputObjectTypeDescriptor<UpdateCityInput> descriptor)
    {
        descriptor
            .Field(x => x.Id)
            .ID("City");
        
        descriptor
            .Field(x => x.CountryId)
            .ID();
    }
}