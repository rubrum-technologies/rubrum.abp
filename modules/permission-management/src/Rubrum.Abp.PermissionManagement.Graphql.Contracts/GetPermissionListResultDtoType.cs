using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Volo.Abp.PermissionManagement;

namespace Rubrum.Abp.PermissionManagement;

public class GetPermissionListResultDtoType : ObjectType<GetPermissionListResultDto>, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor<GetPermissionListResultDto> descriptor)
    {
        descriptor.Name("PermissionList");

        descriptor
            .Field(x => x.EntityDisplayName)
            .Type<NonNullType<StringType>>();

        descriptor
            .Field(x => x.Groups)
            .UseFiltering()
            .Type<NonNullType<ListType<NonNullType<PermissionGroupDtoType>>>>();
    }
}
