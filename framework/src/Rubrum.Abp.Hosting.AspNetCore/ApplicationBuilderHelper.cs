using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Hosting;

public static class ApplicationBuilderHelper
{
    public static async Task<WebApplication> BuildApplicationAsync<TModule>(
        string[] args,
        Action<WebApplicationBuilder>? config = null)
        where TModule : IAbpModule
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host
            .AddAppSettingsSecretsJson()
            .UseAutofac()
            .UseSerilog();

        config?.Invoke(builder);

        await builder.AddApplicationAsync<TModule>();

        return builder.Build();
    }
}
