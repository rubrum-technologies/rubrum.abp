using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace Rubrum.Abp.ImageStoring;

public interface IImageAppService : IApplicationService
{
    Task<ImageInformationDto> GetAsync(Guid id);

    Task<ListResultDto<ImageInformationDto>> GetByTagAsync(string tag);

    Task<ListResultDto<ImageInformationDto>> GetListAsync();

    Task<IRemoteStreamContent?> DownloadAsync(Guid id);

    Task UploadAsync(Guid id, IRemoteStreamContent file);

    Task<ImageInformationDto> UploadAsync(UploadImageInput input);

    Task<ListResultDto<ImageInformationDto>> UploadAsync(UploadImagesInput input);

    Task ChangeTagAsync(ChangeTagInput input);

    Task DeleteAsync(Guid id);

    Task DeleteByTagAsync(string tag);
}
