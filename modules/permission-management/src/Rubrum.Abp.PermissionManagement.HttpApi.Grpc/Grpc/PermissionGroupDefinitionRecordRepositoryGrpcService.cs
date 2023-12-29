using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Rubrum.Abp.PermissionManagement.HttpApi.Grpc;
using Volo.Abp.PermissionManagement;

namespace Rubrum.Abp.PermissionManagement.Grpc;

public class PermissionGroupDefinitionRecordRepositoryGrpcService :
    PermissionGroupDefinitionRecordRepositoryGrpc.PermissionGroupDefinitionRecordRepositoryGrpcBase
{
    private readonly IPermissionGroupDefinitionRecordRepository _repository;

    public PermissionGroupDefinitionRecordRepositoryGrpcService(IPermissionGroupDefinitionRecordRepository repository)
    {
        _repository = repository;
    }

    public override async Task<PermissionGroupDefinitionRecordResponse> Get(
        PermissionGroupDefinitionRecordGetRequest request,
        ServerCallContext context)
    {
        var id = Guid.Parse(request.Id);
        var entity = await _repository.GetAsync(id, request.IncludeDetails, context.CancellationToken);
        return ToResponse(entity);
    }

    public override async Task<PermissionGroupDefinitionRecordResponse> Find(
        PermissionGroupDefinitionRecordFindRequest request,
        ServerCallContext context)
    {
        var id = Guid.Parse(request.Id);
        var entity = await _repository.FindAsync(id, request.IncludeDetails, context.CancellationToken);
        return ToResponse(entity);
    }

    public override async Task<PermissionGroupDefinitionRecordListResponse> GetList(
        PermissionGroupDefinitionRecordListRequest request,
        ServerCallContext context)
    {
        var entities = await _repository.GetListAsync(request.IncludeDetails, context.CancellationToken);
        return ToResponse(entities);
    }

    public override async Task<PermissionGroupDefinitionRecordListResponse> GetPagedList(
        PermissionGroupDefinitionRecordPagedListRequest request,
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

    public override async Task<PermissionGroupDefinitionRecordCountResponse> GetCount(
        Empty request,
        ServerCallContext context)
    {
        var count = await _repository.GetCountAsync(context.CancellationToken);
        return new PermissionGroupDefinitionRecordCountResponse { Count = count };
    }

    public override async Task<PermissionGroupDefinitionRecordResponse> Insert(
        PermissionGroupDefinitionRecordInsertRequest request,
        ServerCallContext context)
    {
        var entity = await _repository.InsertAsync(
            ToEntity(request),
            true,
            context.CancellationToken);
        return ToResponse(entity);
    }

    public override async Task<PermissionGroupDefinitionRecordListResponse> InsertMany(
        PermissionGroupDefinitionRecordInsertManyRequest request,
        ServerCallContext context)
    {
        var entities = request.Inputs.Select(ToEntity).ToList();

        await _repository.InsertManyAsync(
            entities,
            true,
            context.CancellationToken);

        return ToResponse(entities);
    }

    public override async Task<PermissionGroupDefinitionRecordResponse> Update(
        PermissionGroupDefinitionRecordUpdateRequest request,
        ServerCallContext context)
    {
        var entity = await _repository.GetAsync(Guid.Parse(request.Id), true, context.CancellationToken);
        Update(entity, request);
        await _repository.UpdateAsync(entity, true, context.CancellationToken);
        return ToResponse(entity);
    }

    public override async Task<PermissionGroupDefinitionRecordListResponse> UpdateMany(
        PermissionGroupDefinitionRecordUpdateManyRequest request,
        ServerCallContext context)
    {
        var entities = new List<PermissionGroupDefinitionRecord>();

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
        PermissionGroupDefinitionRecordDeleteRequest request,
        ServerCallContext context)
    {
        await _repository.DeleteAsync(Guid.Parse(request.Id), true, context.CancellationToken);
        return new Empty();
    }

    public override async Task<Empty> DeleteMany(
        PermissionGroupDefinitionRecordDeleteManyRequest request,
        ServerCallContext context)
    {
        foreach (var deleteRequest in request.Ids)
        {
            await _repository.DeleteAsync(Guid.Parse(deleteRequest.Id), true, context.CancellationToken);
        }

        return new Empty();
    }

    private static PermissionGroupDefinitionRecordResponse ToResponse(
        PermissionGroupDefinitionRecord? entity)
    {
        return entity is null
            ? new PermissionGroupDefinitionRecordResponse()
            : new PermissionGroupDefinitionRecordResponse
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                DisplayName = entity.DisplayName
            };
    }

    private static PermissionGroupDefinitionRecordListResponse ToResponse(
        IEnumerable<PermissionGroupDefinitionRecord?> entities)
    {
        var response = new PermissionGroupDefinitionRecordListResponse();
        response.Entities.AddRange(entities.Select(ToResponse));
        return response;
    }

    private static PermissionGroupDefinitionRecord ToEntity(
        PermissionGroupDefinitionRecordInsertRequest input)
    {
        return new PermissionGroupDefinitionRecord(
            Guid.Parse(input.Id),
            input.Name,
            input.DisplayName);
    }

    private static void Update(
        PermissionGroupDefinitionRecord entity,
        PermissionGroupDefinitionRecordUpdateRequest input)
    {
        entity.Name = input.Name;
        entity.DisplayName = input.DisplayName;
    }
}
