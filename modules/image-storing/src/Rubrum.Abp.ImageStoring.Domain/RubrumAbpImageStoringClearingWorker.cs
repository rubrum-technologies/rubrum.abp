using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Linq;
using Volo.Abp.Threading;

namespace Rubrum.Abp.ImageStoring;

public class RubrumAbpImageStoringClearingWorker : AsyncPeriodicBackgroundWorkerBase
{
    public RubrumAbpImageStoringClearingWorker(AbpAsyncTimer timer, IServiceScopeFactory serviceScopeFactory) : base(
        timer,
        serviceScopeFactory)
    {
        timer.Period = 60 * 5;
    }

    protected override async Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
    {
        var serviceProvider = workerContext.ServiceProvider;
        var cancellationToken = workerContext.CancellationToken;

        var cancellationTokenProvider = serviceProvider.GetRequiredService<ICancellationTokenProvider>();
        var options = serviceProvider.GetRequiredService<IOptions<RubrumAbpImageStoringOptions>>().Value;
        var repository = serviceProvider.GetRequiredService<IImageInformationRepository>();
        var asyncExecuter = serviceProvider.GetRequiredService<IAsyncQueryableExecuter>();
        var imageContainer = serviceProvider.GetRequiredService<IImageContainer>();
        var dateTime = DateTime.Now.AddSeconds(-options.Lifetime);

        using (cancellationTokenProvider.Use(cancellationToken))
        {
            var query = (await repository.GetQueryableAsync())
                .Where(x => x.IsDisposable == true && x.CreationTime < dateTime)
                .Select(x => x.Id);

            foreach (var id in await asyncExecuter.ToListAsync(query, cancellationToken))
            {
                await imageContainer.DeleteAsync(id, cancellationToken);
            }
        }
    }
}
