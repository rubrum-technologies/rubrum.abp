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
public class ImageController(IImageAppService service) : AbpControllerBase, IImageAppService
{
    [HttpGet("{id:guid}")]
    public Task<IRemoteStreamContent?> DownloadAsync(Guid id)
    {
        return service.DownloadAsync(id);
    }

    [Authorize]
    [HttpPut]
    [Route("{id:guid}")]
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
    [HttpPost]
    [Route("many")]
    public Task<ListResultDto<ImageInformationDto>> UploadAsync([FromForm] UploadImagesInput input)
    {
        return service.UploadAsync(input);
    }

    [Authorize]
    [HttpPut]
    [Route("change-tag")]
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
