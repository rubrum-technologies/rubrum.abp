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
    [HttpGet]
    [Route("{id}")]
    public async Task<SystemLanguageDto> GetAsync(string id)
    {
        return await service.GetAsync(id);
    }

    [HttpGet]
    public async Task<ListResultDto<SystemLanguageDto>> GetListAsync()
    {
        return await service.GetListAsync();
    }

    [HttpPost]
    public async Task<SystemLanguageDto> CreateAsync(CreateSystemLanguageInput input)
    {
        return await service.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<SystemLanguageDto> UpdateAsync(string id, UpdateSystemLanguageInput input)
    {
        return await service.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task DeleteAsync(string id)
    {
        await service.DeleteAsync(id);
    }
}
