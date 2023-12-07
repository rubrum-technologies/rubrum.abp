using Rubrum.Abp.ImageStoring.Mapper.Interfaces;
using Rubrum.Abp.ImageStoring.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Volo.Abp.Threading;

namespace Rubrum.Abp.ImageStoring;

public class ImageAppService : ApplicationService, IImageAppService
{
    private readonly IImageContainer _imageContainer;
    private readonly IImageMapper _mapper;
    private readonly ICancellationTokenProvider _cancellationTokenProvider;

    public ImageAppService(
        IImageContainer imageContainer,
        IImageMapper mapper,
        ICancellationTokenProvider cancellationTokenProvider)
    {
        _imageContainer = imageContainer;
        _mapper = mapper;
        _cancellationTokenProvider = cancellationTokenProvider;
    }

    public async Task<IRemoteStreamContent?> DownloadAsync(Guid id)
    {
        var cancellationToken = _cancellationTokenProvider.Token;

        var file = await _imageContainer.GetOrNullAsync(id, cancellationToken);

        return file is null
            ? null
            : new RemoteStreamContent(file.Stream, file.Information.SystemFileName, "image/webp");
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
        var bytes = await input.Content.GetStream().GetAllBytesAsync(cancellationToken);
        var file = new ImageFile(id, bytes, input.Content.FileName, input.Tag, input.IsDisposable);
        await _imageContainer.CreateAsync(file, cancellationToken);

        return _mapper.Map(file);
    }

    public async Task<ListResultDto<ImageInformationDto>> UploadAsync(UploadImagesInput input)
    {
        await CheckPolicyAsync(ImageStoringPermissions.Images.Upload);

        var cancellationToken = _cancellationTokenProvider.Token;
        var result = new List<ImageInformationDto>();

        foreach (var content in input.Contents)
        {
            var id = GuidGenerator.Create();
            var bytes = await content.GetStream().GetAllBytesAsync(cancellationToken);
            var file = new ImageFile(id, bytes, content.FileName, input.Tag, input.IsDisposable);
            await _imageContainer.CreateAsync(file, cancellationToken);

            result.Add(_mapper.Map(file));
        }

        return new ListResultDto<ImageInformationDto>(result);
    }

    public Task DeleteAsync(Guid id)
    {
        var cancellationToken = _cancellationTokenProvider.Token;

        return _imageContainer.DeleteAsync(id, cancellationToken);
    }
}
