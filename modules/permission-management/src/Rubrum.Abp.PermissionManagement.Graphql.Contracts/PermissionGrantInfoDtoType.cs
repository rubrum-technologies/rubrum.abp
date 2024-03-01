using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Volo.Abp.PermissionManagement;

namespace Rubrum.Abp.PermissionManagement;

public class PermissionGrantInfoDtoType : ObjectType<PermissionGrantInfoDto>, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor<PermissionGrantInfoDto> descriptor)
    {
        descriptor.Name("PermissionGrantInfo");

        descriptor
            .Field(x => x.Name)
            .Type<NonNullType<StringType>>();

        descriptor
            .Field(x => x.DisplayName)
            .Type<NonNullType<StringType>>();

        descriptor
            .Field(x => x.ParentName)
            .Type<NonNullType<StringType>>();

        descriptor
            .Field(x => x.IsGranted)
            .Type<NonNullType<BooleanType>>();

        descriptor
            .Field(x => x.AllowedProviders)
            .UseFiltering()
            .Type<NonNullType<ListType<NonNullType<StringType>>>>();

        descriptor
            .Field(x => x.GrantedProviders)
            .UseFiltering()
            .Type<NonNullType<ListType<NonNullType<ProviderInfoDtoType>>>>();
    }
}
