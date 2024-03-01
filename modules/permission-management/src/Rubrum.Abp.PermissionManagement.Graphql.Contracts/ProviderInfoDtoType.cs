using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Volo.Abp.PermissionManagement;

namespace Rubrum.Abp.PermissionManagement;

public class ProviderInfoDtoType : ObjectType<ProviderInfoDto>, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor<ProviderInfoDto> descriptor)
    {
        descriptor.Name("PermissionProviderInfo");

        descriptor
            .Field(x => x.ProviderName)
            .Type<NonNullType<StringType>>();

        descriptor
            .Field(x => x.ProviderKey)
            .Type<NonNullType<StringType>>();
    }
}
