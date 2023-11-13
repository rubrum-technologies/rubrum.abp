using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using HotChocolate.Types;
using Rubrum.Abp.MultilingualObjects;

namespace Rubrum.Abp.Graphql.MultilingualObjects;

public static class MultilingualObjectTypeExtensions
{
    public static IObjectTypeDescriptor<TObject> MultilingualObject<TObject, TTranslation>(
        this IObjectTypeDescriptor<TObject> descriptor)
        where TObject : IMultilingualObject<TTranslation>
        where TTranslation : IObjectTranslation
    {
        descriptor
            .Field("translation")
            .Argument("culture", a => a.Type<StringType>())
            .Resolve(context =>
            {
                var parent = context.Parent<TObject>();
                var culture = context.ArgumentOptional<string>("culture");

                return parent.FindTranslation(culture.Value);
            })
            .Type<ObjectType<TTranslation>>();

        descriptor
            .Field(x => x.Translations)
            .UseFiltering<FilterInputType<TTranslation>>()
            .UseSorting<SortInputType<TTranslation>>()
            .Type<NonNullType<ListType<NonNullType<ObjectType<TTranslation>>>>>();

        return descriptor;
    }
}
