using CookieCrumble;
using HotChocolate.Execution;
using HotChocolate.Execution.Configuration;
using Xunit;

namespace Rubrum.Abp.Graphql;

public class SchemaTests : GraphqlFluentValidationTestBase
{
    private readonly IRequestExecutorBuilder _builder;

    public SchemaTests()
    {
        _builder = GetRequiredService<IRequestExecutorBuilder>();
    }

    [Fact]
    public async Task SchemaChangeTest()
    {
        var schema = await _builder.BuildSchemaAsync();
        schema.MatchSnapshot();
    }
}
