using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Rubrum.Abp.PermissionManagement.HttpApi.Grpc;
using Volo.Abp.PermissionManagement;

namespace Rubrum.Abp.PermissionManagement.Grpc;

public class PermissionDefinitionRecordRepositoryGrpcService
    : PermissionDefinitionRecordRepositoryGrpc.PermissionDefinitionRecordRepositoryGrpcBase
{
    private readonly IPermissionDefinitionRecordRepository _repository;

    public PermissionDefinitionRecordRepositoryGrpcService(IPermissionDefinitionRecordRepository repository)
    {
        _repository = repository;
    }

    public override async Task<PermissionDefinitionRecordResponse> Get(
        PermissionDefinitionRecordGetRequest request,
        ServerCallContext context)
    {
        var id = Guid.Parse(request.Id);
        var entity = await _repository.GetAsync(id, request.IncludeDetails, context.CancellationToken);
        return ToResponse(entity);
    }

    public override async Task<PermissionDefinitionRecordResponse> Find(
        PermissionDefinitionRecordFindRequest request,
        ServerCallContext context)
    {
        var id = Guid.Parse(request.Id);
        var entity = await _repository.FindAsync(id, request.IncludeDetails, context.CancellationToken);
        return ToResponse(entity);
    }

    public override async Task<PermissionDefinitionRecordResponse> FindByName(
        PermissionDefinitionRecordFindByNameRequest request,
        ServerCallContext context)
    {
        var entity = await _repository.FindByNameAsync(request.Name, context.CancellationToken);
        return ToResponse(entity);
    }

    public override async Task<PermissionDefinitionRecordListResponse> GetList(
        PermissionDefinitionRecordListRequest request,
        ServerCallContext context)
    {
        var entities = await _repository.GetListAsync(request.IncludeDetails, context.CancellationToken);
        return ToResponse(entities);
    }

    public override async Task<PermissionDefinitionRecordListResponse> GetPagedList(
        PermissionDefinitionRecordPagedListRequest request,
        ServerCallContext context)
    {
        var entities = await _repository.GetPagedListAsync(
            request.SkipCount,
            request.MaxResultCount,
            request.Sorting,
            request.IncludeDetails,
            context.CancellationToken);
        return ToResponse(entities);
    }

    public override async Task<PermissionDefinitionRecordCountResponse> GetCount(
        Empty request,
        ServerCallContext context)
    {
        var count = await _repository.GetCountAsync(context.CancellationToken);
        return new PermissionDefinitionRecordCountResponse { Count = count };
    }

    public override async Task<PermissionDefinitionRecordResponse> Insert(
        PermissionDefinitionRecordInsertRequest request,
        ServerCallContext context)
    {
        var entity = await _repository.InsertAsync(
            ToEntity(request),
            true,
            context.CancellationToken);
        return ToResponse(entity);
    }

    public override async Task<PermissionDefinitionRecordListResponse> InsertMany(
        PermissionDefinitionRecordInsertManyRequest request,
        ServerCallContext context)
    {
        var entities = request.Inputs.Select(ToEntity).ToList();

        await _repository.InsertManyAsync(
            entities,
            true,
            context.CancellationToken);

        return ToResponse(entities);
    }

    public override async Task<PermissionDefinitionRecordResponse> Update(
        PermissionDefinitionRecordUpdateRequest request,
        ServerCallContext context)
    {
        var entity = await _repository.GetAsync(Guid.Parse(request.Id), true, context.CancellationToken);
        Update(entity, request);
        await _repository.UpdateAsync(entity, true, context.CancellationToken);
        return ToResponse(entity);
    }

    public override async Task<PermissionDefinitionRecordListResponse> UpdateMany(
        PermissionDefinitionRecordUpdateManyRequest request,
        ServerCallContext context)
    {
        var entities = new List<PermissionDefinitionRecord>();

        foreach (var input in request.Inputs)
        {
            var entity = await _repository.GetAsync(Guid.Parse(input.Id), true, context.CancellationToken);
            Update(entity, input);
            await _repository.UpdateAsync(entity, true, context.CancellationToken);
            entities.Add(entity);
        }

        return ToResponse(entities);
    }

    public override async Task<Empty> Delete(
        PermissionDefinitionRecordDeleteRequest request,
        ServerCallContext context)
    {
        await _repository.DeleteAsync(Guid.Parse(request.Id), true, context.CancellationToken);
        return new Empty();
    }

    public override async Task<Empty> DeleteMany(
        PermissionDefinitionRecordDeleteManyRequest request,
        ServerCallContext context)
    {
        foreach (var deleteRequest in request.Ids)
        {
            await _repository.DeleteAsync(Guid.Parse(deleteRequest.Id), true, context.CancellationToken);
        }

        return new Empty();
    }

    private static PermissionDefinitionRecordResponse ToResponse(
        PermissionDefinitionRecord? entity)
    {
        return entity is null
            ? new PermissionDefinitionRecordResponse()
            : new PermissionDefinitionRecordResponse
            {
                Id = entity.Id.ToString(),
                GroupName = entity.GroupName,
                Name = entity.Name,
                ParentName = entity.ParentName,
                DisplayName = entity.DisplayName,
                IsEnabled = entity.IsEnabled,
                MultiTenancySide = entity.MultiTenancySide.ToGrpc(),
                Providers = entity.Providers,
                StateCheckers = entity.StateCheckers
            };
    }

    private static PermissionDefinitionRecordListResponse ToResponse(
        IEnumerable<PermissionDefinitionRecord?> entities)
    {
        var response = new PermissionDefinitionRecordListResponse();
        response.Entities.AddRange(entities.Select(ToResponse));
        return response;
    }

    private static PermissionDefinitionRecord ToEntity(
        PermissionDefinitionRecordInsertRequest input)
    {
        return new PermissionDefinitionRecord(
            Guid.Parse(input.Id),
            input.GroupName,
            input.Name,
            input.ParentName,
            input.DisplayName,
            input.IsEnabled,
            input.MultiTenancySide.ToEntity(),
            input.Providers,
            input.StateCheckers);
    }

    private static void Update(
        PermissionDefinitionRecord entity,
        PermissionDefinitionRecordUpdateRequest input)
    {
        entity.GroupName = input.GroupName;
        entity.Name = input.Name;
        entity.ParentName = input.ParentName;
        entity.DisplayName = input.DisplayName;
        entity.IsEnabled = input.IsEnabled;
        entity.MultiTenancySide = input.MultiTenancySide.ToEntity();
        entity.Providers = input.Providers;
        entity.StateCheckers = input.StateCheckers;
    }
}
