using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using Volo.Abp.Threading;

namespace Rubrum.Abp.ImageStoring;

public class ImageInformationDeleteHandler(
    IImageBlobContainerFactory imageBlobContainerFactory,
    ICancellationTokenProvider cancellationTokenProvider)
    : ILocalEventHandler<EntityDeletedEventData<ImageInformation>>, ITransientDependency
{
    public async Task HandleEventAsync(EntityDeletedEventData<ImageInformation> eventData)
    {
        var cancellationToken = cancellationTokenProvider.Token;

        var information = eventData.Entity;
        var blobContainer = await imageBlobContainerFactory.CreateAsync(information);

        if (await blobContainer.ExistsAsync(information.SystemFileName, cancellationToken))
        {
            await blobContainer.DeleteAsync(information.SystemFileName, cancellationToken);
        }
    }
}
