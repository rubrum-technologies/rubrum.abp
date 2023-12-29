using Rubrum.Abp.LanguageManagement.Mapper.Interfaces;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace Rubrum.Abp.LanguageManagement;

public class SystemLanguageAppService : ApplicationService, ISystemLanguageAppService
{
    public SystemLanguageAppService(
       IRepository<SystemLanguage, string> repository,
       SystemLanguageManager manager,
       ISystemLanguageMapper mapper,
       ICancellationTokenProvider cancellationTokenProvider)
    {
        Repository = repository;
        Manager = manager;
        Mapper = mapper;
        CancellationTokenProvider = cancellationTokenProvider;
    }

    protected SystemLanguageManager Manager { get; }

    protected ISystemLanguageMapper Mapper { get; }

    protected IRepository<SystemLanguage, string> Repository { get; }

    protected ICancellationTokenProvider CancellationTokenProvider { get; }

    public async Task<SystemLanguageDto> GetAsync(string id)
    {
        var cancellationToken = CancellationTokenProvider.Token;

        var language = await Repository.GetAsync(id, true, cancellationToken);
        return Mapper.Map(language);
    }

    public async Task<ListResultDto<SystemLanguageDto>> GetListAsync()
    {
        var cancellationToken = CancellationTokenProvider.Token;

        var languages = await Repository.GetListAsync(true, cancellationToken);
        return new ListResultDto<SystemLanguageDto>(languages.Select(Mapper.Map).ToList());
    }

    public async Task<SystemLanguageDto> CreateAsync(CreateSystemLanguageInput input)
    {
        var cancellationToken = CancellationTokenProvider.Token;

        var language = await Manager.CreateAsync(input.Code, input.Name);
        input.MapExtraPropertiesTo(language);

        await Repository.InsertAsync(language, true, cancellationToken);

        return Mapper.Map(language);
    }

    public async Task<SystemLanguageDto> UpdateAsync(string id, UpdateSystemLanguageInput input)
    {
        var cancellationToken = CancellationTokenProvider.Token;

        var language = await Repository.GetAsync(id, true, cancellationToken);
        input.MapExtraPropertiesTo(language);

        await Manager.ChangeNameAsync(language, input.Name);
        await Repository.UpdateAsync(language, true, cancellationToken);

        return Mapper.Map(language);
    }

    public async Task DeleteAsync(string id)
    {
        var cancellationToken = CancellationTokenProvider.Token;

        var language = await Repository.GetAsync(id, true, cancellationToken);
        await Repository.DeleteAsync(language, true, cancellationToken);
    }
}
