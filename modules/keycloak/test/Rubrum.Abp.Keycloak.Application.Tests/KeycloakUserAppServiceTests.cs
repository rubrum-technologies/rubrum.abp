using Rubrum.Abp.Keycloak.Users;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Xunit;

namespace Rubrum.Abp.Keycloak;

public class KeycloakUserAppServiceTests : RubrumAbpKeycloakApplicationTestBase
{
    private readonly IKeycloakClient _keycloakClient;
    private readonly IKeycloakUserAppService _service;

    public KeycloakUserAppServiceTests()
    {
        _keycloakClient = GetRequiredService<IKeycloakClient>();
        _service = GetRequiredService<IKeycloakUserAppService>();
    }

    [Fact]
    public async Task GetAsync()
    {
        var users = await _keycloakClient.GetUsersAsync();

        foreach (var user in users)
        {
            var result = await _service.GetAsync(user.Id!);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(user.Id);
            result.UserName.ShouldBe(user.Username);
        }
    }

    [Fact]
    public async Task GetListAsync()
    {
        var users = await _keycloakClient.GetUsersAsync(max: 1000);
        var result = await _service.GetListAsync(new PagedResultRequestDto { SkipCount = 0, MaxResultCount = 1000 });

        users.Count.ShouldBe(result.Items.Count);
    }

    [Fact]
    public async Task GetRolesAsync()
    {
        var users = await _keycloakClient.GetUsersAsync();
        var admin = users.First(x => x.Username == "admin");

        var roles = await _service.GetRolesAsync(admin.Id!);

        roles.Items.Any(x => x.Name == "admin").ShouldBeTrue();
    }

    [Fact]
    public async Task CreateAsync()
    {
        var userName = Guid.NewGuid().ToString();
        var firstName = Guid.NewGuid().ToString();
        var lastName = Guid.NewGuid().ToString();
        var email = $"{Guid.NewGuid()}@rubrum-technologies.ru";

        var result = await _service.CreateAsync(new CreateKeycloakUserInput
        {
            UserName = userName,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            IsActive = true
        });

        result.ShouldNotBeNull();
        result.UserName.ShouldBe(userName);
        result.FirstName.ShouldBe(firstName);
        result.LastName.ShouldBe(lastName);
        result.Email.ShouldBe(email);
        result.IsActive.ShouldBeTrue();

        var user = await _keycloakClient.GetUserByIdAsync(result.Id);

        user.Username.ShouldBe(userName);
        user.FirstName.ShouldBe(firstName);
        user.LastName.ShouldBe(lastName);
        user.Email.ShouldBe(email);
        user.Enabled.ShouldBe(true);
    }

    [Fact]
    public async Task UpdateAsync()
    {
        var result = await CreateUserAsync();

        var firstName = Guid.NewGuid().ToString();
        var lastName = Guid.NewGuid().ToString();
        var email = $"{Guid.NewGuid()}@rubrum-technologies.ru";

        result = await _service.UpdateAsync(
            result.Id,
            new UpdateKeycloakUserInput
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                IsActive = false
            });

        result.ShouldNotBeNull();
        result.FirstName.ShouldBe(firstName);
        result.LastName.ShouldBe(lastName);
        result.Email.ShouldBe(email);
        result.IsActive.ShouldBeFalse();

        var user = await _keycloakClient.GetUserByIdAsync(result.Id);

        user.FirstName.ShouldBe(firstName);
        user.LastName.ShouldBe(lastName);
        user.Email.ShouldBe(email);
        user.Enabled.ShouldBe(false);
    }

    [Fact]
    public async Task DeleteAsync()
    {
        var result = await CreateUserAsync();

        await _service.DeleteAsync(result.Id);

        var users = await _keycloakClient.GetUsersAsync();

        users.All(x => x.Id != result.Id).ShouldBeTrue();
    }

    [Fact]
    public async Task ChangePasswordAsync()
    {
        var result = await CreateUserAsync();

        result.ShouldNotBeNull();

        await _service.ChangePasswordAsync(result.Id, new ChangePasswordKeycloakUserInput { Password = "sagoiadg" });
    }

    [Fact]
    public async Task ChangeRolesAsync()
    {
        var result = await CreateUserAsync();

        await _service.ChangeRolesAsync(result.Id, new ChangeRolesKeycloakUserInput { RoleNames = new[] { "admin" } });

        var mappings = await _keycloakClient.GetUserRoleMappingsAsync(result.Id);

        mappings.RealmMappings.ShouldNotBeNull();
        mappings.RealmMappings.Exists(x => x.Name == "admin").ShouldBeTrue();
    }

    private async Task<KeycloakUserDto> CreateUserAsync()
    {
        var userName = Guid.NewGuid().ToString();
        var firstName = Guid.NewGuid().ToString();
        var lastName = Guid.NewGuid().ToString();
        var email = $"{Guid.NewGuid()}@rubrum-technologies.ru";

        return await _service.CreateAsync(new CreateKeycloakUserInput
        {
            UserName = userName,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            IsActive = true
        });
    }
}
