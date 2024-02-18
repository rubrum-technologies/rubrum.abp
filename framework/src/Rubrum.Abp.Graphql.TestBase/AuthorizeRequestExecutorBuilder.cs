using HotChocolate.Authorization;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Rubrum.Abp.Graphql;

public static class AuthorizeRequestExecutorBuilder
{
    public static IRequestExecutorBuilder AddFakeAuthorizationHandler(this IRequestExecutorBuilder builder)
    {
        builder.Services.RemoveAll<IAuthorizationHandler>();
        builder.Services.AddScoped<IAuthorizationHandler, FakeAuthorizationHandler>();

        return builder;
    }
}
