using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace Rubrum.Abp.ImageStoring;

public interface IImageAppService : IApplicationService
{
    Task<IRemoteStreamContent?> DownloadAsync(Guid id);
    Task UploadAsync(Guid id, IRemoteStreamContent file);
    Task<ImageInformationDto> UploadAsync(IRemoteStreamContent file, UploadImageInput input);
}
