using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Rubrum.Abp.LanguageManagement;

public interface ISystemLanguageAppService :
    ICreateUpdateAppService<SystemLanguageDto, string, CreateSystemLanguageInput, UpdateSystemLanguageInput>,
    IDeleteAppService<string>
{
    Task<SystemLanguageDto> GetAsync(string id);

    Task<ListResultDto<SystemLanguageDto>> GetListAsync();
}
