using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Hosting;

public static class JwtBearerConfigurationHelper
{
    public static void Configure(
        ServiceConfigurationContext context,
        string audience)
    {
        var configuration = context.Services.GetConfiguration();

        var authority = configuration["AuthServer:Authority"]!;
        var metadataAddress = configuration["AuthServer:MetadataAddress"];
        var requireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);

        var validIssuers = new List<string> { authority };

        if (!string.IsNullOrWhiteSpace(metadataAddress))
        {
            validIssuers.Add(metadataAddress);
        }

        context.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = authority;
                options.RequireHttpsMetadata = requireHttpsMetadata;
                options.Audience = audience;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuers = validIssuers,
                    SignatureValidator = (token, _) =>
                    {
                        var jwt = new Microsoft.IdentityModel.JsonWebTokens.JsonWebToken(token);
                        return jwt;
                    }
                };
            });
    }
}
