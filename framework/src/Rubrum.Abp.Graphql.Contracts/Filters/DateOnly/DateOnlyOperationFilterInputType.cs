using HotChocolate.Data.Filters;
using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.Graphql.Filters.DateOnly;

public class DateOnlyOperationFilterInputType : FilterInputType, IGraphqlType
{
    protected override void Configure(IFilterInputTypeDescriptor descriptor)
    {
        descriptor
            .Operation(DefaultFilterOperations.Equals)
            .Type(typeof(System.DateOnly))
            .MakeNullable();

        descriptor
            .Operation(DefaultFilterOperations.NotEquals)
            .Type(typeof(System.DateOnly))
            .MakeNullable();

        descriptor
            .Operation(DefaultFilterOperations.In)
            .Type(typeof(IEnumerable<System.DateOnly>))
            .MakeNullable();

        descriptor
            .Operation(DefaultFilterOperations.NotIn)
            .Type(typeof(IEnumerable<System.DateOnly>))
            .MakeNullable();

        descriptor
            .Operation(DefaultFilterOperations.GreaterThan)
            .Type(typeof(System.DateOnly))
            .MakeNullable();

        descriptor
            .Operation(DefaultFilterOperations.NotGreaterThan)
            .Type(typeof(System.DateOnly))
            .MakeNullable();

        descriptor
            .Operation(DefaultFilterOperations.GreaterThanOrEquals)
            .Type(typeof(System.DateOnly))
            .MakeNullable();

        descriptor
            .Operation(DefaultFilterOperations.NotGreaterThanOrEquals)
            .Type(typeof(System.DateOnly))
            .MakeNullable();

        descriptor
            .Operation(DefaultFilterOperations.LowerThan)
            .Type(typeof(System.DateOnly))
            .MakeNullable();

        descriptor
            .Operation(DefaultFilterOperations.NotLowerThan)
            .Type(typeof(System.DateOnly))
            .MakeNullable();

        descriptor
            .Operation(DefaultFilterOperations.LowerThanOrEquals)
            .Type(typeof(System.DateOnly))
            .MakeNullable();

        descriptor
            .Operation(DefaultFilterOperations.NotLowerThanOrEquals)
            .Type(typeof(System.DateOnly))
            .MakeNullable();

        descriptor.AllowAnd().AllowOr();
    }
}
