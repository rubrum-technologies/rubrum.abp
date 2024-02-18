using HotChocolate.Authorization;
using HotChocolate.Resolvers;

namespace Rubrum.Abp.Graphql;

public class FakeAuthorizationHandler : IAuthorizationHandler
{
    public ValueTask<AuthorizeResult> AuthorizeAsync(
        IMiddlewareContext context,
        AuthorizeDirective directive,
        CancellationToken cancellationToken = default)
    {
        return ValueTask.FromResult(AuthorizeResult.Allowed);
    }

    public ValueTask<AuthorizeResult> AuthorizeAsync(
        AuthorizationContext context,
        IReadOnlyList<AuthorizeDirective> directives,
        CancellationToken cancellationToken = default)
    {
        return ValueTask.FromResult(AuthorizeResult.Allowed);
    }
}
