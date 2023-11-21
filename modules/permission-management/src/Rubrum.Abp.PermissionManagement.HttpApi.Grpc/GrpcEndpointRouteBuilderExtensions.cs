using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Rubrum.Abp.PermissionManagement.Grpc;

namespace Rubrum.Abp.PermissionManagement;

public static class GrpcEndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapPermissionGrpcService(this IEndpointRouteBuilder builder)
    {
        builder.MapGrpcService<PermissionDefinitionRecordRepositoryGrpcService>();
        builder.MapGrpcService<PermissionGrantRepositoryGrpcService>();
        builder.MapGrpcService<PermissionGroupDefinitionRecordRepositoryGrpcService>();

        return builder;
    }
}
