﻿using Microsoft.AspNetCore.Mvc;
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
    public async Task<IRemoteStreamContent?> DownloadAsync(Guid id)
    {
        return await _service.DownloadAsync(id);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task UploadAsync(Guid id, IRemoteStreamContent file)
    {
        await _service.UploadAsync(id, file);
    }

    [HttpPost]
    public async Task<ImageInformationDto> UploadAsync(UploadImageInput input)
    {
        return await _service.UploadAsync(input);
    }

    [HttpPost]
    [Route("many")]
    public async Task<ListResultDto<ImageInformationDto>> UploadAsync(UploadImagesInput input)
    {
        return await _service.UploadAsync(input);
    }
}
