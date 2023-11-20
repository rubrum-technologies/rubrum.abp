﻿using CookieCrumble;
using HotChocolate.Types.Relay;
using Rubrum.Abp.Keycloak.Roles;
using Xunit;

namespace Rubrum.Abp.Keycloak;

public class KeycloakRoleTests : RubrumAbpKeycloakGraphqlTestBase
{
    private readonly IKeycloakRoleGraphqlService _service;
    private readonly IKeycloakClient _keycloakClient;
    private readonly IIdSerializer _idSerializer;

    public KeycloakRoleTests()
    {
        _service = GetRequiredService<IKeycloakRoleGraphqlService>();
        _keycloakClient = GetRequiredService<IKeycloakClient>();
        _idSerializer = GetRequiredService<IIdSerializer>();
    }

    [Fact]
    public async Task FetchById()
    {
        var role = await _keycloakClient.GetRoleByNameAsync("admin");
        var id = _idSerializer.Serialize(null, "KeycloakRole", role.Id);

        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              query {
                  keycloakRoleById(id: "{{id}}") {
                      name
                  }
              }
              """
        ));

        result.MatchSnapshot();
    }

    [Fact]
    public async Task Fetch()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            query {
                keycloakRole(where: { name: { eq: "admin" } }) {
                    name
                }
            }
            """
        ));

        result.MatchSnapshot();
    }

    [Fact]
    public async Task FetchList()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            query {
                keycloakRoles(where: { name: { eq: "admin" } }) {
                    nodes {
                      name
                    }
                    pageInfo {
                      endCursor
                      hasNextPage
                      hasPreviousPage
                      startCursor
                    }
                }
            }
            """
        ));

        result.MatchSnapshot();
    }

    [Fact]
    public async Task FetchAny()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            query {
                keycloakRolesAny(where: { name: { eq: "admin" } })
            }
            """
        ));

        result.MatchSnapshot();
    }

    [Fact]
    public async Task FetchCount()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
              query {
                  keycloakRolesCount(where: { name: { eq: "admin" } })
              }
            """
        ));

        result.MatchSnapshot();
    }

    [Fact]
    public async Task Create()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              mutation {
                  createKeycloakRole (input: { name: "{{Guid.NewGuid()}}" }) {
                      errors {
                          ... on Error {
                              message
                          }
                      }
                  }
              }
              """
        ));

        result.MatchSnapshot();
    }

    [Fact]
    public async Task Update()
    {
        var roles = await _keycloakClient.GetRolesAsync();
        if (roles.Any(x => x.Name == "test-2-role"))
        {
            await _service.DeleteAsync(roles.First(x => x.Name == "test-2-role").Id!);
        }
        
        var role = await CreateRoleAsync();
        var id = _idSerializer.Serialize(null, "KeycloakRole", role.Id);

        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              mutation {
                  updateKeycloakRole (input: { id: "{{id}}", name: "test-2-role" }) {
                      keycloakRole {
                          name
                      }
                      errors {
                          ... on Error {
                              message
                          }
                      }
                  }
              }
              """
        ));

        result.MatchSnapshot();
    }

    [Fact]
    public async Task Delete()
    {
        var role = await CreateRoleAsync("test-delete-graphql-8");
        var id = _idSerializer.Serialize(null, "KeycloakRole", role.Id);

        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              mutation {
                  deleteKeycloakRole (input: { id: "{{id}}" }) {
                      keycloakRole {
                          name
                      }
                      errors {
                          ... on Error {
                              message
                          }
                      }
                  }
              }
              """
        ));

        result.MatchSnapshot();
    }

    private Task<KeycloakRoleDto> CreateRoleAsync(string? name = null)
    {
        return _service.CreateAsync(new CreateKeycloakRoleInput { Name = name ?? Guid.NewGuid().ToString() });
    }
}
