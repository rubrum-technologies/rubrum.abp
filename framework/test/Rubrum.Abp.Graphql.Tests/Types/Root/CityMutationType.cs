using HotChocolate.Types;
using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Application.Inputs;
using Rubrum.Abp.Graphql.Services.Contracts;

namespace Rubrum.Abp.Graphql.Types.Root;

public class CityMutationType : ObjectTypeExtension, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.EntityMutation<CityDto, int, ICityGraphqlService, CreateCityInput, UpdateCityInput>(
            new EntityMutationOptions
            {
                TypeName = "City",
                TypeNameSingular = "City",
                IsAuthorize = false
            });
    }
}
