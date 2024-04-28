using Shouldly;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Rubrum.Abp.LanguageManagement;

public sealed class SystemLanguageManagerTests : LanguageManagementDomainTestBase
{
    private readonly SystemLanguageManager _manager;
    private readonly IRepository<SystemLanguage, string> _repository;

    public SystemLanguageManagerTests()
    {
        _manager = GetRequiredService<SystemLanguageManager>();
        _repository = GetRequiredService<IRepository<SystemLanguage, string>>();
    }

    [Fact]
    public async Task CreateAsync()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var language = await _manager.CreateAsync("test-id", "test-name");
            language.Id.ShouldBe("test-id");
            language.Name.ShouldBe("test-name");
        });
    }

    [Fact]
    public async Task Create_Name_Can_Not_Duplicate()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            await Assert.ThrowsAsync<SystemLanguageNameAlreadyExistsException>(async () =>
            {
                await _manager.CreateAsync("ru", "Русский");
            });
        });
    }

    [Fact]
    public async Task ChangeNameAsync()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var language = await _repository.GetAsync("gu");
            language.ShouldNotBeNull();

            await _manager.ChangeNameAsync(language, "Test");

            language.Name.ShouldBe("Test");
        });
    }

    [Fact]
    public async Task ChangeName_Name_Can_Not_Duplicate()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var language = await _repository.GetAsync("gu");
            language.ShouldNotBeNull();

            await Assert.ThrowsAsync<SystemLanguageNameAlreadyExistsException>(async () =>
            {
                await _manager.ChangeNameAsync(language, "English");
            });
        });
    }
}
