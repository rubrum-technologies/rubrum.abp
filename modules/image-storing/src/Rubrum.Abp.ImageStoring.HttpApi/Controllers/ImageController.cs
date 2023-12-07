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
public class ImageController : AbpControllerBase, IImageAppService
{
    private readonly IImageAppService _service;

    public ImageController(IImageAppService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{id:guid}")]
    public Task<IRemoteStreamContent?> DownloadAsync(Guid id)
    {
        return _service.DownloadAsync(id);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public Task UploadAsync(Guid id, IRemoteStreamContent file)
    {
        return _service.UploadAsync(id, file);
    }

    [HttpPost]
    public Task<ImageInformationDto> UploadAsync([FromForm] UploadImageInput input)
    {
        return _service.UploadAsync(input);
    }

    [HttpPost]
    [Route("many")]
    public Task<ListResultDto<ImageInformationDto>> UploadAsync([FromForm] UploadImagesInput input)
    {
        return _service.UploadAsync(input);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public Task DeleteAsync(Guid id)
    {
        return _service.DeleteAsync(id);
    }
}
