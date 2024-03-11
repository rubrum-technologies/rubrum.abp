using Rubrum.Abp.ImageStoring.Mapper;
using Rubrum.Abp.ImageStoring.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Volo.Abp.Linq;
using Volo.Abp.Threading;

namespace Rubrum.Abp.ImageStoring;

public class ImageStoringAppService(
    IImageInformationRepository repository,
    IAsyncQueryableExecuter asyncExecuter,
    IImageContainer imageContainer,
    IImageInformationMapper mapper,
    ICancellationTokenProvider cancellationTokenProvider)
    : ApplicationService, IImageStoringAppService
{
    public async Task<ImageInformationDto> GetAsync(Guid id)
    {
        var cancellationToken = cancellationTokenProvider.Token;

        var image = await repository.GetAsync(id, true, cancellationToken);

        return mapper.Map(image);
    }

    public async Task<ListResultDto<ImageInformationDto>> GetByTagAsync(string tag)
    {
        var cancellationToken = cancellationTokenProvider.Token;

        var query = (await repository.GetQueryableAsync())
            .Where(x => x.Tag == tag)
            .Select(mapper.Projection);
        var images = await asyncExecuter.ToListAsync(query, cancellationToken);

        return new ListResultDto<ImageInformationDto>(images);
    }

    public async Task<ListResultDto<ImageInformationDto>> GetListAsync()
    {
        var cancellationToken = cancellationTokenProvider.Token;

        var query = (await repository.GetQueryableAsync()).Select(mapper.Projection);
        var images = await asyncExecuter.ToListAsync(query, cancellationToken);

        return new ListResultDto<ImageInformationDto>(images);
    }

    public async Task<IRemoteStreamContent?> DownloadAsync(Guid id)
    {
        var cancellationToken = cancellationTokenProvider.Token;

        var file = await imageContainer.GetOrNullAsync(id, cancellationToken);

        return file is null
            ? null
            : new RemoteStreamContent(file.Stream, file.Information.FileName, "image/webp");
    }

    public async Task UploadAsync(Guid id, IRemoteStreamContent file)
    {
        await CheckPolicyAsync(ImageStoringPermissions.Images.Upload);

        var cancellationToken = cancellationTokenProvider.Token;

        await imageContainer.ChangeImageAsync(id, file.GetStream(), cancellationToken);
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

    public async Task<ListResultDto<ImageInformationDto>> UploadManyAsync(UploadImagesInput input)
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
            await imageContainer.ChangeTagAsync(id, input.Tag, cancellationToken);
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
