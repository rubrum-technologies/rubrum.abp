using Google.Protobuf.WellKnownTypes;
using Rubrum.Abp.PermissionManagement.HttpApi.Grpc;
using Volo.Abp.DependencyInjection;
using Volo.Abp.PermissionManagement;

namespace Rubrum.Abp.PermissionManagement;

[Dependency(ReplaceServices = true)]
public class PermissionGroupDefinitionRecordRepository :
    IPermissionGroupDefinitionRecordRepository,
    ITransientDependency
{
    private readonly PermissionGroupDefinitionRecordRepositoryGrpc.PermissionGroupDefinitionRecordRepositoryGrpcClient
        _client;

    public PermissionGroupDefinitionRecordRepository(
        PermissionGroupDefinitionRecordRepositoryGrpc.PermissionGroupDefinitionRecordRepositoryGrpcClient client)
    {
        _client = client;
    }

    public bool? IsChangeTrackingEnabled => false;

    public async Task<PermissionGroupDefinitionRecord> GetAsync(
        Guid id,
        bool includeDetails = true,
        CancellationToken cancellationToken = default)
    {
        var response = await _client.GetAsync(
            new PermissionGroupDefinitionRecordGetRequest { Id = id.ToString(), IncludeDetails = includeDetails },
            cancellationToken: cancellationToken);

        return ToEntity(response);
    }

    public async Task<PermissionGroupDefinitionRecord?> FindAsync(
        Guid id,
        bool includeDetails = true,
        CancellationToken cancellationToken = default)
    {
        var response = await _client.FindAsync(
            new PermissionGroupDefinitionRecordFindRequest { Id = id.ToString(), IncludeDetails = includeDetails },
            cancellationToken: cancellationToken);

        return ToEntity(response);
    }

    public async Task<List<PermissionGroupDefinitionRecord>> GetListAsync(
        bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        var response = await _client.GetListAsync(
            new PermissionGroupDefinitionRecordListRequest { IncludeDetails = includeDetails },
            cancellationToken: cancellationToken);

        return response.Entities.Select(ToEntity).ToList();
    }

    public async Task<long> GetCountAsync(CancellationToken cancellationToken = default)
    {
        var response = await _client.GetCountAsync(
            new Empty(),
            cancellationToken: cancellationToken);

        return response.Count;
    }

    public async Task<List<PermissionGroupDefinitionRecord>> GetPagedListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        var response = await _client.GetListAsync(
            new PermissionGroupDefinitionRecordListRequest { IncludeDetails = includeDetails },
            cancellationToken: cancellationToken);

        return response.Entities.Select(ToEntity).ToList();
    }

    public async Task<PermissionGroupDefinitionRecord> InsertAsync(
        PermissionGroupDefinitionRecord entity,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        var response = await _client.InsertAsync(
            ToInsertRequest(entity),
            cancellationToken: cancellationToken);

        return ToEntity(response);
    }

    public async Task InsertManyAsync(
        IEnumerable<PermissionGroupDefinitionRecord> entities,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        var request = new PermissionGroupDefinitionRecordInsertManyRequest();
        request.Inputs.AddRange(entities.Select(ToInsertRequest));

        await _client.InsertManyAsync(request, cancellationToken: cancellationToken);
    }

    public async Task<PermissionGroupDefinitionRecord> UpdateAsync(
        PermissionGroupDefinitionRecord entity,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        var response = await _client.UpdateAsync(
            ToUpdateRequest(entity),
            cancellationToken: cancellationToken);

        return ToEntity(response);
    }

    public async Task UpdateManyAsync(
        IEnumerable<PermissionGroupDefinitionRecord> entities,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        var request = new PermissionGroupDefinitionRecordUpdateManyRequest();
        request.Inputs.AddRange(entities.Select(ToUpdateRequest));

        await _client.UpdateManyAsync(request, cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(
        PermissionGroupDefinitionRecord entity,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        await DeleteAsync(entity.Id, autoSave, cancellationToken);
    }

    public async Task DeleteManyAsync(
        IEnumerable<PermissionGroupDefinitionRecord> entities,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        await DeleteManyAsync(entities.Select(x => x.Id), autoSave, cancellationToken);
    }

    public async Task DeleteAsync(
        Guid id,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        await _client.DeleteAsync(
            new PermissionGroupDefinitionRecordDeleteRequest { Id = id.ToString() },
            cancellationToken: cancellationToken);
    }

    public async Task DeleteManyAsync(
        IEnumerable<Guid> ids,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        var request = new PermissionGroupDefinitionRecordDeleteManyRequest();
        request.Ids.AddRange(ids.Select(x => new PermissionGroupDefinitionRecordDeleteRequest { Id = x.ToString() }));

        await _client.DeleteManyAsync(
            request,
            cancellationToken: cancellationToken);
    }

    private static PermissionGroupDefinitionRecord ToEntity(
        PermissionGroupDefinitionRecordResponse response)
    {
        return new PermissionGroupDefinitionRecord(
            Guid.Parse(response.Id),
            response.Name,
            response.DisplayName);
    }

    private static PermissionGroupDefinitionRecordInsertRequest ToInsertRequest(PermissionGroupDefinitionRecord entity)
    {
        return new PermissionGroupDefinitionRecordInsertRequest
        {
            Id = entity.Id.ToString(),
            Name = entity.Name,
            DisplayName = entity.DisplayName
        };
    }

    private static PermissionGroupDefinitionRecordUpdateRequest ToUpdateRequest(PermissionGroupDefinitionRecord entity)
    {
        return new PermissionGroupDefinitionRecordUpdateRequest
        {
            Id = entity.Id.ToString(),
            Name = entity.Name,
            DisplayName = entity.DisplayName
        };
    }
}
