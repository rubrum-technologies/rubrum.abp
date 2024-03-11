using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Content;
using static Rubrum.Abp.ImageStoring.ImageStoringRemoteServiceConstants;

namespace Rubrum.Abp.ImageStoring.Controllers;

[Controller]
[RemoteService(Name = RemoteServiceName)]
[Area(ModuleName)]
[Route("api/image-storing/images")]
public class ImageStoringController(IImageStoringAppService service) : AbpControllerBase, IImageStoringAppService
{
    [Authorize]
    [HttpGet("{id:guid}")]
    public Task<ImageInformationDto> GetAsync(Guid id)
    {
        return service.GetAsync(id);
    }

    [Authorize]
    [HttpGet("by-tag/{tag}")]
    public Task<ListResultDto<ImageInformationDto>> GetByTagAsync(string tag)
    {
        return service.GetByTagAsync(tag);
    }

    [Authorize]
    [HttpGet]
    public Task<ListResultDto<ImageInformationDto>> GetListAsync()
    {
        return service.GetListAsync();
    }

    [ResponseCache(Duration = 86400 * 7, Location = ResponseCacheLocation.Client)]
    [HttpGet("download/{id:guid}")]
    public Task<IRemoteStreamContent?> DownloadAsync(Guid id)
    {
        return service.DownloadAsync(id);
    }

    [Authorize]
    [HttpPut("{id:guid}")]
    public Task UploadAsync(Guid id, IRemoteStreamContent file)
    {
        return service.UploadAsync(id, file);
    }

    [Authorize]
    [HttpPost]
    public Task<ImageInformationDto> UploadAsync([FromForm] UploadImageInput input)
    {
        return service.UploadAsync(input);
    }

    [Authorize]
    [HttpPost("many")]
    public Task<ListResultDto<ImageInformationDto>> UploadManyAsync([FromForm] UploadImagesInput input)
    {
        return service.UploadManyAsync(input);
    }

    [Authorize]
    [HttpPut("change-tag")]
    public Task ChangeTagAsync(ChangeTagInput input)
    {
        return service.ChangeTagAsync(input);
    }

    [Authorize]
    [HttpDelete("{id:guid}")]
    public Task DeleteAsync(Guid id)
    {
        return service.DeleteAsync(id);
    }

    [Authorize]
    [HttpDelete("tag/{tag}")]
    public Task DeleteByTagAsync(string tag)
    {
        return service.DeleteByTagAsync(tag);
    }
}
