using System.Linq.Expressions;
using HotChocolate.Data.Filters;

namespace Rubrum.Abp.Graphql.Filters.DateOnly;

public static class DateOnlyOperationFilterExtensions
{
    public static IFilterInputTypeDescriptor<T> AddDateOnlyFilter<T>(
        this IFilterInputTypeDescriptor<T> descriptor,
        string fieldName,
        Expression<Func<T, DateTime>> propertyOrMember)
    {
        descriptor
            .Extend()
            .OnBeforeCreate((context, definition) =>
            {
                definition.Fields.Add(new FilterFieldDefinition {
                    Member = (propertyOrMember.Body as MemberExpression)!.Member,
                    Name = fieldName,
                    Type = context.TypeInspector.GetTypeRef(typeof(DateOnlyOperationFilterInputType))
                });
            });
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<T> AddDateOnlyFilter<T>(
        this IFilterInputTypeDescriptor<T> descriptor,
        string fieldName,
        Expression<Func<T, DateTime?>> propertyOrMember)
    {
        descriptor
            .Extend()
            .OnBeforeCreate((context, definition) =>
            {
                definition.Fields.Add(new FilterFieldDefinition {
                    Member = (propertyOrMember.Body as MemberExpression)!.Member,
                    Name = fieldName,
                    Type = context.TypeInspector.GetTypeRef(typeof(DateOnlyOperationFilterInputType))
                });
            });
        return descriptor;
    }
}