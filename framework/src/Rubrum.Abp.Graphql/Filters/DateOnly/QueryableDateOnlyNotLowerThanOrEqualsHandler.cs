using System.Linq.Expressions;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Language;
using HotChocolate.Utilities;

namespace Rubrum.Abp.Graphql.Filters.DateOnly;

public class QueryableDateOnlyNotLowerThanOrEqualsHandler : QueryableDateOnlyOperationHandler
{
    public QueryableDateOnlyNotLowerThanOrEqualsHandler(
        ITypeConverter typeConverter,
        InputParser inputParser)
        : base(typeConverter, inputParser)
    {
        CanBeNull = false;
    }

    protected override int Operation => DefaultFilterOperations.NotLowerThanOrEquals;

    public override Expression HandleOperation(
        QueryableFilterContext context,
        IFilterOperationField field,
        IValueNode value,
        object? parsedValue)
    {
        var property = GetProperty(context);
        parsedValue = ParseValue(value, parsedValue, field.Type, context);

        if (parsedValue is null)
        {
            throw new InvalidOperationException();
        }

        return FilterExpressionBuilder.Not(FilterExpressionBuilder.LowerThanOrEqual(property, parsedValue));
    }
}
