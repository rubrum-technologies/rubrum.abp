using HotChocolate.Language;
using HotChocolate.Types;

namespace Rubrum.Abp.Graphql.Types;

public class EmptyType : BooleanType, IGraphqlType
{
    public EmptyType() : base("Empty", "Empty")
    {
    }

    public override IValueNode ParseResult(object? resultValue)
    {
        return BooleanValueNode.True;
    }

    protected override BooleanValueNode ParseValue(bool runtimeValue)
    {
        return BooleanValueNode.True;
    }
}