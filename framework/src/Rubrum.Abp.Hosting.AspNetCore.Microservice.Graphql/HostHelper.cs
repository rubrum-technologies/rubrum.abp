using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Rubrum.Abp.Graphql.Extensions;
using Serilog;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Hosting;

public static class HostHelper
{
    public static async Task<int> RunServerAsync<TGenerationModule, TModule>(
        string[] args,
        Action<WebApplicationBuilder>? config = null)
        where TGenerationModule : AbpModule
        where TModule : AbpModule
    {
        var assemblyName = Assembly.GetAssembly(typeof(TModule))?.GetName().Name;

        SerilogConfigurationHelper.Configure(assemblyName);

        try
        {
            Log.Information("Starting {AssemblyName}", assemblyName);

            WebApplication app;

            if (args.IsGraphQlCommand())
            {
                app = await ApplicationBuilderHelper.BuildApplicationAsync<TGenerationModule>(args, config);
            }
            else
            {
                app = await ApplicationBuilderHelper.BuildApplicationAsync<TModule>(args, config);
            }

            await app.InitializeApplicationAsync();
            await app.RunWithGraphQLCommandsAsync(args);

            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "{AssemblyName} terminated unexpectedly!", assemblyName);
            return 1;
        }
        finally
        {
            await Log.CloseAndFlushAsync();
        }
    }
}
