using Rubrum.Abp.PermissionManagement.HttpApi.Grpc;
using Volo.Abp.MultiTenancy;

namespace Rubrum.Abp.PermissionManagement.Grpc;

internal static class MultiTenancySidesExtensions
{
    public static MultiTenancySidesGrpc ToGrpc(this MultiTenancySides obj)
    {
        return obj switch
        {
            MultiTenancySides.Tenant => MultiTenancySidesGrpc.Tenant,
            MultiTenancySides.Host => MultiTenancySidesGrpc.Host,
            MultiTenancySides.Both => MultiTenancySidesGrpc.Both,
            _ => throw new ArgumentOutOfRangeException(nameof(obj), obj, null)
        };
    }

    public static MultiTenancySides ToEntity(this MultiTenancySidesGrpc obj)
    {
        return obj switch
        {
            MultiTenancySidesGrpc.Tenant => MultiTenancySides.Tenant,
            MultiTenancySidesGrpc.Host => MultiTenancySides.Host,
            MultiTenancySidesGrpc.Both => MultiTenancySides.Both,
            _ => throw new ArgumentOutOfRangeException(nameof(obj), obj, null)
        };
    }
}
