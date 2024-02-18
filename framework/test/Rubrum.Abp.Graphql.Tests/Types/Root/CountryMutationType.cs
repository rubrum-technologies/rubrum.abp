using HotChocolate.Types;
using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Application.Inputs;
using Rubrum.Abp.Graphql.Services.Contracts;

namespace Rubrum.Abp.Graphql.Types.Root;

public class CountryMutationType : ObjectTypeExtension, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.EntityMutation<CountryDto, Guid, ICountryGraphqlService, CreateCountryInput, UpdateCountryInput>(
            new EntityMutationOptions
            {
                TypeName = CountryConstants.TypeName,
                TypeNameSingular = "Country",
                IsAuthorize = false
            });
    }
}
