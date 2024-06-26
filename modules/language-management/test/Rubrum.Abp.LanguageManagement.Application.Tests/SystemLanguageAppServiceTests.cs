﻿using Shouldly;
using Xunit;

namespace Rubrum.Abp.LanguageManagement;

public sealed class SystemLanguageAppServiceTests : LanguageManagementApplicationTestBase
{
    private readonly ISystemLanguageAppService _service;

    public SystemLanguageAppServiceTests()
    {
        _service = GetRequiredService<ISystemLanguageAppService>();
    }

    [Fact]
    public async Task GetAsync()
    {
        var languageInDb = UsingDbContext(db => db.Languages.First());
        var language = await _service.GetAsync(languageInDb.Id);
        language.Name.ShouldBe(languageInDb.Name);
    }

    [Fact]
    public async Task GetListAsync()
    {
        var result = await _service.GetListAsync();
        result.Items.Count.ShouldBeGreaterThan(0);
        result.Items.ShouldContain(x => x.Name == "Русский");
        result.Items.ShouldContain(x => x.Name == "English");
    }

    [Fact]
    public async Task CreateAsync()
    {
        var language = await _service.CreateAsync(new CreateSystemLanguageInput { Code = "te", Name = "Test" });

        language.Id.ShouldBe("te");
        language.Name.ShouldBe("Test");
    }

    [Fact]
    public async Task CreateAsync_Should_Not_Allow_Duplicate_Name()
    {
        await Assert.ThrowsAsync<SystemLanguageNameAlreadyExistsException>(async () =>
        {
            await _service.CreateAsync(new CreateSystemLanguageInput { Code = "ru", Name = "Русский" });
        });
    }

    [Fact]
    public async Task UpdateAsync()
    {
        var language = UsingDbContext(db => db.Languages.Single(t => t.Id == "ru"));

        var result = await _service.UpdateAsync(language.Id, new UpdateSystemLanguageInput { Name = "Russian" });
        result.Id.ShouldBe(language.Id);
        result.Name.ShouldBe("Russian");

        var acmeUpdated = UsingDbContext(db => db.Languages.Single(x => x.Id == language.Id));
        acmeUpdated.Name.ShouldBe("Russian");
    }

    [Fact]
    public async Task UpdateAsync_Should_Not_Allow_Duplicate_Names()
    {
        var language = UsingDbContext(db => db.Languages.Single(t => t.Id == "en"));

        await Assert.ThrowsAsync<SystemLanguageNameAlreadyExistsException>(async () =>
        {
            await _service.UpdateAsync(language.Id, new UpdateSystemLanguageInput { Name = "Русский" });
        });
    }

    [Fact]
    public async Task DeleteAsync()
    {
        var language = UsingDbContext(dbContext => dbContext.Languages.Single(t => t.Id == "en"));

        await _service.DeleteAsync(language.Id);

        UsingDbContext(db =>
        {
            db.Languages.Any(x => x.Id == language.Id).ShouldBeFalse();
        });
    }
}
