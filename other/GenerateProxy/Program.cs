using GenerateProxy;
using Rubrum.Abp.Hosting;
using Serilog;
using Serilog.Events;

var assemblyName = typeof(Program).Assembly.GetName().Name;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .Enrich.WithProperty("Application", $"{assemblyName}")
    .WriteTo.Async(c => c.Console())
    .CreateLogger();
try
{
    Log.Information("Starting {AssemblyName}", assemblyName);

    var app = await ApplicationBuilderHelper.BuildApplicationAsync<GenerateProxyModule>(args);

    await app.InitializeApplicationAsync();
    await app.RunAsync();

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
