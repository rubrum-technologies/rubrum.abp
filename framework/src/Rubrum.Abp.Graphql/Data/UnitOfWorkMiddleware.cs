using HotChocolate.Resolvers;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Uow;

namespace Rubrum.Abp.Graphql.Data;

public class UnitOfWorkMiddleware<T>
{
    private readonly FieldDelegate _next;

    public UnitOfWorkMiddleware(FieldDelegate next)
    {
        _next = Check.NotNull(next, nameof(next));
    }

    public async Task InvokeAsync(IMiddlewareContext context)
    {
        var unitOfWorkManager = context.Services.GetRequiredService<IUnitOfWorkManager>();
        using var uow = unitOfWorkManager.Begin(true, true);

        await _next(context).ConfigureAwait(false);

        context.Result = context.Result switch
        {
            IAsyncEnumerable<T> ae => await ae.ToListAsync(),
            ICollection<T> => context.Result,
            IEnumerable<T> e => e.ToList(),
            _ => context.Result
        };

        await uow.CompleteAsync(context.RequestAborted);
    }
}
