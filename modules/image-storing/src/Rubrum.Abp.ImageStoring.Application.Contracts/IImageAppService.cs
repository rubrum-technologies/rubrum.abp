using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace Rubrum.Abp.ImageStoring;

public interface IImageAppService : IApplicationService
{
    Task<IRemoteStreamContent?> DownloadAsync(Guid id);

    Task UploadAsync(Guid id, IRemoteStreamContent file);

    Task<ImageInformationDto> UploadAsync(UploadImageInput input);

    Task<ListResultDto<ImageInformationDto>> UploadAsync(UploadImagesInput input);

    Task ChangeTagAsync(ChangeTagInput input);

    Task DeleteAsync(Guid id);

    Task DeleteByTagAsync(string tag);
}
