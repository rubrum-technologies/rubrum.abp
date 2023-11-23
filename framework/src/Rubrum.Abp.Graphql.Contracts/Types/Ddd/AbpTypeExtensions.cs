using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Rubrum.Abp.Graphql.DataLoader;
using Rubrum.Abp.Graphql.Filters.DateOnly;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;

namespace Rubrum.Abp.Graphql.Types.Ddd;

public static class AbpTypeExtensions
{
    public static IInputObjectTypeDescriptor<TInput> AddFieldKey<TInput, TKey>(
        this IInputObjectTypeDescriptor<TInput> descriptor,
        string typeName,
        string? fieldName = null) where TKey : notnull
    {
        descriptor
            .Field(fieldName ?? "id")
            .Type<NonNullType<InputObjectType<TKey>>>()
            .ID(typeName);

        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntityDto> Entity<TEntityDto, TKey>(
        this IInterfaceTypeDescriptor<TEntityDto> descriptor)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
    {
        descriptor.Implements<NodeType>();
        descriptor.Implements<EntityType<TKey>>();

        descriptor
            .Field(x => x.Id)
            .Type<NonNullType<IdType>>();

        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntityDto> Entity<TEntityDto, TKey>(
        this IObjectTypeDescriptor<TEntityDto> descriptor,
        string typeName)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
    {
        descriptor.Implements<NodeType>();
        descriptor.Implements<EntityType<TKey>>();

        descriptor
            .Field(x => x.Id)
            .IsProjected()
            .ID(typeName);

        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntityDto> Entity<TEntityDto, TKey>(
        this IObjectTypeDescriptor<TEntityDto> descriptor)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
    {
        descriptor.Implements<EntityType<TKey>>();

        descriptor
            .ImplementsNode()
            .IdField(x => x.Id)
            .ResolveNode(async (context, id) =>
            {
                var service = context.Service<IAbpDataLoader<TEntityDto, TKey>>();
                return await service.LoadAsync(id, context.RequestAborted);
            });

        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntityDto> Entity<TEntityDto, TKey>(
        this IFilterInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IEntityDto<TKey>
    {
        descriptor
            .Field(x => x.Id)
            .Type<IdOperationFilterInputType>();
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntityDto> Entity<TEntityDto, TKey>(
        this ISortInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IEntityDto<TKey>
    {
        descriptor.Field(x => x.Id);
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntityDto> ExtraProperties<TEntityDto>(
        this IInterfaceTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : ExtensibleObject
    {
        descriptor.Implements<HasExtraPropertiesType>();
        descriptor.Ignore(x => x.Validate(default!));

        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntityDto> ExtraProperties<TEntityDto>(
        this IObjectTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : ExtensibleObject
    {
        descriptor.Implements<HasExtraPropertiesType>();

        descriptor
            .Field(x => x.ExtraProperties)
            .Type<JsonType>();

        descriptor.Ignore(x => x.Validate(default!));

        return descriptor;
    }

    public static IInputObjectTypeDescriptor<TEntityDto> ExtraProperties<TEntityDto>(
        this IInputObjectTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : ExtensibleObject
    {
        descriptor.Ignore(x => x.ExtraProperties);
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntityDto> ExtraProperties<TEntityDto>(
        this IFilterInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : ExtensibleObject
    {
        descriptor.Ignore(x => x.ExtraProperties);

        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntityDto> ExtraProperties<TEntityDto>(
        this ISortInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : ExtensibleObject
    {
        descriptor.Ignore(x => x.ExtraProperties);

        return descriptor;
    }


    public static IInterfaceTypeDescriptor<TEntityDto> MayHaveCreator<TEntityDto>(
        this IInterfaceTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IMayHaveCreator
    {
        descriptor.Implements<MayHaveCreatorType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntityDto> MayHaveCreator<TEntityDto>(
        this IObjectTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IMayHaveCreator
    {
        descriptor.Implements<MayHaveCreatorType>();
        descriptor
            .Field(x => x.CreatorId)
            .IsProjected()
            .ID();
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntityDto> MayHaveCreator<TEntityDto>(
        this IFilterInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IMayHaveCreator
    {
        descriptor
            .Field(x => x.CreatorId)
            .Type<IdOperationFilterInputType>();
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntityDto> MayHaveCreator<TEntityDto>(
        this ISortInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IMayHaveCreator
    {
        descriptor.Field(x => x.CreatorId);
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntityDto> HasCreationTime<TEntityDto>(
        this IInterfaceTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IHasCreationTime
    {
        descriptor.Implements<HasCreationTimeType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntityDto> HasCreationTime<TEntityDto>(
        this IObjectTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IHasCreationTime
    {
        descriptor.Implements<HasCreationTimeType>();
        descriptor
            .Field(x => x.CreationTime)
            .Type<DateTimeType>();
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntityDto> HasCreationTime<TEntityDto>(
        this IFilterInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IHasCreationTime
    {
        descriptor
            .Field(x => x.CreationTime)
            .Type<ComparableOperationFilterInputType<DateTime>>();

        descriptor.AddDateOnlyFilter("creationDate", x => x.CreationTime);

        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntityDto> HasCreationTime<TEntityDto>(
        this ISortInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IHasCreationTime
    {
        descriptor.Field(x => x.CreationTime);
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntityDto> CreationAudited<TEntityDto>(
        this IInterfaceTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : ICreationAuditedObject
    {
        descriptor.MayHaveCreator();
        descriptor.HasCreationTime();
        descriptor.Implements<CreationAuditedType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntityDto> CreationAudited<TEntityDto>(
        this IObjectTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : ICreationAuditedObject
    {
        descriptor.MayHaveCreator();
        descriptor.HasCreationTime();
        descriptor.Implements<CreationAuditedType>();
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntityDto> CreationAudited<TEntityDto>(
        this IFilterInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : ICreationAuditedObject
    {
        descriptor.MayHaveCreator();
        descriptor.HasCreationTime();
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntityDto> CreationAudited<TEntityDto>(
        this ISortInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : ICreationAuditedObject
    {
        descriptor.MayHaveCreator();
        descriptor.HasCreationTime();
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntityDto> HasModificationTime<TEntityDto>(
        this IInterfaceTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IHasModificationTime
    {
        descriptor.Implements<HasModificationTimeType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntityDto> HasModificationTime<TEntityDto>(
        this IObjectTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IHasModificationTime
    {
        descriptor.Implements<HasModificationTimeType>();
        descriptor
            .Field(x => x.LastModificationTime)
            .Type<DateTimeType>();
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntityDto> HasModificationTime<TEntityDto>(
        this IFilterInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IHasModificationTime
    {
        descriptor
            .Field(x => x.LastModificationTime)
            .Type<ComparableOperationFilterInputType<DateTime>>();

        descriptor.AddDateOnlyFilter("lastModificationDate", x => x.LastModificationTime);

        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntityDto> HasModificationTime<TEntityDto>(
        this ISortInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IHasModificationTime
    {
        descriptor.Field(x => x.LastModificationTime);
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntityDto> ModificationAudited<TEntityDto>(
        this IInterfaceTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IModificationAuditedObject
    {
        descriptor.HasModificationTime();
        descriptor.Implements<ModificationAuditedType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntityDto> ModificationAudited<TEntityDto>(
        this IObjectTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IModificationAuditedObject
    {
        descriptor.HasModificationTime();

        descriptor.Implements<ModificationAuditedType>();

        descriptor
            .Field(x => x.LastModifierId)
            .IsProjected()
            .ID();
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntityDto> ModificationAudited<TEntityDto>(
        this IFilterInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IModificationAuditedObject
    {
        descriptor.HasModificationTime();

        descriptor
            .Field(x => x.LastModifierId)
            .Type<IdOperationFilterInputType>();
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntityDto> ModificationAudited<TEntityDto>(
        this ISortInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IModificationAuditedObject
    {
        descriptor.HasModificationTime();
        descriptor.Field(x => x.LastModifierId);
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntityDto> SoftDelete<TEntityDto>(
        this IInterfaceTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : ISoftDelete
    {
        descriptor.Implements<SoftDeleteType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntityDto> SoftDelete<TEntityDto>(
        this IObjectTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : ISoftDelete
    {
        descriptor.Implements<SoftDeleteType>();

        descriptor
            .Field(x => x.IsDeleted)
            .IsProjected()
            .Type<NonNullType<BooleanType>>();
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntityDto> SoftDelete<TEntityDto>(
        this IFilterInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : ISoftDelete
    {
        descriptor
            .Field(x => x.IsDeleted)
            .Type<BooleanOperationFilterInputType>();
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntityDto> SoftDelete<TEntityDto>(
        this ISortInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : ISoftDelete
    {
        descriptor.Field(x => x.IsDeleted);
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntityDto> HasDeletionTime<TEntityDto>(
        this IInterfaceTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IHasDeletionTime
    {
        descriptor.SoftDelete();

        descriptor.Implements<HasDeletionTimeType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntityDto> HasDeletionTime<TEntityDto>(
        this IObjectTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IHasDeletionTime
    {
        descriptor.SoftDelete();

        descriptor.Implements<HasDeletionTimeType>();

        descriptor
            .Field(x => x.DeletionTime)
            .Type<DateTimeType>();
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntityDto> HasDeletionTime<TEntityDto>(
        this IFilterInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IHasDeletionTime
    {
        descriptor.SoftDelete();

        descriptor
            .Field(x => x.DeletionTime)
            .Type<ComparableOperationFilterInputType<DateTime>>();

        descriptor.AddDateOnlyFilter("deletionTime", x => x.DeletionTime);

        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntityDto> HasDeletionTime<TEntityDto>(
        this ISortInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IHasDeletionTime
    {
        descriptor.SoftDelete();
        descriptor.Field(x => x.DeletionTime);
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntityDto> DeletionAudited<TEntityDto>(
        this IInterfaceTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IDeletionAuditedObject
    {
        descriptor.HasDeletionTime();

        descriptor.Implements<DeletionAuditedType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntityDto> DeletionAudited<TEntityDto>(
        this IObjectTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IDeletionAuditedObject
    {
        descriptor.HasDeletionTime();

        descriptor.Implements<DeletionAuditedType>();

        descriptor
            .Field(x => x.DeleterId)
            .IsProjected()
            .ID();
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntityDto> DeletionAudited<TEntityDto>(
        this IFilterInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IDeletionAuditedObject
    {
        descriptor
            .Field(x => x.DeleterId)
            .Type<IdOperationFilterInputType>();
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntityDto> DeletionAudited<TEntityDto>(
        this ISortInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IDeletionAuditedObject
    {
        descriptor.HasDeletionTime();
        descriptor.Field(x => x.DeleterId);
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntityDto> Audited<TEntityDto>(
        this IInterfaceTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IAuditedObject
    {
        descriptor.CreationAudited();
        descriptor.ModificationAudited();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntityDto> Audited<TEntityDto>(
        this IObjectTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IAuditedObject
    {
        descriptor.CreationAudited();
        descriptor.ModificationAudited();
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntityDto> Audited<TEntityDto>(
        this IFilterInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IAuditedObject
    {
        descriptor.CreationAudited();
        descriptor.ModificationAudited();
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntityDto> Audited<TEntityDto>(
        this ISortInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IAuditedObject
    {
        descriptor.CreationAudited();
        descriptor.ModificationAudited();
        return descriptor;
    }


    public static IInterfaceTypeDescriptor<TEntityDto> FullAudited<TEntityDto>(
        this IInterfaceTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IFullAuditedObject
    {
        descriptor.Audited();
        descriptor.DeletionAudited();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntityDto> FullAudited<TEntityDto>(
        this IObjectTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IFullAuditedObject
    {
        descriptor.Audited();
        descriptor.DeletionAudited();
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntityDto> FullAudited<TEntityDto>(
        this IFilterInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IFullAuditedObject
    {
        descriptor.Audited();
        descriptor.DeletionAudited();
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntityDto> FullAudited<TEntityDto>(
        this ISortInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IFullAuditedObject
    {
        descriptor.Audited();
        descriptor.DeletionAudited();
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntityDto> MultiTenant<TEntityDto>(
        this IInterfaceTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IMultiTenant
    {
        descriptor.Implements<MultiTenantType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntityDto> MultiTenant<TEntityDto>(
        this IObjectTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IMultiTenant
    {
        descriptor.Implements<MultiTenantType>();
        descriptor
            .Field(x => x.TenantId)
            .IsProjected()
            .ID("Tenant");
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntityDto> MultiTenant<TEntityDto>(
        this IFilterInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IMultiTenant
    {
        descriptor.Ignore(x => x.TenantId);
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntityDto> MultiTenant<TEntityDto>(
        this ISortInputTypeDescriptor<TEntityDto> descriptor)
        where TEntityDto : IMultiTenant
    {
        descriptor.Ignore(x => x.TenantId);
        return descriptor;
    }
}
