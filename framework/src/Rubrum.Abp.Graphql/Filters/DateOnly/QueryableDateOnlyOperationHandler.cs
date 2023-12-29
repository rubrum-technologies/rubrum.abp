using System.Linq.Expressions;
using HotChocolate.Configuration;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Utilities;

namespace Rubrum.Abp.Graphql.Filters.DateOnly;

public abstract class QueryableDateOnlyOperationHandler : QueryableComparableOperationHandler
{
    protected QueryableDateOnlyOperationHandler(
        ITypeConverter typeConverter,
        InputParser inputParser)
        : base(typeConverter, inputParser)
    {
    }

    public override bool CanHandle(
        ITypeCompletionContext context,
        IFilterInputTypeDefinition typeDefinition,
        IFilterFieldDefinition fieldDefinition)
    {
        return context.Type is DateOnlyOperationFilterInputType &&
               fieldDefinition is FilterOperationFieldDefinition operationField &&
               operationField.Id == Operation;
    }

    protected virtual Expression GetProperty(QueryableFilterContext context)
    {
        var property = context.GetInstance();

        if (property.Type == typeof(DateTime))
        {
            property = Expression.Property(context.GetInstance(), nameof(DateTime.Date));
        }
        else if (property.Type == typeof(DateTime?))
        {
            property = Expression.Property(
                Expression.Property(context.GetInstance(), "Value"),
                nameof(DateTime.Date));
        }

        return property;
    }
}
