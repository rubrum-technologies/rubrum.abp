using HotChocolate.Types;
using Rubrum.Abp.Graphql.Application.Inputs;

namespace Rubrum.Abp.Graphql.Types;

public class UpdateCityInputType : InputObjectType<UpdateCityInput>, IGraphqlType
{
    protected override void Configure(IInputObjectTypeDescriptor<UpdateCityInput> descriptor)
    {
        descriptor.AddFieldKey<UpdateCityInput, int>(CityConstants.TypeName);
        
        descriptor
            .Field(x => x.CountryId)
            .ID(CountryConstants.TypeName);
    }
}