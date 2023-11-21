using Microsoft.AspNetCore.Builder;

namespace Rubrum.Abp.Hosting;

public static class HealthCheckApplicationBuilderExtensions
{
    public static IApplicationBuilder UseHealthChecks(this IApplicationBuilder app)
    {
        return app.UseHealthChecks("/health");
    }
}
