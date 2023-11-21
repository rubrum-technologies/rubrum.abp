using Rubrum.Abp.LanguageManagement.Mapper.Interfaces;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace Rubrum.Abp.LanguageManagement;

public class LanguageAppService : ApplicationService, ILanguageAppService
{
    protected readonly ICancellationTokenProvider CancellationTokenProvider;
    protected readonly LanguageManager Manager;
    protected readonly ILanguageMapper Mapper;
    protected readonly IRepository<Language, string> Repository;

    public LanguageAppService(
        IRepository<Language, string> repository,
        LanguageManager manager,
        ILanguageMapper mapper,
        ICancellationTokenProvider cancellationTokenProvider)
    {
        Repository = repository;
        Manager = manager;
        Mapper = mapper;
        CancellationTokenProvider = cancellationTokenProvider;
    }

    public async Task<LanguageDto> GetAsync(string id)
    {
        var cancellationToken = CancellationTokenProvider.Token;

        var language = await Repository.GetAsync(id, true, cancellationToken);
        return Mapper.Map(language);
    }

    public async Task<ListResultDto<LanguageDto>> GetListAsync()
    {
        var cancellationToken = CancellationTokenProvider.Token;

        var languages = await Repository.GetListAsync(true, cancellationToken);
        return new ListResultDto<LanguageDto>(languages.Select(Mapper.Map).ToList());
    }

    public async Task<LanguageDto> CreateAsync(CreateLanguageInput input)
    {
        var cancellationToken = CancellationTokenProvider.Token;

        var language = await Manager.CreateAsync(input.Code, input.Name);
        input.MapExtraPropertiesTo(language);

        await Repository.InsertAsync(language, true, cancellationToken);

        return Mapper.Map(language);
    }

    public async Task<LanguageDto> UpdateAsync(string id, UpdateLanguageInput input)
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
