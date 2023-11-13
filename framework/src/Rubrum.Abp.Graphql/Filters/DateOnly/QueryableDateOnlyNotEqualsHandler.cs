using System.Linq.Expressions;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Language;
using HotChocolate.Utilities;

namespace Rubrum.Abp.Graphql.Filters.DateOnly;

public class QueryableDateOnlyNotEqualsHandler : QueryableDateOnlyOperationHandler
{
    public QueryableDateOnlyNotEqualsHandler(
        ITypeConverter typeConverter,
        InputParser inputParser)
        : base(typeConverter, inputParser)
    {
    }

    protected override int Operation => DefaultFilterOperations.NotEquals;

    public override Expression HandleOperation(
        QueryableFilterContext context,
        IFilterOperationField field,
        IValueNode value,
        object? parsedValue)
    {
        parsedValue = ParseValue(value, parsedValue, field.Type, context);
        var property = parsedValue is null ? context.GetInstance() : GetProperty(context);
        return FilterExpressionBuilder.NotEquals(property, parsedValue);
    }
}