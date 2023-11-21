using Microsoft.Extensions.DependencyInjection;
using Rubrum.Abp.PermissionManagement.HttpApi.Grpc;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Rubrum.Abp.PermissionManagement;

[DependsOn(typeof(AbpPermissionManagementDomainModule))]
public class RubrumAbpPermissionManagementHttpApiGrpcClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        context.Services
            .AddGrpcClient<PermissionDefinitionRecordRepositoryGrpc.PermissionDefinitionRecordRepositoryGrpcClient>(
                (_, options) =>
                {
                    options.Address = new Uri(configuration["RemoteServices:Administration:GrpcUrl"]!);
                });

        context.Services
            .AddGrpcClient<PermissionGrantRepositoryGrpc.PermissionGrantRepositoryGrpcClient>(
                (_, options) =>
                {
                    options.Address = new Uri(configuration["RemoteServices:Administration:GrpcUrl"]!);
                });

        context.Services
            .AddGrpcClient<PermissionGroupDefinitionRecordRepositoryGrpc.
                PermissionGroupDefinitionRecordRepositoryGrpcClient>(
                (_, options) =>
                {
                    options.Address = new Uri(configuration["RemoteServices:Administration:GrpcUrl"]!);
                });
    }
}
