using Rubrum.Abp.ImageStoring.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Volo.Abp.Threading;

namespace Rubrum.Abp.ImageStoring;

public class ImageAppService : ApplicationService, IImageAppService
{
    private readonly ICancellationTokenProvider _cancellationTokenProvider;
    private readonly IImageContainer _imageContainer;

    public ImageAppService(
        IImageContainer imageContainer,
        ICancellationTokenProvider cancellationTokenProvider)
    {
        _imageContainer = imageContainer;
        _cancellationTokenProvider = cancellationTokenProvider;
    }

    public async Task<IRemoteStreamContent?> DownloadAsync(Guid id)
    {
        var cancellationToken = _cancellationTokenProvider.Token;

        var file = await _imageContainer.GetOrNullAsync(id, cancellationToken);

        return file is null
            ? null
            : new RemoteStreamContent(file.Stream, file.Information.FileName, "image/webp");
    }

    public async Task UploadAsync(Guid id, IRemoteStreamContent file)
    {
        await CheckPolicyAsync(ImageStoringPermissions.Images.Upload);

        var cancellationToken = _cancellationTokenProvider.Token;

        await _imageContainer.UpdateAsync(id, file.GetStream(), cancellationToken);
    }

    public async Task<ImageInformationDto> UploadAsync(UploadImageInput input)
    {
        await CheckPolicyAsync(ImageStoringPermissions.Images.Upload);

        var cancellationToken = _cancellationTokenProvider.Token;

        var id = GuidGenerator.Create();
        var file = new ImageFile(id, input.Content.GetStream(), input.Tag, input.IsDisposable);
        await _imageContainer.CreateAsync(file, cancellationToken);

        return new ImageInformationDto { Id = id };
    }

    public async Task<ListResultDto<ImageInformationDto>> UploadAsync(UploadImagesInput input)
    {
        await CheckPolicyAsync(ImageStoringPermissions.Images.Upload);

        var cancellationToken = _cancellationTokenProvider.Token;
        var result = new List<ImageInformationDto>();

        foreach (var content in input.Contents)
        {
            var id = GuidGenerator.Create();
            var file = new ImageFile(id, content.GetStream(), input.Tag, input.IsDisposable);
            await _imageContainer.CreateAsync(file, cancellationToken);

            result.Add(new ImageInformationDto { Id = id });
        }

        return new ListResultDto<ImageInformationDto>(result);
    }
}
