﻿using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace Rubrum.Abp.Keycloak;

public sealed class KeycloakDataSeederTests : RubrumAbpKeycloakDomainTestBase
{
    private readonly IKeycloakClient _keycloakClient;

    public KeycloakDataSeederTests()
    {
        _keycloakClient = GetRequiredService<IKeycloakClient>();
    }

    [Fact]
    public async Task Check_Result_Seeder()
    {
        using var scope = ServiceProvider.CreateScope();
        await scope.ServiceProvider
            .GetRequiredService<IKeycloakDataSeeder>()
            .SeedAsync();

        var clients = (await _keycloakClient.GetClientsAsync()).ToList();

        clients.Find(x => x.Name == "swagger-test").ShouldNotBeNull();
        clients.Find(x => x.Name == "test-app").ShouldNotBeNull();
        clients.Find(x => x.Name == "test-microservice-1").ShouldNotBeNull();
    }
}
