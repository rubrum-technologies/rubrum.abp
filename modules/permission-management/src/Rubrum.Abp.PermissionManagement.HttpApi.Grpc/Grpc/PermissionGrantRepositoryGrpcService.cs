using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Rubrum.Abp.PermissionManagement.HttpApi.Grpc;
using Volo.Abp.PermissionManagement;

namespace Rubrum.Abp.PermissionManagement.Grpc;

public class PermissionGrantRepositoryGrpcService : PermissionGrantRepositoryGrpc.PermissionGrantRepositoryGrpcBase
{
    private readonly IPermissionManager _manager;
    private readonly IPermissionGrantRepository _repository;

    public PermissionGrantRepositoryGrpcService(IPermissionGrantRepository repository, IPermissionManager manager)
    {
        _repository = repository;
        _manager = manager;
    }

    public override async Task<PermissionGrantResponse> Get(
        PermissionGrantGetRequest request,
        ServerCallContext context)
    {
        var id = Guid.Parse(request.Id);
        var entity = await _repository.GetAsync(id, request.IncludeDetails, context.CancellationToken);
        return ToResponse(entity);
    }

    public override async Task<PermissionGrantResponse> Find(
        PermissionGrantFindRequest request,
        ServerCallContext context)
    {
        var id = Guid.Parse(request.Id);
        var entity = await _repository.FindAsync(id, request.IncludeDetails, context.CancellationToken);
        return ToResponse(entity);
    }

    public override async Task<PermissionGrantResponse> FindByName(
        PermissionGrantFindByNameRequest request,
        ServerCallContext context)
    {
        var entity = await _repository.FindAsync(
            request.Name,
            request.ProviderName,
            request.ProviderKey,
            context.CancellationToken);
        return ToResponse(entity);
    }

    public override async Task<PermissionGrantListResponse> GetList(
        PermissionGrantListRequest request,
        ServerCallContext context)
    {
        var entities = await _repository.GetListAsync(request.IncludeDetails, context.CancellationToken);
        return ToResponse(entities);
    }

    public override async Task<PermissionGrantListResponse> GetListByProvider(
        PermissionGrantListByProviderRequest request,
        ServerCallContext context)
    {
        var entities = await _repository.GetListAsync(
            request.ProviderName,
            request.ProviderKey,
            context.CancellationToken);
        return ToResponse(entities);
    }

    public override async Task<PermissionGrantListResponse> GetListByNames(
        PermissionGrantListByNamesRequest request,
        ServerCallContext context)
    {
        var entities = await _repository.GetListAsync(
            request.Names.ToArray(),
            request.ProviderName,
            request.ProviderKey,
            context.CancellationToken);
        return ToResponse(entities);
    }

    public override async Task<PermissionGrantListResponse> GetPagedList(
        PermissionGrantPagedListRequest request,
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

    public override async Task<PermissionGrantCountResponse> GetCount(
        Empty request,
        ServerCallContext context)
    {
        var count = await _repository.GetCountAsync(context.CancellationToken);
        return new PermissionGrantCountResponse { Count = count };
    }

    public override async Task<PermissionGrantResponse> Insert(
        PermissionGrantInsertRequest request,
        ServerCallContext context)
    {
        var entity = await _repository.InsertAsync(
            ToEntity(request),
            true,
            context.CancellationToken);
        return ToResponse(entity);
    }

    public override async Task<PermissionGrantListResponse> InsertMany(
        PermissionGrantInsertManyRequest request,
        ServerCallContext context)
    {
        var entities = request.Inputs.Select(ToEntity).ToList();

        await _repository.InsertManyAsync(
            entities,
            true,
            context.CancellationToken);

        return ToResponse(entities);
    }

    public override async Task<PermissionGrantResponse> Update(
        PermissionGrantUpdateRequest request,
        ServerCallContext context)
    {
        var entity = await _repository.GetAsync(Guid.Parse(request.Id), true, context.CancellationToken);
        await UpdateAsync(entity, request);
        await _repository.UpdateAsync(entity, true, context.CancellationToken);
        return ToResponse(entity);
    }

    public override async Task<PermissionGrantListResponse> UpdateMany(
        PermissionGrantUpdateManyRequest request,
        ServerCallContext context)
    {
        var entities = new List<PermissionGrant>();

        foreach (var input in request.Inputs)
        {
            var entity = await _repository.GetAsync(Guid.Parse(input.Id), true, context.CancellationToken);
            await UpdateAsync(entity, input);
            await _repository.UpdateAsync(entity, true, context.CancellationToken);
            entities.Add(entity);
        }

        return ToResponse(entities);
    }

    public override async Task<Empty> Delete(
        PermissionGrantDeleteRequest request,
        ServerCallContext context)
    {
        await _repository.DeleteAsync(Guid.Parse(request.Id), true, context.CancellationToken);
        return new Empty();
    }

    public override async Task<Empty> DeleteMany(
        PermissionGrantDeleteManyRequest request,
        ServerCallContext context)
    {
        foreach (var deleteRequest in request.Ids)
        {
            await _repository.DeleteAsync(Guid.Parse(deleteRequest.Id), true, context.CancellationToken);
        }

        return new Empty();
    }

    private static PermissionGrantResponse ToResponse(PermissionGrant? entity)
    {
        return entity is null
            ? new PermissionGrantResponse()
            : new PermissionGrantResponse
            {
                Id = entity.Id.ToString(),
                TenantId = entity.TenantId?.ToString(),
                Name = entity.Name,
                ProviderName = entity.ProviderName,
                ProviderKey = entity.ProviderKey
            };
    }

    private static PermissionGrantListResponse ToResponse(
        IEnumerable<PermissionGrant?> permissions)
    {
        var response = new PermissionGrantListResponse();
        response.Entities.AddRange(permissions.Select(ToResponse));
        return response;
    }

    private static PermissionGrant ToEntity(
        PermissionGrantInsertRequest input)
    {
        return new PermissionGrant(
            Guid.Parse(input.Id),
            input.Name,
            input.ProviderName,
            input.ProviderKey,
            string.IsNullOrWhiteSpace(input.TenantId) ? null : Guid.Parse(input.TenantId));
    }

    private async Task UpdateAsync(
        PermissionGrant entity,
        PermissionGrantUpdateRequest input)
    {
        await _manager.UpdateProviderKeyAsync(entity, input.ProviderKey);
        await _manager.SetAsync(entity.Name, entity.ProviderName, entity.ProviderKey, input.IsGranted);
    }
}
