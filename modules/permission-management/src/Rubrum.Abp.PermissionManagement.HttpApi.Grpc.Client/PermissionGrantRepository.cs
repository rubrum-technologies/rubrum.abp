using Google.Protobuf.WellKnownTypes;
using Rubrum.Abp.PermissionManagement.HttpApi.Grpc;
using Volo.Abp.DependencyInjection;
using Volo.Abp.PermissionManagement;

namespace Rubrum.Abp.PermissionManagement;

[Dependency(ReplaceServices = true)]
public class PermissionGrantRepository : IPermissionGrantRepository, ITransientDependency
{
    private readonly PermissionGrantRepositoryGrpc.PermissionGrantRepositoryGrpcClient _client;

    public PermissionGrantRepository(PermissionGrantRepositoryGrpc.PermissionGrantRepositoryGrpcClient client)
    {
        _client = client;
    }

    public bool? IsChangeTrackingEnabled => false;

    public async Task<PermissionGrant> GetAsync(
        Guid id,
        bool includeDetails = true,
        CancellationToken cancellationToken = default)
    {
        var response = await _client.GetAsync(
            new PermissionGrantGetRequest { Id = id.ToString(), IncludeDetails = includeDetails },
            cancellationToken: cancellationToken);

        return ToEntity(response);
    }

    public async Task<PermissionGrant?> FindAsync(
        Guid id,
        bool includeDetails = true,
        CancellationToken cancellationToken = default)
    {
        var response = await _client.FindAsync(
            new PermissionGrantFindRequest { Id = id.ToString(), IncludeDetails = includeDetails },
            cancellationToken: cancellationToken);

        return ToEntity(response);
    }

    public async Task<PermissionGrant> FindAsync(
        string name,
        string providerName,
        string providerKey,
        CancellationToken cancellationToken = default)
    {
        var response = await _client.FindByNameAsync(
            new PermissionGrantFindByNameRequest
            {
                Name = name,
                ProviderName = providerName,
                ProviderKey = providerKey
            },
            cancellationToken: cancellationToken);

        return ToEntity(response);
    }

    public async Task<List<PermissionGrant>> GetListAsync(
        bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        var response = await _client.GetListAsync(
            new PermissionGrantListRequest { IncludeDetails = includeDetails },
            cancellationToken: cancellationToken);

        return response.Entities.Select(ToEntity).ToList();
    }

    public async Task<List<PermissionGrant>> GetListAsync(
        string providerName,
        string providerKey,
        CancellationToken cancellationToken = default)
    {
        var response = await _client.GetListByProviderAsync(
            new PermissionGrantListByProviderRequest { ProviderName = providerName, ProviderKey = providerKey },
            cancellationToken: cancellationToken);

        return response.Entities.Select(ToEntity).ToList();
    }

    public async Task<List<PermissionGrant>> GetListAsync(
        string[] names,
        string providerName,
        string providerKey,
        CancellationToken cancellationToken = default)
    {
        var response = await _client.GetListByNamesAsync(
            new PermissionGrantListByNamesRequest
            {
                Names = { names },
                ProviderName = providerName,
                ProviderKey = providerKey
            },
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

    public async Task<List<PermissionGrant>> GetPagedListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        var response = await _client.GetListAsync(
            new PermissionGrantListRequest { IncludeDetails = includeDetails },
            cancellationToken: cancellationToken);

        return response.Entities.Select(ToEntity).ToList();
    }

    public async Task<PermissionGrant> InsertAsync(
        PermissionGrant entity,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        var response = await _client.InsertAsync(
            ToInsertRequest(entity),
            cancellationToken: cancellationToken);

        return ToEntity(response);
    }

    public async Task InsertManyAsync(
        IEnumerable<PermissionGrant> entities,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        var request = new PermissionGrantInsertManyRequest();
        request.Inputs.AddRange(entities.Select(ToInsertRequest));

        await _client.InsertManyAsync(request, cancellationToken: cancellationToken);
    }

    public async Task<PermissionGrant> UpdateAsync(
        PermissionGrant entity,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        var response = await _client.UpdateAsync(
            ToUpdateRequest(entity),
            cancellationToken: cancellationToken);

        return ToEntity(response);
    }

    public async Task UpdateManyAsync(
        IEnumerable<PermissionGrant> entities,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        var request = new PermissionGrantUpdateManyRequest();
        request.Inputs.AddRange(entities.Select(ToUpdateRequest));

        await _client.UpdateManyAsync(request, cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(
        PermissionGrant entity,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        await DeleteAsync(entity.Id, autoSave, cancellationToken);
    }

    public async Task DeleteManyAsync(
        IEnumerable<PermissionGrant> entities,
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
            new PermissionGrantDeleteRequest { Id = id.ToString() },
            cancellationToken: cancellationToken);
    }

    public async Task DeleteManyAsync(
        IEnumerable<Guid> ids,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        var request = new PermissionGrantDeleteManyRequest();
        request.Ids.AddRange(ids.Select(x => new PermissionGrantDeleteRequest { Id = x.ToString() }));

        await _client.DeleteManyAsync(
            request,
            cancellationToken: cancellationToken);
    }

    private static PermissionGrant ToEntity(
        PermissionGrantResponse response)
    {
        return new PermissionGrant(
            Guid.Parse(response.Id),
            response.Name,
            response.ProviderName,
            response.ProviderKey,
            string.IsNullOrWhiteSpace(response.TenantId) ? null : Guid.Parse(response.TenantId));
    }

    private static PermissionGrantInsertRequest ToInsertRequest(PermissionGrant entity)
    {
        return new PermissionGrantInsertRequest
        {
            Id = entity.Id.ToString(),
            TenantId = entity.TenantId?.ToString(),
            Name = entity.Name,
            ProviderName = entity.ProviderName,
            ProviderKey = entity.ProviderKey
        };
    }

    private static PermissionGrantUpdateRequest ToUpdateRequest(PermissionGrant entity)
    {
        return new PermissionGrantUpdateRequest
        {
            Id = entity.Id.ToString(),
            TenantId = entity.TenantId?.ToString(),
            Name = entity.Name,
            ProviderName = entity.ProviderName,
            ProviderKey = entity.ProviderKey
        };
    }
}
