using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Rubrum.Abp.Graphql.Filters.DateOnly;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.MultiTenancy;

namespace Rubrum.Abp.Graphql.Types.Ddd;

public static class TypesExtensions
{
    public static IInterfaceTypeDescriptor<TEntity> Entity<TEntity, TKey>(
        this IInterfaceTypeDescriptor<TEntity> descriptor)
        where TEntity : IEntityDto<TKey>
    {
        descriptor.Implements<NodeType>();
        descriptor.Implements<EntityType<TKey>>();

        descriptor
            .Field(x => x.Id)
            .Type<NonNullType<IdType>>();

        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntity> Entity<TEntity, TKey>(
        this IObjectTypeDescriptor<TEntity> descriptor,
        string? typeName = null)
        where TEntity : IEntityDto<TKey>
    {
        descriptor.Implements<NodeType>();
        descriptor.Implements<EntityType<TKey>>();

        descriptor
            .Field(x => x.Id)
            .IsProjected()
            .ID(typeName ?? typeof(TEntity).Name);

        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntity> Entity<TEntity, TKey>(
        this IFilterInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IEntityDto<TKey>
    {
        descriptor
            .Field(x => x.Id)
            .Type<IdOperationFilterInputType>();
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntity> Entity<TEntity, TKey>(
        this ISortInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IEntityDto<TKey>
    {
        descriptor.Field(x => x.Id);
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntity> MayHaveCreator<TEntity>(
        this IInterfaceTypeDescriptor<TEntity> descriptor)
        where TEntity : IMayHaveCreator
    {
        descriptor.Implements<MayHaveCreatorType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntity> MayHaveCreator<TEntity>(this IObjectTypeDescriptor<TEntity> descriptor)
        where TEntity : IMayHaveCreator
    {
        descriptor.Implements<MayHaveCreatorType>();
        descriptor
            .Field(x => x.CreatorId)
            .IsProjected()
            .ID("IdentityUser");
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntity> MayHaveCreator<TEntity>(
        this IFilterInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IMayHaveCreator
    {
        descriptor
            .Field(x => x.CreatorId)
            .Type<IdOperationFilterInputType>();
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntity> MayHaveCreator<TEntity>(
        this ISortInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IMayHaveCreator
    {
        descriptor.Field(x => x.CreatorId);
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntity> HasCreationTime<TEntity>(
        this IInterfaceTypeDescriptor<TEntity> descriptor)
        where TEntity : IHasCreationTime
    {
        descriptor.Implements<HasCreationTimeType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntity> HasCreationTime<TEntity>(
        this IObjectTypeDescriptor<TEntity> descriptor)
        where TEntity : IHasCreationTime
    {
        descriptor.Implements<HasCreationTimeType>();
        descriptor
            .Field(x => x.CreationTime)
            .Type<DateTimeType>();
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntity> HasCreationTime<TEntity>(
        this IFilterInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IHasCreationTime
    {
        descriptor
            .Field(x => x.CreationTime)
            .Type<ComparableOperationFilterInputType<DateTime>>();

        descriptor.AddDateOnlyFilter("creationDate", x => x.CreationTime);

        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntity> HasCreationTime<TEntity>(
        this ISortInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IHasCreationTime
    {
        descriptor.Field(x => x.CreationTime);
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntity> CreationAudited<TEntity>(
        this IInterfaceTypeDescriptor<TEntity> descriptor)
        where TEntity : ICreationAuditedObject
    {
        descriptor.MayHaveCreator();
        descriptor.HasCreationTime();
        descriptor.Implements<CreationAuditedType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntity> CreationAudited<TEntity>(
        this IObjectTypeDescriptor<TEntity> descriptor)
        where TEntity : ICreationAuditedObject
    {
        descriptor.MayHaveCreator();
        descriptor.HasCreationTime();
        descriptor.Implements<CreationAuditedType>();
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntity> CreationAudited<TEntity>(
        this IFilterInputTypeDescriptor<TEntity> descriptor)
        where TEntity : ICreationAuditedObject
    {
        descriptor.MayHaveCreator();
        descriptor.HasCreationTime();
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntity> CreationAudited<TEntity>(
        this ISortInputTypeDescriptor<TEntity> descriptor)
        where TEntity : ICreationAuditedObject
    {
        descriptor.MayHaveCreator();
        descriptor.HasCreationTime();
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntity> HasModificationTime<TEntity>(
        this IInterfaceTypeDescriptor<TEntity> descriptor)
        where TEntity : IHasModificationTime
    {
        descriptor.Implements<HasModificationTimeType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntity> HasModificationTime<TEntity>(
        this IObjectTypeDescriptor<TEntity> descriptor)
        where TEntity : IHasModificationTime
    {
        descriptor.Implements<HasModificationTimeType>();
        descriptor
            .Field(x => x.LastModificationTime)
            .Type<DateTimeType>();
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntity> HasModificationTime<TEntity>(
        this IFilterInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IHasModificationTime
    {
        descriptor
            .Field(x => x.LastModificationTime)
            .Type<ComparableOperationFilterInputType<DateTime>>();

        descriptor.AddDateOnlyFilter("lastModificationDate", x => x.LastModificationTime);

        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntity> HasModificationTime<TEntity>(
        this ISortInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IHasModificationTime
    {
        descriptor.Field(x => x.LastModificationTime);
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntity> ModificationAudited<TEntity>(
        this IInterfaceTypeDescriptor<TEntity> descriptor)
        where TEntity : IModificationAuditedObject
    {
        descriptor.HasModificationTime();
        descriptor.Implements<ModificationAuditedType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntity> ModificationAudited<TEntity>(
        this IObjectTypeDescriptor<TEntity> descriptor)
        where TEntity : IModificationAuditedObject
    {
        descriptor.HasModificationTime();

        descriptor.Implements<ModificationAuditedType>();

        descriptor
            .Field(x => x.LastModifierId)
            .IsProjected()
            .ID("IdentityUser");
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntity> ModificationAudited<TEntity>(
        this IFilterInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IModificationAuditedObject
    {
        descriptor.HasModificationTime();

        descriptor
            .Field(x => x.LastModifierId)
            .Type<IdOperationFilterInputType>();
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntity> ModificationAudited<TEntity>(
        this ISortInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IModificationAuditedObject
    {
        descriptor.HasModificationTime();
        descriptor.Field(x => x.LastModifierId);
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntity> SoftDelete<TEntity>(
        this IInterfaceTypeDescriptor<TEntity> descriptor)
        where TEntity : ISoftDelete
    {
        descriptor.Implements<SoftDeleteType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntity> SoftDelete<TEntity>(this IObjectTypeDescriptor<TEntity> descriptor)
        where TEntity : ISoftDelete
    {
        descriptor.Implements<SoftDeleteType>();

        descriptor
            .Field(x => x.IsDeleted)
            .IsProjected()
            .Type<NonNullType<BooleanType>>();
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntity> SoftDelete<TEntity>(
        this IFilterInputTypeDescriptor<TEntity> descriptor)
        where TEntity : ISoftDelete
    {
        descriptor
            .Field(x => x.IsDeleted)
            .Type<BooleanOperationFilterInputType>();
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntity> SoftDelete<TEntity>(
        this ISortInputTypeDescriptor<TEntity> descriptor)
        where TEntity : ISoftDelete
    {
        descriptor.Field(x => x.IsDeleted);
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntity> HasDeletionTime<TEntity>(
        this IInterfaceTypeDescriptor<TEntity> descriptor)
        where TEntity : IHasDeletionTime
    {
        descriptor.SoftDelete();

        descriptor.Implements<HasDeletionTimeType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntity> HasDeletionTime<TEntity>(
        this IObjectTypeDescriptor<TEntity> descriptor)
        where TEntity : IHasDeletionTime
    {
        descriptor.SoftDelete();

        descriptor.Implements<HasDeletionTimeType>();

        descriptor
            .Field(x => x.DeletionTime)
            .Type<DateTimeType>();
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntity> HasDeletionTime<TEntity>(
        this IFilterInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IHasDeletionTime
    {
        descriptor.SoftDelete();

        descriptor
            .Field(x => x.DeletionTime)
            .Type<ComparableOperationFilterInputType<DateTime>>();

        descriptor.AddDateOnlyFilter("deletionTime", x => x.DeletionTime);

        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntity> HasDeletionTime<TEntity>(
        this ISortInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IHasDeletionTime
    {
        descriptor.SoftDelete();
        descriptor.Field(x => x.DeletionTime);
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntity> DeletionAudited<TEntity>(
        this IInterfaceTypeDescriptor<TEntity> descriptor)
        where TEntity : IDeletionAuditedObject
    {
        descriptor.HasDeletionTime();

        descriptor.Implements<DeletionAuditedType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntity> DeletionAudited<TEntity>(
        this IObjectTypeDescriptor<TEntity> descriptor)
        where TEntity : IDeletionAuditedObject
    {
        descriptor.HasDeletionTime();

        descriptor.Implements<DeletionAuditedType>();

        descriptor
            .Field(x => x.DeleterId)
            .IsProjected()
            .ID("IdentityUser");
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntity> DeletionAudited<TEntity>(
        this IFilterInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IDeletionAuditedObject
    {
        descriptor
            .Field(x => x.DeleterId)
            .Type<IdOperationFilterInputType>();
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntity> DeletionAudited<TEntity>(
        this ISortInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IDeletionAuditedObject
    {
        descriptor.HasDeletionTime();
        descriptor.Field(x => x.DeleterId);
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntity> Audited<TEntity>(this IInterfaceTypeDescriptor<TEntity> descriptor)
        where TEntity : IAuditedObject
    {
        descriptor.CreationAudited();
        descriptor.ModificationAudited();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntity> Audited<TEntity>(this IObjectTypeDescriptor<TEntity> descriptor)
        where TEntity : IAuditedObject
    {
        descriptor.CreationAudited();
        descriptor.ModificationAudited();
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntity> Audited<TEntity>(
        this IFilterInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IAuditedObject
    {
        descriptor.CreationAudited();
        descriptor.ModificationAudited();
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntity> Audited<TEntity>(this ISortInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IAuditedObject
    {
        descriptor.CreationAudited();
        descriptor.ModificationAudited();
        return descriptor;
    }


    public static IInterfaceTypeDescriptor<TEntity> FullAudited<TEntity>(
        this IInterfaceTypeDescriptor<TEntity> descriptor)
        where TEntity : IFullAuditedObject
    {
        descriptor.Audited();
        descriptor.DeletionAudited();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntity> FullAudited<TEntity>(this IObjectTypeDescriptor<TEntity> descriptor)
        where TEntity : IFullAuditedObject
    {
        descriptor.Audited();
        descriptor.DeletionAudited();
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntity> FullAudited<TEntity>(
        this IFilterInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IFullAuditedObject
    {
        descriptor.Audited();
        descriptor.DeletionAudited();
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntity> FullAudited<TEntity>(
        this ISortInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IFullAuditedObject
    {
        descriptor.Audited();
        descriptor.DeletionAudited();
        return descriptor;
    }

    public static IInterfaceTypeDescriptor<TEntity> MultiTenant<TEntity>(
        this IInterfaceTypeDescriptor<TEntity> descriptor)
        where TEntity : IMultiTenant
    {
        descriptor.Implements<MultiTenantType>();
        return descriptor;
    }

    public static IObjectTypeDescriptor<TEntity> MultiTenant<TEntity>(this IObjectTypeDescriptor<TEntity> descriptor)
        where TEntity : IMultiTenant
    {
        descriptor.Implements<MultiTenantType>();
        descriptor
            .Field(x => x.TenantId)
            .IsProjected()
            .ID("Tenant");
        return descriptor;
    }

    public static IFilterInputTypeDescriptor<TEntity> MultiTenant<TEntity>(
        this IFilterInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IMultiTenant
    {
        descriptor.Ignore(x => x.TenantId);
        return descriptor;
    }

    public static ISortInputTypeDescriptor<TEntity> MultiTenant<TEntity>(
        this ISortInputTypeDescriptor<TEntity> descriptor)
        where TEntity : IMultiTenant
    {
        descriptor.Ignore(x => x.TenantId);
        return descriptor;
    }
}
