using HotChocolate.Types;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Rubrum.Abp.EntityFrameworkCore.HumanFriendly;
using Rubrum.Abp.Graphql.Extensions;
using Rubrum.Abp.Graphql.HumanFriendly.EntityFrameworkCore;
using Rubrum.Abp.HumanFriendly;
using Volo.Abp;
using Volo.Abp.Authorization;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;
using Volo.Abp.Uow;

namespace Rubrum.Abp.Graphql.HumanFriendly;

[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(AbpAuthorizationModule))]
[DependsOn(typeof(AbpDataModule))]
[DependsOn(typeof(AbpEntityFrameworkCoreSqliteModule))]
[DependsOn(typeof(RubrumAbpGraphqlModule))]
[DependsOn(typeof(RubrumAbpEntityFrameworkCoreHumanFriendlyModule))]
[DependsOn(typeof(RubrumAbpDddApplicationContractsHumanFriendlyModule))]
[DependsOn(typeof(RubrumAbpGraphqlHumanFriendlyModule))]
[DependsOn(typeof(RubrumAbpGraphqlTestBaseModule))]
public class RubrumAbpGraphqlHumanFriendlyTestModule : AbpModule
{
    private SqliteConnection? _sqliteConnection;

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
            .ModifyRequestOptions(options =>
            {
                options.IncludeExceptionDetails = true;
            })
            .AddFakeAuthorizationHandler();
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
}
