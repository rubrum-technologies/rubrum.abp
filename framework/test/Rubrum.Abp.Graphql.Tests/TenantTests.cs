using CookieCrumble;
using HotChocolate.Types.Relay;
using Shouldly;
using Volo.Abp.Data;
using Volo.Abp.TenantManagement;
using Xunit;

namespace Rubrum.Abp.Graphql;

public class TenantTests : RubrumAbpGraphqlTestBase
{
    private readonly IIdSerializer _idSerializer;
    private readonly ITenantManager _manager;
    private readonly ITenantRepository _repository;

    public TenantTests()
    {
        _idSerializer = GetRequiredService<IIdSerializer>();
        _manager = GetRequiredService<ITenantManager>();
        _repository = GetRequiredService<ITenantRepository>();
    }

    [Fact]
    public async Task ExtraProperties()
    {
        var tenant = await _manager.CreateAsync("Test");

        tenant.SetProperty("Test", "Test Property");

        await _repository.InsertAsync(tenant, true);

        var id = _idSerializer.Serialize(null, "Tenant", tenant.Id);

        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              query {
                  tenantById(id: "{{id}}") {
                      id
                      name
                      test
                  }
              }
              """));

        result.ShouldNotBeNull();

        result.MatchInlineSnapshot(
            $$"""
            {
              "data": {
                "tenantById": {
                  "id": "{{id}}",
                  "name": "Test",
                  "test": "Test Property"
                }
              }
            }
            """);
    }
}
