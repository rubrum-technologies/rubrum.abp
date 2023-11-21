using Rubrum.Abp.Keycloak.Roles;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Xunit;

namespace Rubrum.Abp.Keycloak;

public class KeycloakRoleAppServiceTests : RubrumAbpKeycloakApplicationTestBase
{
    private readonly IKeycloakClient _keycloakClient;
    private readonly IKeycloakRoleAppService _service;

    public KeycloakRoleAppServiceTests()
    {
        _keycloakClient = GetRequiredService<IKeycloakClient>();
        _service = GetRequiredService<IKeycloakRoleAppService>();
    }

    [Fact]
    public async Task GetAsync()
    {
        var roles = await _keycloakClient.GetRolesAsync();

        foreach (var role in roles)
        {
            var result = await _service.GetAsync(role.Id!);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(role.Id);
            result.Name.ShouldBe(role.Name);
        }
    }

    [Fact]
    public async Task GetListAsync()
    {
        var roles = await _keycloakClient.GetRolesAsync();
        var result = await _service.GetListAsync(new PagedResultRequestDto { SkipCount = 0, MaxResultCount = 1000 });

        roles.Count.ShouldBe(result.Items.Count);
    }

    [Fact]
    public async Task CreateAsync()
    {
        var name = Guid.NewGuid().ToString();

        var result = await _service.CreateAsync(new CreateKeycloakRoleInput { Name = name });

        result.Name.ShouldBe(name);

        var roles = await _keycloakClient.GetRolesAsync();
        var role = roles.FirstOrDefault(x => x.Id == result.Id);

        role.ShouldNotBeNull();
        role.Id.ShouldBe(result.Id);
        role.Name.ShouldBe(result.Name);
    }

    [Fact]
    public async Task UpdateAsync()
    {
        var name = Guid.NewGuid().ToString();
        var result = await CreateRoleAsync();

        result = await _service.UpdateAsync(result.Id, new UpdateKeycloakRoleInput { Name = name });

        result.Name.ShouldBe(name);

        var roles = await _keycloakClient.GetRolesAsync();
        var role = roles.FirstOrDefault(x => x.Id == result.Id);

        role.ShouldNotBeNull();
        role.Id.ShouldBe(result.Id);
        role.Name.ShouldBe(result.Name);
    }

    [Fact]
    public async Task DeleteAsync()
    {
        var result = await CreateRoleAsync();

        await _service.DeleteAsync(result.Id);

        var roles = await _keycloakClient.GetUsersAsync();

        roles.All(x => x.Id != result.Id).ShouldBeTrue();
    }

    private Task<KeycloakRoleDto> CreateRoleAsync()
    {
        return _service.CreateAsync(new CreateKeycloakRoleInput { Name = Guid.NewGuid().ToString() });
    }
}
