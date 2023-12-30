using HotChocolate.Data.Filters;
using HotChocolate.Types;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Rubrum.Abp.Graphql.EntityFrameworkCore;
using Rubrum.Abp.Graphql.Extensions;
using Volo.Abp;
using Volo.Abp.Authorization;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.Threading;
using Volo.Abp.Uow;

namespace Rubrum.Abp.Graphql;

[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(AbpAuthorizationModule))]
[DependsOn(typeof(AbpDataModule))]
[DependsOn(typeof(AbpTenantManagementApplicationModule))]
[DependsOn(typeof(AbpTenantManagementEntityFrameworkCoreModule))]
[DependsOn(typeof(AbpEntityFrameworkCoreSqliteModule))]
[DependsOn(typeof(RubrumAbpGraphqlTestBaseModule))]
public class RubrumAbpGraphqlTestModule : AbpModule
{
    private static readonly OneTimeRunner OneTimeRunner = new();
    private SqliteConnection? _sqliteConnection;

    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        OneTimeRunner.Run(ConfigureExtraProperties);
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAlwaysAllowAuthorization();

        context.Services.AddAbpDbContext<GraphqlTestDbContext>(options =>
        {
            options.AddDefaultRepositories();
        });

        ConfigureInMemorySqlite(context.Services);

        var graphql = context.Services.GetGraphql();

        graphql
            .AddQueryType(d => d.Name(OperationTypeNames.Query))
            .AddMutationType(d => d.Name(OperationTypeNames.Mutation))
            .AddConvention<IFilterConvention>(new FilterConventionExtension(descriptor =>
            {
                descriptor.BindRuntimeType<Guid, IdOperationFilterInputType>();
            }))
            .ModifyRequestOptions(options =>
            {
                options.IncludeExceptionDetails = true;
            });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        SeedTestData(context);
    }

    public override void OnApplicationShutdown(ApplicationShutdownContext context)
    {
        _sqliteConnection?.Dispose();
    }

    private static void SeedTestData(ApplicationInitializationContext context)
    {
        AsyncHelper.RunSync(async () =>
        {
            using var scope = context.ServiceProvider.CreateScope();
            await scope.ServiceProvider
                .GetRequiredService<IDataSeeder>()
                .SeedAsync();
        });
    }

    private void ConfigureInMemorySqlite(IServiceCollection services)
    {
        _sqliteConnection = CreateDatabaseAndGetConnection();

        services.Configure<AbpDbContextOptions>(options =>
        {
            options.Configure(context =>
            {
                context.DbContextOptions.UseSqlite(_sqliteConnection);
            });
        });

        Configure<AbpUnitOfWorkDefaultOptions>(options =>
        {
            options.TransactionBehavior = UnitOfWorkTransactionBehavior.Disabled;
        });
    }

    private SqliteConnection CreateDatabaseAndGetConnection()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<GraphqlTestDbContext>()
            .UseSqlite(connection)
            .Options;

        using var context = new GraphqlTestDbContext(options);
        context.GetService<IRelationalDatabaseCreator>().CreateTables();

        return connection;
    }

    private void ConfigureExtraProperties()
    {
        ObjectExtensionManager.Instance
            .Modules()
            .ConfigureTenantManagement(m =>
            {
                m.ConfigureTenant(config =>
                {
                    config.AddOrUpdateProperty<string>("Test");
                });
            });

        ObjectExtensionManager.Instance
            .AddOrUpdateProperty<TenantDto, string>("Test");
    }
}
