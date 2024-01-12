using Rubrum.Abp.LanguageManagement.Mapper.Interfaces;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;
using static Rubrum.Abp.LanguageManagement.Permissions.LanguageManagementPermissions.SystemLanguages;

namespace Rubrum.Abp.LanguageManagement;

public class SystemLanguageAppService(
    IRepository<SystemLanguage, string> repository,
    SystemLanguageManager manager,
    ISystemLanguageMapper mapper,
    ICancellationTokenProvider cancellationTokenProvider)
    : ApplicationService, ISystemLanguageAppService
{
    protected SystemLanguageManager Manager => manager;

    protected ISystemLanguageMapper Mapper => mapper;

    protected IRepository<SystemLanguage, string> Repository => repository;

    protected ICancellationTokenProvider CancellationTokenProvider => cancellationTokenProvider;

    public async Task<SystemLanguageDto> GetAsync(string id)
    {
        await CheckPolicyAsync(Default);

        var cancellationToken = CancellationTokenProvider.Token;

        var language = await Repository.GetAsync(id, true, cancellationToken);
        return Mapper.Map(language);
    }

    public async Task<ListResultDto<SystemLanguageDto>> GetListAsync()
    {
        await CheckPolicyAsync(Default);

        var cancellationToken = CancellationTokenProvider.Token;

        var languages = await Repository.GetListAsync(true, cancellationToken);
        return new ListResultDto<SystemLanguageDto>(languages.Select(Mapper.Map).ToList());
    }

    public async Task<SystemLanguageDto> CreateAsync(CreateSystemLanguageInput input)
    {
        await CheckPolicyAsync(Create);

        var cancellationToken = CancellationTokenProvider.Token;

        var language = await Manager.CreateAsync(input.Code, input.Name);
        input.MapExtraPropertiesTo(language);

        await Repository.InsertAsync(language, true, cancellationToken);

        return Mapper.Map(language);
    }

    public async Task<SystemLanguageDto> UpdateAsync(string id, UpdateSystemLanguageInput input)
    {
        await CheckPolicyAsync(Update);

        var cancellationToken = CancellationTokenProvider.Token;

        var language = await Repository.GetAsync(id, true, cancellationToken);
        input.MapExtraPropertiesTo(language);

        await Manager.ChangeNameAsync(language, input.Name);
        await Repository.UpdateAsync(language, true, cancellationToken);

        return Mapper.Map(language);
    }

    public async Task DeleteAsync(string id)
    {
        await CheckPolicyAsync(Delete);

        var cancellationToken = CancellationTokenProvider.Token;

        var language = await Repository.GetAsync(id, true, cancellationToken);
        await Repository.DeleteAsync(language, true, cancellationToken);
    }
}
