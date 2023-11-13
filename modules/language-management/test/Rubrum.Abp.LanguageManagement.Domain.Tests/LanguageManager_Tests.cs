using Shouldly;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Rubrum.Abp.LanguageManagement;

public class LanguageManagerTests : LanguageManagementDomainTestBase
{
    private readonly LanguageManager _manager;
    private readonly IRepository<Language, string> _repository;

    public LanguageManagerTests()
    {
        _manager = GetRequiredService<LanguageManager>();
        _repository = GetRequiredService<IRepository<Language, string>>();
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
            await Assert.ThrowsAsync<LanguageNameAlreadyExistsException>(async () =>
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

            await Assert.ThrowsAsync<LanguageNameAlreadyExistsException>(async () =>
            {
                await _manager.ChangeNameAsync(language, "English");
            });
        });
    }
}
