using Google.Protobuf.WellKnownTypes;
using Rubrum.Abp.PermissionManagement.HttpApi.Grpc;
using Volo.Abp.DependencyInjection;
using Volo.Abp.PermissionManagement;

namespace Rubrum.Abp.PermissionManagement;

[Dependency(ReplaceServices = true)]
public class PermissionDefinitionRecordRepository : IPermissionDefinitionRecordRepository, ITransientDependency
{
    private readonly PermissionDefinitionRecordRepositoryGrpc.PermissionDefinitionRecordRepositoryGrpcClient _client;

    public PermissionDefinitionRecordRepository(
        PermissionDefinitionRecordRepositoryGrpc.PermissionDefinitionRecordRepositoryGrpcClient client)
    {
        _client = client;
    }

    public async Task<PermissionDefinitionRecord> GetAsync(
        Guid id,
        bool includeDetails = true,
        CancellationToken cancellationToken = new())
    {
        var response = await _client.GetAsync(
            new PermissionDefinitionRecordGetRequest { Id = id.ToString(), IncludeDetails = includeDetails },
            cancellationToken: cancellationToken);

        return ToEntity(response);
    }

    public async Task<PermissionDefinitionRecord?> FindAsync(
        Guid id,
        bool includeDetails = true,
        CancellationToken cancellationToken = new())
    {
        var response = await _client.FindAsync(
            new PermissionDefinitionRecordFindRequest { Id = id.ToString(), IncludeDetails = includeDetails },
            cancellationToken: cancellationToken);

        return ToEntity(response);
    }

    public async Task<PermissionDefinitionRecord> FindByNameAsync(
        string name,
        CancellationToken cancellationToken = new())
    {
        var response = await _client.FindByNameAsync(
            new PermissionDefinitionRecordFindByNameRequest { Name = name },
            cancellationToken: cancellationToken);

        return ToEntity(response);
    }

    public async Task<List<PermissionDefinitionRecord>> GetListAsync(
        bool includeDetails = false,
        CancellationToken cancellationToken = new())
    {
        var response = await _client.GetListAsync(
            new PermissionDefinitionRecordListRequest { IncludeDetails = includeDetails },
            cancellationToken: cancellationToken);

        return response.Entities.Select(ToEntity).ToList();
    }

    public async Task<long> GetCountAsync(CancellationToken cancellationToken = new())
    {
        var response = await _client.GetCountAsync(
            new Empty(),
            cancellationToken: cancellationToken);

        return response.Count;
    }

    public async Task<List<PermissionDefinitionRecord>> GetPagedListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = new())
    {
        var response = await _client.GetListAsync(
            new PermissionDefinitionRecordListRequest { IncludeDetails = includeDetails },
            cancellationToken: cancellationToken);

        return response.Entities.Select(ToEntity).ToList();
    }

    public async Task<PermissionDefinitionRecord> InsertAsync(
        PermissionDefinitionRecord entity,
        bool autoSave = false,
        CancellationToken cancellationToken = new())
    {
        var response = await _client.InsertAsync(
            ToInsertRequest(entity),
            cancellationToken: cancellationToken);

        return ToEntity(response);
    }

    public async Task InsertManyAsync(
        IEnumerable<PermissionDefinitionRecord> entities,
        bool autoSave = false,
        CancellationToken cancellationToken = new())
    {
        var request = new PermissionDefinitionRecordInsertManyRequest();
        request.Inputs.AddRange(entities.Select(ToInsertRequest));

        await _client.InsertManyAsync(request, cancellationToken: cancellationToken);
    }

    public async Task<PermissionDefinitionRecord> UpdateAsync(
        PermissionDefinitionRecord entity,
        bool autoSave = false,
        CancellationToken cancellationToken = new())
    {
        var response = await _client.UpdateAsync(
            ToUpdateRequest(entity),
            cancellationToken: cancellationToken);

        return ToEntity(response);
    }

    public async Task UpdateManyAsync(
        IEnumerable<PermissionDefinitionRecord> entities,
        bool autoSave = false,
        CancellationToken cancellationToken = new())
    {
        var request = new PermissionDefinitionRecordUpdateManyRequest();
        request.Inputs.AddRange(entities.Select(ToUpdateRequest));

        await _client.UpdateManyAsync(request, cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(
        PermissionDefinitionRecord entity,
        bool autoSave = false,
        CancellationToken cancellationToken = new())
    {
        await DeleteAsync(entity.Id, autoSave, cancellationToken);
    }

    public async Task DeleteManyAsync(
        IEnumerable<PermissionDefinitionRecord> entities,
        bool autoSave = false,
        CancellationToken cancellationToken = new())
    {
        await DeleteManyAsync(entities.Select(x => x.Id), autoSave, cancellationToken);
    }

    public async Task DeleteAsync(
        Guid id,
        bool autoSave = false,
        CancellationToken cancellationToken = new())
    {
        await _client.DeleteAsync(
            new PermissionDefinitionRecordDeleteRequest { Id = id.ToString() },
            cancellationToken: cancellationToken);
    }

    public async Task DeleteManyAsync(
        IEnumerable<Guid> ids,
        bool autoSave = false,
        CancellationToken cancellationToken = new())
    {
        var request = new PermissionDefinitionRecordDeleteManyRequest();
        request.Ids.AddRange(ids.Select(x => new PermissionDefinitionRecordDeleteRequest { Id = x.ToString() }));

        await _client.DeleteManyAsync(
            request,
            cancellationToken: cancellationToken);
    }

    private static PermissionDefinitionRecord ToEntity(
        PermissionDefinitionRecordResponse response)
    {
        return new PermissionDefinitionRecord(
            Guid.Parse(response.Id),
            response.GroupName,
            response.Name,
            response.ParentName,
            response.DisplayName,
            response.IsEnabled,
            response.MultiTenancySide.ToEntity(),
            response.Providers,
            response.StateCheckers);
    }

    private static PermissionDefinitionRecordInsertRequest ToInsertRequest(PermissionDefinitionRecord entity)
    {
        return new PermissionDefinitionRecordInsertRequest
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

    private static PermissionDefinitionRecordUpdateRequest ToUpdateRequest(PermissionDefinitionRecord entity)
    {
        return new PermissionDefinitionRecordUpdateRequest
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
}
