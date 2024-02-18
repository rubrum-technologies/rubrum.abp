using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using static Rubrum.Abp.LanguageManagement.LanguageManagementRemoteServiceConstants;

namespace Rubrum.Abp.LanguageManagement.Controllers;

[Area(ModuleName)]
[RemoteService(Name = RemoteServiceName)]
[Route("api/language-management/languages")]
public class SystemLanguageController(ISystemLanguageAppService service) : AbpControllerBase, ISystemLanguageAppService
{
    [Authorize]
    [HttpGet("{id}")]
    public async Task<SystemLanguageDto> GetAsync(string id)
    {
        return await service.GetAsync(id);
    }

    [Authorize]
    [HttpGet]
    public async Task<ListResultDto<SystemLanguageDto>> GetListAsync()
    {
        return await service.GetListAsync();
    }

    [Authorize]
    [HttpPost]
    public async Task<SystemLanguageDto> CreateAsync(CreateSystemLanguageInput input)
    {
        return await service.CreateAsync(input);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<SystemLanguageDto> UpdateAsync(string id, UpdateSystemLanguageInput input)
    {
        return await service.UpdateAsync(id, input);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task DeleteAsync(string id)
    {
        await service.DeleteAsync(id);
    }
}
