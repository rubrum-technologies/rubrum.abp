using HotChocolate.Resolvers;
using Volo.Abp;

namespace Rubrum.Abp.Graphql.Data;

internal class AnyMiddleware<T>
    where T : class
{
    private readonly FieldDelegate _next;

    public AnyMiddleware(FieldDelegate next)
    {
        _next = Check.NotNull(next, nameof(next));
    }

    public async Task InvokeAsync(IMiddlewareContext context)
    {
        await _next(context).ConfigureAwait(false);
        context.Result = context.Result switch {
            IAsyncEnumerable<T> ae => await ae.AnyAsync(),
            IEnumerable<T> en => await Task.Run(() => en.Any(), context.RequestAborted).ConfigureAwait(false),
            _ => context.Result
        };
    }
}