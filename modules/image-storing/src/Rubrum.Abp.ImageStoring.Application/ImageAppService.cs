using Rubrum.Abp.ImageStoring.Mapper.Interfaces;
using Rubrum.Abp.ImageStoring.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Volo.Abp.Threading;

namespace Rubrum.Abp.ImageStoring;

public class ImageAppService(
    IImageContainer imageContainer,
    IImageMapper mapper,
    ICancellationTokenProvider cancellationTokenProvider)
    : ApplicationService, IImageAppService
{
    public async Task<IRemoteStreamContent?> DownloadAsync(Guid id)
    {
        var cancellationToken = cancellationTokenProvider.Token;

        var file = await imageContainer.GetOrNullAsync(id, cancellationToken);

        return file is null
            ? null
            : new RemoteStreamContent(file.Stream, file.Information.SystemFileName, "image/webp");
    }

    public async Task UploadAsync(Guid id, IRemoteStreamContent file)
    {
        await CheckPolicyAsync(ImageStoringPermissions.Images.Upload);

        var cancellationToken = cancellationTokenProvider.Token;

        await imageContainer.UpdateAsync(id, file.GetStream(), cancellationToken);
    }

    public async Task<ImageInformationDto> UploadAsync(UploadImageInput input)
    {
        await CheckPolicyAsync(ImageStoringPermissions.Images.Upload);

        var cancellationToken = cancellationTokenProvider.Token;

        var id = GuidGenerator.Create();
        var bytes = await input.Content.GetStream().GetAllBytesAsync(cancellationToken);
        var file = new ImageFile(id, bytes, input.Content.FileName, input.Tag, input.IsDisposable);
        await imageContainer.CreateAsync(file, cancellationToken);

        return mapper.Map(file);
    }

    public async Task<ListResultDto<ImageInformationDto>> UploadAsync(UploadImagesInput input)
    {
        await CheckPolicyAsync(ImageStoringPermissions.Images.Upload);

        var cancellationToken = cancellationTokenProvider.Token;
        var result = new List<ImageInformationDto>();

        foreach (var content in input.Contents)
        {
            var id = GuidGenerator.Create();
            var bytes = await content.GetStream().GetAllBytesAsync(cancellationToken);
            var file = new ImageFile(id, bytes, content.FileName, input.Tag, input.IsDisposable);
            await imageContainer.CreateAsync(file, cancellationToken);

            result.Add(mapper.Map(file));
        }

        return new ListResultDto<ImageInformationDto>(result);
    }

    public async Task ChangeTagAsync(ChangeTagInput input)
    {
        await CheckPolicyAsync(ImageStoringPermissions.Images.Upload);

        var cancellationToken = cancellationTokenProvider.Token;

        foreach (var id in input.Ids)
        {
            await imageContainer.UpdateTagAsync(id, input.Tag, cancellationToken);
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        await CheckPolicyAsync(ImageStoringPermissions.Images.Delete);

        var cancellationToken = cancellationTokenProvider.Token;

        await imageContainer.DeleteAsync(id, cancellationToken);
    }

    public async Task DeleteByTagAsync(string tag)
    {
        await CheckPolicyAsync(ImageStoringPermissions.Images.Delete);

        var cancellationToken = cancellationTokenProvider.Token;

        await imageContainer.DeleteByTagAsync(tag, cancellationToken);
    }
}
