using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Rubrum.Abp.LanguageManagement;

public interface ILanguageAppService : 
    ICreateUpdateAppService<LanguageDto, string, CreateLanguageInput, UpdateLanguageInput>,
    IDeleteAppService<string>
{
    Task<LanguageDto> GetAsync(string id);
    Task<ListResultDto<LanguageDto>> GetListAsync();
}
