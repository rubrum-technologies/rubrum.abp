using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Volo.Abp.PermissionManagement;

namespace Rubrum.Abp.PermissionManagement;

public class PermissionGroupDtoType : ObjectType<PermissionGroupDto>, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor<PermissionGroupDto> descriptor)
    {
        descriptor.Name("PermissionGroup");

        descriptor
            .Field(x => x.Name)
            .Type<NonNullType<StringType>>();

        descriptor
            .Field(x => x.DisplayName)
            .Type<NonNullType<StringType>>();

        descriptor
            .Field(x => x.DisplayNameKey)
            .Type<NonNullType<StringType>>();

        descriptor
            .Field(x => x.DisplayNameResource)
            .Type<NonNullType<StringType>>();

        descriptor
            .Field(x => x.Permissions)
            .UseFiltering()
            .Type<NonNullType<ListType<NonNullType<PermissionGrantInfoDtoType>>>>();
    }
}
