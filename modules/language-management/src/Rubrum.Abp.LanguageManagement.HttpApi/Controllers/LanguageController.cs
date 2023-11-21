using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using static Rubrum.Abp.LanguageManagement.Permissions.LanguageManagementPermissions.Languages;
using static Rubrum.Abp.LanguageManagement.LanguageManagementRemoteServiceConstants;

namespace Rubrum.Abp.LanguageManagement.Controllers;

[Area(ModuleName)]
[RemoteService(Name = RemoteServiceName)]
[Route("api/language-management/languages")]
public class LanguageController : AbpControllerBase, ILanguageAppService
{
    private readonly ILanguageAppService _service;

    public LanguageController(ILanguageAppService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{id}")]
    [Authorize(Policy = Default)]
    public async Task<LanguageDto> GetAsync(string id)
    {
        return await _service.GetAsync(id);
    }

    [HttpGet]
    [Authorize(Policy = Default)]
    public async Task<ListResultDto<LanguageDto>> GetListAsync()
    {
        return await _service.GetListAsync();
    }

    [HttpPost]
    [Authorize(Policy = Create)]
    public async Task<LanguageDto> CreateAsync(CreateLanguageInput input)
    {
        return await _service.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    [Authorize(Policy = Update)]
    public async Task<LanguageDto> UpdateAsync(string id, UpdateLanguageInput input)
    {
        return await _service.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{id}")]
    [Authorize(Policy = Delete)]
    public async Task DeleteAsync(string id)
    {
        await _service.DeleteAsync(id);
    }
}
