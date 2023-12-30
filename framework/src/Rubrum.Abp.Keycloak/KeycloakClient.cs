using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Json;
using Volo.Abp.Threading;

namespace Rubrum.Abp.Keycloak;

public class KeycloakClient(
    IHttpClientFactory httpClientFactory,
    ICurrentKeycloakRealm currentKeycloakRealm,
    IJsonSerializer serializer,
    ICancellationTokenProvider cancellationTokenProvider,
    IOptions<RubrumAbpKeycloakOptions> options)
    : IKeycloakClient, ITransientDependency
{
    protected IHttpClientFactory HttpClientFactory => httpClientFactory;

    protected ICurrentKeycloakRealm CurrentKeycloakRealm => currentKeycloakRealm;

    protected RubrumAbpKeycloakOptions Options => options.Value;

    protected IJsonSerializer Serializer => serializer;

    protected ICancellationTokenProvider CancellationTokenProvider => cancellationTokenProvider;

    protected string RealmName => CurrentKeycloakRealm.RealmName;

    public virtual Task<object> GetBasePathForRetrieveProvidersAsync(CancellationToken cancellationToken = default)
    {
        return GetAsync<object>(
            $"/admin/realms/{RealmName}/client-registration-policy/providers",
            cancellationToken);
    }

    public virtual Task<KeysMetadataRepresentation> GetKeysAsync(CancellationToken cancellationToken = default)
    {
        return GetAsync<KeysMetadataRepresentation>(
            $"/admin/realms/{RealmName}/keys",
            cancellationToken);
    }

    public virtual Task<Dictionary<string, object>> GetUserNameStatusInBruteForceDetectionAsync(
        string userId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<Dictionary<string, object>>(
            $"/admin/realms/{RealmName}/attack-detection/brute-force/users/{userId}",
            cancellationToken);
    }

    public virtual Task ClearUserLoginFailuresAsync(CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/attack-detection/brute-force/users",
            cancellationToken);
    }

    public virtual Task ClearUserLoginFailuresAsync(string userId, CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/attack-detection/brute-force/users/{userId}",
            cancellationToken);
    }

    public virtual Task<AuthenticatorConfigRepresentation> GetAuthenticatorConfigurationAsync(
        string configurationId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<AuthenticatorConfigRepresentation>(
            $"/admin/realms/{RealmName}/authentication/config/{configurationId}",
            cancellationToken);
    }

    public virtual Task<object> GetAuthenticatorProvidersAsync(CancellationToken cancellationToken = default)
    {
        return GetAsync<object>(
            $"/admin/realms/{RealmName}/authentication/authenticator-providers",
            cancellationToken);
    }

    public virtual Task<object> GetClientAuthenticatorProvidersAsync(CancellationToken cancellationToken = default)
    {
        return GetAsync<object>(
            $"/admin/realms/{RealmName}/authentication/client-authenticator-providers",
            cancellationToken);
    }

    public virtual Task<AuthenticatorConfigInfoRepresentation> GetAuthenticatorProvidersConfigurationAsync(
        string providerId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<AuthenticatorConfigInfoRepresentation>(
            $"/admin/realms/{RealmName}/authentication/config-description/{providerId}",
            cancellationToken);
    }

    public virtual Task<object> GetAuthenticationExecutionAsync(
        string executionId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<object>(
            $"/admin/realms/{RealmName}/authentication/executions/{executionId}",
            cancellationToken);
    }

    public virtual Task<AuthenticatorConfigRepresentation> GetAuthenticationExecutionConfigurationAsync(
        string executionId,
        string configurationId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<AuthenticatorConfigRepresentation>(
            $"/admin/realms/{RealmName}/authentication/executions/{executionId}/config/{configurationId}",
            cancellationToken);
    }

    public virtual Task<object> GetAuthenticationExecutionsForFlowAsync(
        string flowAlias,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<object>(
            $"/admin/realms/{RealmName}/authentication/flows/{flowAlias}/executions",
            cancellationToken);
    }

    public virtual Task<AuthenticationFlowRepresentation> GetAuthenticationFlowForIdAsync(
        string flowId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<AuthenticationFlowRepresentation>(
            $"/admin/realms/{RealmName}/authentication/flows/{flowId}",
            cancellationToken);
    }

    public virtual Task<ICollection<AuthenticationFlowRepresentation>> GetAuthenticationFlowsAsync(
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<AuthenticationFlowRepresentation>>(
            $"/admin/realms/{RealmName}/authentication/flows",
            cancellationToken);
    }

    public virtual Task<Dictionary<string, object>> GetFormActionProvidersAsync(
        CancellationToken cancellationToken = default)
    {
        return GetAsync<Dictionary<string, object>>(
            $"/admin/realms/{RealmName}/authentication/form-action-providers",
            cancellationToken);
    }

    public virtual Task<Dictionary<string, object>> GetFormProvidersAsync(CancellationToken cancellationToken = default)
    {
        return GetAsync<Dictionary<string, object>>(
            $"/admin/realms/{RealmName}/authentication/form-providers",
            cancellationToken);
    }

    public virtual Task<Dictionary<string, ConfigPropertyRepresentation>> GetConfigurationForAllClientsAsync(
        CancellationToken cancellationToken = default)
    {
        return GetAsync<Dictionary<string, ConfigPropertyRepresentation>>(
            $"/admin/realms/{RealmName}/authentication/per-client-config-description",
            cancellationToken);
    }

    public virtual Task<RequiredActionProviderRepresentation> GetRequiredActionForAliasAsync(
        string alias,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<RequiredActionProviderRepresentation>(
            $"/admin/realms/{RealmName}/authentication/required-actions/{alias}",
            cancellationToken);
    }

    public virtual Task<ICollection<RequiredActionProviderRepresentation>> GetRequiredActionsAsync(
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RequiredActionProviderRepresentation>>(
            $"/admin/realms/{RealmName}/authentication/required-actions",
            cancellationToken);
    }

    public virtual Task<Dictionary<string, object>> GetUnregisteredRequiredActionsAsync(
        CancellationToken cancellationToken = default)
    {
        return GetAsync<Dictionary<string, object>>(
            $"/admin/realms/{RealmName}/authentication/unregistered-required-actions",
            cancellationToken);
    }

    public virtual Task CreateAuthenticatorConfigurationAsync(
        AuthenticatorConfigRepresentation? authenticatorConfigRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/authentication/config",
            authenticatorConfigRepresentation,
            cancellationToken);
    }

    public virtual Task CopyExistingAuthenticationFlowAsync(
        string flowAlias,
        string? body,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/authentication/flows/{flowAlias}/copy",
            body,
            cancellationToken);
    }

    public virtual Task CreateAuthenticationExecutionToFlowAsync(
        string flowAlias,
        string? body,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/authentication/flows/{flowAlias}/executions/execution",
            body,
            cancellationToken);
    }

    public virtual Task UpdateExecutionWithConfigurationAsync(
        string executionId,
        AuthenticatorConfigRepresentation? authenticatorConfigRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/authentication/executions/{executionId}/config",
            authenticatorConfigRepresentation,
            cancellationToken);
    }

    public virtual Task ExecutionLowerPriorityAsync(string executionId, CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/authentication/executions/{executionId}/lower-priority",
            cancellationToken);
    }

    public virtual Task ExecutionRaisePriorityAsync(string executionId, CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/authentication/executions/{executionId}/raise-priority",
            cancellationToken);
    }

    public virtual Task CreateAuthenticationExecutionAsync(
        AuthenticationExecutionRepresentation? authenticationExecutionRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/authentication/executions",
            authenticationExecutionRepresentation,
            cancellationToken);
    }

    public virtual Task CreateFlowWithNewExecutionAsync(
        string flowAlias,
        string? body,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/authentication/flows/{flowAlias}/executions/flow",
            body,
            cancellationToken);
    }

    public virtual Task CreateAuthenticationFlowAsync(
        AuthenticationFlowRepresentation? authenticationFlowRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/authentication/flows",
            authenticationFlowRepresentation,
            cancellationToken);
    }

    public virtual Task RegisterRequiredActionAsync(string? body, CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/authentication/register-required-action",
            body,
            cancellationToken);
    }

    public virtual Task RequiredActionLowerPriorityAsync(string alias, CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/authentication/required-actions/{alias}/lower-priority",
            cancellationToken);
    }

    public virtual Task RequiredActionRaisePriorityAsync(string alias, CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/authentication/required-actions/{alias}/raise-priority",
            cancellationToken);
    }

    public virtual Task UpdateAuthenticationConfigurationAsync(
        string configurationId,
        AuthenticatorConfigRepresentation? authenticatorConfigRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/authentication/config/{configurationId}",
            authenticatorConfigRepresentation,
            cancellationToken);
    }

    public virtual Task UpdateAuthenticationExecutionsOfFlowAsync(
        string flowAlias,
        AuthenticationExecutionInfoRepresentation? authenticationExecutionInfoRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/authentication/flows/{flowAlias}/executions",
            authenticationExecutionInfoRepresentation,
            cancellationToken);
    }

    public virtual Task UpdateAuthenticationFlowAsync(
        string flowId,
        AuthenticationFlowRepresentation? authenticationFlowRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/authentication/flows/{flowId}",
            authenticationFlowRepresentation,
            cancellationToken);
    }

    public virtual Task UpdateRequiredActionAsync(
        string alias,
        RequiredActionProviderRepresentation? requiredActionProviderRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/authentication/required-actions/{alias}",
            requiredActionProviderRepresentation,
            cancellationToken);
    }

    public virtual Task DeleteAuthenticatorConfigurationAsync(
        string configurationId,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/authentication/config/{configurationId}",
            cancellationToken);
    }

    public virtual Task DeleteExecutionAsync(string executionId, CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/authentication/executions/{executionId}",
            cancellationToken);
    }

    public virtual Task DeleteAuthenticationFlowAsync(string flowId, CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/authentication/flows/{flowId}",
            cancellationToken);
    }

    public virtual Task DeleteRequiredActionAsync(string alias, CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/authentication/required-actions/{alias}",
            cancellationToken);
    }

    public virtual Task<CertificateRepresentation> GetCertificateAsync(
        string id,
        string attribute,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<CertificateRepresentation>(
            $"/admin/realms/{RealmName}/clients/{id}/certificates/{attribute}",
            cancellationToken);
    }

    public virtual Task<Stream> GetKeystoreFileForClientAsync(
        string clientId,
        string attribute,
        KeyStoreConfig? keyStoreConfig,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<Stream>(
            $"/admin/realms/{RealmName}/clients/{clientId}/certificates/{attribute}/download",
            cancellationToken);
    }

    public virtual Task<CertificateRepresentation> GenerateCertificateAsync(
        string clientId,
        string attribute,
        CancellationToken cancellationToken = default)
    {
        return PostAsync<CertificateRepresentation, object>(
            $"/admin/realms/{RealmName}/clients/{clientId}/certificates/{attribute}/generate",
            null,
            cancellationToken);
    }

    public virtual Task<Stream> GenerateKeypairAndCertificateAsync(
        string clientId,
        string attribute,
        KeyStoreConfig? keyStoreConfig,
        CancellationToken cancellationToken = default)
    {
        return PostAsync<Stream, KeyStoreConfig>(
            $"/admin/realms/{RealmName}/clients/{clientId}/certificates/{attribute}/generate-and-download",
            keyStoreConfig,
            cancellationToken);
    }

    public virtual Task<CertificateRepresentation> UploadCertificateAndPrivateKeyAsync(
        string clientId,
        string attribute,
        Stream file,
        CancellationToken cancellationToken = default)
    {
        return PostAsync<CertificateRepresentation, Stream>(
            $"/admin/realms/{RealmName}/clients/{clientId}/certificates/{attribute}/upload",
            file,
            cancellationToken);
    }

    public virtual Task<CertificateRepresentation> UploadOnlyCertificateAsync(
        string clientId,
        string attribute,
        Stream file,
        CancellationToken cancellationToken = default)
    {
        return PostAsync<CertificateRepresentation, Stream>(
            $"/admin/realms/{RealmName}/clients/{clientId}/certificates/{attribute}/upload-certificate",
            file,
            cancellationToken);
    }

    public virtual Task<ICollection<ClientInitialAccessPresentation>> GetClientInitialAccessAsync(
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<ClientInitialAccessPresentation>>(
            $"/admin/realms/{RealmName}/clients-initial-access",
            cancellationToken);
    }

    public virtual Task<ClientInitialAccessPresentation> CreateInitialAccessTokenAsync(
        ClientInitialAccessCreatePresentation? clientInitialAccessCreatePresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync<ClientInitialAccessPresentation, ClientInitialAccessCreatePresentation>(
            $"/admin/realms/{RealmName}/clients-initial-access",
            clientInitialAccessCreatePresentation,
            cancellationToken);
    }

    public virtual Task DeleteInitialAccessTokenAsync(string id, CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/clients-initial-access/{id}",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetGroupRoleMappingsClientAsync(
        string groupId,
        string client,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/groups/{groupId}/role-mappings/clients/{client}",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetGroupRoleMappingsClientAvailableAsync(
        string groupId,
        string client,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/groups/{groupId}/role-mappings/clients/{client}/available",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetGroupRoleMappingsClientCompositeAsync(
        string groupId,
        string client,
        bool briefRepresentation = true,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "briefRepresentation", briefRepresentation } };

        return GetAsync<ICollection<RoleRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/groups/{groupId}/role-mappings/clients/{client}/composite", queries),
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetUserRoleMappingsClientAsync(
        string userId,
        string client,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/users/{userId}/role-mappings/clients/{client}",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetUserRoleMappingsClientAvailableAsync(
        string userId,
        string client,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/users/{userId}/role-mappings/clients/{client}/available",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetUserRoleMappingsClientCompositeAsync(
        string userId,
        string client,
        bool briefRepresentation = true,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "briefRepresentation", briefRepresentation } };

        return GetAsync<ICollection<RoleRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/users/{userId}/role-mappings/clients/{client}/composite", queries),
            cancellationToken);
    }

    public virtual Task ChangeGroupRoleMappingsClientAsync(
        string groupId,
        string client,
        RoleRepresentation roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/groups/{groupId}/role-mappings/clients/{client}",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task ChangeUserRoleMappingsClientAsync(
        string userId,
        string client,
        RoleRepresentation roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/users/{userId}/role-mappings/clients/{client}",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task DeleteGroupRoleMappingsClientAsync(
        string groupId,
        string client,
        RoleRepresentation roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/groups/{groupId}/role-mappings/clients/{client}",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task DeleteUserRoleMappingsClientAsync(
        string userId,
        string client,
        RoleRepresentation roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/users/{userId}/role-mappings/clients/{client}",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task<ClientRepresentation> GetClientByIdAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ClientRepresentation>(
            $"/admin/realms/{RealmName}/clients/{clientId}",
            cancellationToken);
    }

    public virtual Task<ManagementPermissionReference> GetClientManagementPermissionsAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ManagementPermissionReference>(
            $"/admin/realms/{RealmName}/clients/{clientId}/management/permissions",
            cancellationToken);
    }

    public virtual Task<CredentialRepresentation> GetClientSecretAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<CredentialRepresentation>(
            $"/admin/realms/{RealmName}/clients/{clientId}/client-secret",
            cancellationToken);
    }

    public virtual Task<ICollection<UserSession>> GetClientUserSessionsAsync(
        string clientId,
        int? first = null,
        int? max = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "first", first }, { "max", max } };

        return GetAsync<ICollection<UserSession>>(
            SetQuery($"/admin/realms/{RealmName}/clients/{clientId}/user-sessions", queries),
            cancellationToken);
    }

    public virtual Task<ICollection<ClientRepresentation>> GetClientsAsync(
        string? clientId = null,
        int? first = null,
        int? max = null,
        string? q = null,
        string? search = null,
        bool? viewableOnly = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?>
        {
            { "clientId", clientId },
            { "first", first },
            { "max", max },
            { "q", q },
            { "search", search },
            { "viewableOnly", viewableOnly }
        };

        return GetAsync<ICollection<ClientRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/clients", queries),
            cancellationToken);
    }

    public virtual Task<ICollection<ClientScopeRepresentation>> GetDefaultClientScopesAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<ClientScopeRepresentation>>(
            $"/admin/realms/{RealmName}/clients/{clientId}/default-client-scopes",
            cancellationToken);
    }

    public virtual Task<AccessToken> GetGenerateExampleAccessTokenAsync(
        string clientId,
        string? scope = null,
        string? userId = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "scope", scope }, { "userId", userId } };

        return GetAsync<AccessToken>(
            SetQuery(
                $"/admin/realms/{RealmName}/clients/{clientId}/evaluate-scopes/generate-example-access-token",
                queries),
            cancellationToken);
    }

    public virtual Task<IdToken> GetGenerateExampleIdTokenAsync(
        string clientId,
        string? scope = null,
        string? userId = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "scope", scope }, { "userId", userId } };

        return GetAsync<IdToken>(
            SetQuery(
                $"/admin/realms/{RealmName}/clients/{clientId}/evaluate-scopes/generate-example-id-token",
                queries),
            cancellationToken);
    }

    public virtual Task<Dictionary<string, object>> GetGenerateExampleUserInfoAsync(
        string clientId,
        string? scope = null,
        string? userId = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "scope", scope }, { "userId", userId } };

        return GetAsync<Dictionary<string, object>>(
            SetQuery(
                $"/admin/realms/{RealmName}/clients/{clientId}/evaluate-scopes/generate-example-userinfo",
                queries),
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetGrantedAsync(
        string clientId,
        string roleContainerId,
        string? scope = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "scope", scope } };

        return GetAsync<ICollection<RoleRepresentation>>(
            SetQuery(
                $"/admin/realms/{RealmName}/clients/{clientId}/evaluate-scopes/scope-mappings/{roleContainerId}/granted",
                queries),
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetNotGrantedAsync(
        string clientId,
        string roleContainerId,
        string? scope = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "scope", scope } };

        return GetAsync<ICollection<RoleRepresentation>>(
            SetQuery(
                $"/admin/realms/{RealmName}/clients/{clientId}/evaluate-scopes/scope-mappings/{roleContainerId}/not-granted",
                queries),
            cancellationToken);
    }

    public virtual Task<Dictionary<string, long>> GetOfflineSessionCountAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<Dictionary<string, long>>(
            $"/admin/realms/{RealmName}/clients/{clientId}/offline-session-count",
            cancellationToken);
    }

    public virtual Task<ICollection<UserSession>> GetOfflineSessionsAsync(
        string clientId,
        int? first = null,
        int? max = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "first", first }, { "max", max } };

        return GetAsync<ICollection<UserSession>>(
            SetQuery($"/admin/realms/{RealmName}/clients/{clientId}/offline-sessions", queries),
            cancellationToken);
    }

    public virtual Task<ICollection<ClientScopeRepresentation>> GetOptionalClientScopesAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<ClientScopeRepresentation>>(
            $"/admin/realms/{RealmName}/clients/{clientId}/optional-client-scopes",
            cancellationToken);
    }

    public virtual Task<ICollection<ClientScopeEvaluateResourceProtocolMapperEvaluation>>
        GetProtocolMappersInTokenGenerationAsync(
            string clientId,
            string? scope = null,
            CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "scope", scope } };

        return GetAsync<ICollection<ClientScopeEvaluateResourceProtocolMapperEvaluation>>(
            SetQuery($"/admin/realms/{RealmName}/clients/{clientId}/evaluate-scopes/protocol-mappers", queries),
            cancellationToken);
    }

    public virtual Task<CredentialRepresentation> GetRotatedClientSecretAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<CredentialRepresentation>(
            $"/admin/realms/{RealmName}/clients/{clientId}/client-secret/rotated",
            cancellationToken);
    }

    public virtual Task<UserRepresentation> GetServiceAccountUserAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<UserRepresentation>(
            $"/admin/realms/{RealmName}/clients/{clientId}/service-account-user",
            cancellationToken);
    }

    public virtual Task<Dictionary<string, long>> GetSessionCountAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<Dictionary<string, long>>(
            $"/admin/realms/{RealmName}/clients/{clientId}/session-count",
            cancellationToken);
    }

    public virtual Task<GlobalRequestResult> GetTestNodesAvailableAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<GlobalRequestResult>(
            $"/admin/realms/{RealmName}/clients/{clientId}/test-nodes-available",
            cancellationToken);
    }

    public virtual Task<GlobalRequestResult> ClientPushRevocationAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return PostAsync<GlobalRequestResult>(
            $"/admin/realms/{RealmName}/clients/{clientId}/push-revocation",
            cancellationToken);
    }

    public virtual Task<CredentialRepresentation> GenerateClientSecretAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return PostAsync<CredentialRepresentation>(
            $"/admin/realms/{RealmName}/clients/{clientId}/client-secret",
            cancellationToken);
    }

    public virtual Task CreateClientAsync(
        ClientRepresentation? clientRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/clients",
            clientRepresentation,
            cancellationToken);
    }

    public virtual Task RegisterClusterNodeWithClientAsync(
        string clientId,
        string? body = null,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/nodes",
            body,
            cancellationToken);
    }

    public virtual Task<ClientRepresentation> GenerateRegistrationAccessTokenAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return PostAsync<ClientRepresentation>(
            $"/admin/realms/{RealmName}/clients/{clientId}/registration-access-token",
            cancellationToken);
    }

    public virtual Task UpdateClientAsync(
        string clientId,
        ClientRepresentation? clientRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}",
            clientRepresentation,
            cancellationToken);
    }

    public virtual Task<ManagementPermissionReference> UpdateClientManagementPermissionsAsync(
        string clientId,
        ManagementPermissionReference? managementPermissionReference,
        CancellationToken cancellationToken = default)
    {
        return PutAsync<ManagementPermissionReference, ManagementPermissionReference>(
            $"/admin/realms/{RealmName}/clients/{clientId}/management/permissions",
            managementPermissionReference,
            cancellationToken);
    }

    public virtual Task UpdateDefaultClientScopeAsync(
        string clientId,
        string clientScopeId,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/default-client-scopes/{clientScopeId}",
            cancellationToken);
    }

    public virtual Task UpdateOptionalClientScopeAsync(
        string clientId,
        string clientScopeId,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/optional-client-scopes/{clientScopeId}",
            cancellationToken);
    }

    public virtual Task DeleteClientByIdAsync(string clientId, CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}",
            cancellationToken);
    }

    public virtual Task DeleteDefaultClientScopeAsync(
        string clientScopeId,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/clients/{clientScopeId}/default-client-scopes/{clientScopeId}",
            cancellationToken);
    }

    public virtual Task DeleteDefaultClientScopeAsync(
        string clientId,
        string clientScopeId,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/default-client-scopes/{clientScopeId}",
            cancellationToken);
    }

    public virtual Task UnregisterClusterNodeFromClient(
        string clientId,
        string node,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/nodes/{node}",
            cancellationToken);
    }

    public virtual Task DeleteOptionalClientScopeAsync(
        string clientId,
        string clientScopeId,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/optional-client-scopes/{clientScopeId}",
            cancellationToken);
    }

    public virtual Task DeleteRotatedAsync(string clientId, CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/client-secret/rotated",
            cancellationToken);
    }

    public virtual Task<ClientScopeRepresentation> GetClientScopeAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ClientScopeRepresentation>(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}",
            cancellationToken);
    }

    public virtual Task<ICollection<ClientScopeRepresentation>> GetClientScopesAsync(
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<ClientScopeRepresentation>>(
            $"/admin/realms/{RealmName}/client-scopes",
            cancellationToken);
    }

    public virtual Task<ClientScopeRepresentation> GetClientTemplateAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ClientScopeRepresentation>(
            $"/admin/realms/{RealmName}/client-templates/{clientId}",
            cancellationToken);
    }

    public virtual Task<ICollection<ClientScopeRepresentation>> GetClientTemplatesAsync(
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<ClientScopeRepresentation>>(
            $"/admin/realms/{RealmName}/client-templates",
            cancellationToken);
    }

    public virtual Task CreateClientScopeAsync(
        ClientScopeRepresentation? clientScopeRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/client-scopes",
            clientScopeRepresentation,
            cancellationToken);
    }

    public virtual Task CreateClientTemplateAsync(
        ClientScopeRepresentation? clientScopeRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/client-templates",
            clientScopeRepresentation,
            cancellationToken);
    }

    public virtual Task UpdateClientScopeAsync(
        string clientId,
        ClientScopeRepresentation? clientScopeRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}",
            clientScopeRepresentation,
            cancellationToken);
    }

    public virtual Task UpdateClientTemplateAsync(
        string clientId,
        ClientScopeRepresentation? clientScopeRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/client-templates/{clientId}",
            clientScopeRepresentation,
            cancellationToken);
    }

    public virtual Task DeleteClientScopeAsync(string clientId, CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}",
            cancellationToken);
    }

    public virtual Task DeleteClientTemplateAsync(string clientId, CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/client-templates/{clientId}",
            cancellationToken);
    }

    public virtual Task<ComponentRepresentation> GetComponentAsync(
        string componentId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ComponentRepresentation>(
            $"/admin/realms/{RealmName}/components/{componentId}",
            cancellationToken);
    }

    public virtual Task<ICollection<ComponentRepresentation>> GetComponentsAsync(
        string? name = null,
        string? parent = null,
        string? type = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "name", name }, { "parent", parent }, { "type", type } };

        return GetAsync<ICollection<ComponentRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/components", queries),
            cancellationToken);
    }

    public virtual Task<ICollection<ComponentRepresentation>> GetSubComponentTypesAsync(
        string componentId,
        string? type = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "type", type } };

        return GetAsync<ICollection<ComponentRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/components/{componentId}/sub-component-types", queries),
            cancellationToken);
    }

    public virtual Task CreateComponentAsync(
        ComponentRepresentation? componentRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/components",
            componentRepresentation,
            cancellationToken);
    }

    public virtual Task UpdateComponentAsync(
        string componentId,
        ComponentRepresentation? componentRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/components/{componentId}",
            componentRepresentation,
            cancellationToken);
    }

    public virtual Task DeleteComponentAsync(string componentId, CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/components/{componentId}",
            cancellationToken);
    }

    public virtual Task<GroupRepresentation> GetGroupAsync(
        string groupId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<GroupRepresentation>(
            $"/admin/realms/{RealmName}/groups/{groupId}",
            cancellationToken);
    }

    public virtual Task<ManagementPermissionReference> GetGroupManagementPermissionsAsync(
        string groupId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ManagementPermissionReference>(
            $"/admin/realms/{RealmName}/groups/{groupId}/management/permissions",
            cancellationToken);
    }

    public virtual Task<ICollection<GroupRepresentation>> GetGroupsAsync(
        bool? briefRepresentation = true,
        bool? exact = false,
        int? first = null,
        int? max = null,
        bool? populateHierarchy = true,
        string? q = null,
        string? search = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?>
        {
            { "briefRepresentation", briefRepresentation },
            { "exact", exact },
            { "first", first },
            { "max", max },
            { "populateHierarchy", populateHierarchy },
            { "q", q },
            { "search", search }
        };

        return GetAsync<ICollection<GroupRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/groups", queries),
            cancellationToken);
    }

    public virtual Task<Dictionary<string, long>> GetGroupsCountAsync(
        string? search = null,
        bool? top = false,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "search", search }, { "top", top } };

        return GetAsync<Dictionary<string, long>>(
            SetQuery($"/admin/realms/{RealmName}/groups/count", queries),
            cancellationToken);
    }

    public virtual Task<ICollection<UserRepresentation>> GetGroupUsersAsync(
        string groupId,
        bool? briefRepresentation = null,
        int? first = null,
        int? max = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?>
        {
            { "briefRepresentation", briefRepresentation }, { "first", first }, { "max", max }
        };

        return GetAsync<ICollection<UserRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/groups/{groupId}/members", queries),
            cancellationToken);
    }

    public virtual Task CreateChildrenAsync(
        string groupId,
        GroupRepresentation? groupRepresentation = null,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/groups/{groupId}/children",
            groupRepresentation,
            cancellationToken);
    }

    public virtual Task CreateGroupAsync(
        GroupRepresentation? groupRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/groups",
            groupRepresentation,
            cancellationToken);
    }

    public virtual Task UpdateGroupByIdAsync(
        string groupId,
        GroupRepresentation? groupRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/groups/{groupId}",
            groupRepresentation,
            cancellationToken);
    }

    public virtual Task<ManagementPermissionReference> UpdateGroupManagementPermissionsAsync(
        string groupId,
        ManagementPermissionReference? managementPermissionReference,
        CancellationToken cancellationToken = default)
    {
        return PutAsync<ManagementPermissionReference, ManagementPermissionReference>(
            $"/admin/realms/{RealmName}/groups/{groupId}/management/permissions",
            managementPermissionReference,
            cancellationToken);
    }

    public virtual Task DeleteGroupByIdAsync(string groupId, CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/groups/{groupId}",
            cancellationToken);
    }

    public virtual Task<Stream> ExportAsync(
        string alias,
        string? format,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "format", format } };

        return GetAsync<Stream>(
            SetQuery($"/admin/realms/{RealmName}/identity-provider/instances/{alias}/export", queries),
            cancellationToken);
    }

    public virtual Task<IdentityProviderRepresentation> GetIdentityProviderAsync(
        string alias,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<IdentityProviderRepresentation>(
            $"/admin/realms/{RealmName}/identity-provider/instances/{alias}",
            cancellationToken);
    }

    public virtual Task<ManagementPermissionReference> GetManagementPermissionsAsync(
        string alias,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ManagementPermissionReference>(
            $"/admin/realms/{RealmName}/identity-provider/instances/{alias}/management/permissions",
            cancellationToken);
    }

    public virtual Task<ICollection<IdentityProviderRepresentation>> GetIdentityProvidersAsync(
        string providerId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<IdentityProviderRepresentation>>(
            $"/admin/realms/{RealmName}/identity-provider/providers/{providerId}",
            cancellationToken);
    }

    public virtual Task<ICollection<IdentityProviderRepresentation>> GetIdentityProvidersAsync(
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<IdentityProviderRepresentation>>(
            $"/admin/realms/{RealmName}/identity-provider/instances",
            cancellationToken);
    }

    public virtual Task<ICollection<IdentityProviderMapperRepresentation>> GetIdentityProviderMappersAsync(
        string alias,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<IdentityProviderMapperRepresentation>>(
            $"/admin/realms/{RealmName}/identity-provider/instances/{alias}/mappers",
            cancellationToken);
    }

    public virtual Task<IdentityProviderMapperRepresentation> GetIdentityProviderMappersAsync(
        string alias,
        string mapperId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<IdentityProviderMapperRepresentation>(
            $"/admin/realms/{RealmName}/identity-provider/instances/{alias}/mappers/{mapperId}",
            cancellationToken);
    }

    public virtual Task<Dictionary<string, IdentityProviderMapperTypeRepresentation>>
        GetIdentityProviderMapperTypesAsync(string alias, CancellationToken cancellationToken = default)
    {
        return GetAsync<Dictionary<string, IdentityProviderMapperTypeRepresentation>>(
            $"/admin/realms/{RealmName}/identity-provider/instances/{alias}/mapper-types",
            cancellationToken);
    }

    public virtual Task<Dictionary<string, string>> ImportIdentityProviderAsync(
        object? body,
        CancellationToken cancellationToken = default)
    {
        return PostAsync<Dictionary<string, string>, object>(
            $"/admin/realms/{RealmName}/identity-provider/import-config",
            body,
            cancellationToken);
    }

    public virtual Task CreateIdentityProviderAsync(
        IdentityProviderRepresentation? identityProviderRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/identity-provider/instances",
            identityProviderRepresentation,
            cancellationToken);
    }

    public virtual Task CreateMapperForIdentityProviderAsync(
        string alias,
        IdentityProviderMapperRepresentation? identityProviderMapperRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/identity-provider/instances/{alias}/mappers",
            identityProviderMapperRepresentation,
            cancellationToken);
    }

    public virtual Task UpdateIdentityProviderAsync(
        string alias,
        IdentityProviderRepresentation? identityProviderRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/identity-provider/instances/{alias}",
            identityProviderRepresentation,
            cancellationToken);
    }

    public virtual Task<ManagementPermissionReference> UpdateManagementPermissionsAsync(
        string alias,
        ManagementPermissionReference? managementPermissionReference,
        CancellationToken cancellationToken = default)
    {
        return PutAsync<ManagementPermissionReference, ManagementPermissionReference>(
            $"/admin/realms/{RealmName}/identity-provider/instances/{alias}/management/permissions",
            managementPermissionReference,
            cancellationToken);
    }

    public virtual Task UpdateMapperForIdentityProviderAsync(
        string alias,
        string mapperId,
        IdentityProviderMapperRepresentation? identityProviderMapperRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/identity-provider/instances/{alias}/mappers/{mapperId}",
            identityProviderMapperRepresentation,
            cancellationToken);
    }

    public virtual Task DeleteIdentityProviderAsync(string alias, CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/identity-provider/instances/{alias}",
            cancellationToken);
    }

    public virtual Task DeleteMapperForIdentityProviderAsync(
        string alias,
        string mapperId,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/identity-provider/instances/{alias}/mappers/{mapperId}",
            cancellationToken);
    }

    public virtual Task<ProtocolMapperRepresentation> GetProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ProtocolMapperRepresentation>(
            $"/admin/realms/{RealmName}/clients/{clientId}/protocol-mappers/models/{protocolMapperId}",
            cancellationToken);
    }

    public virtual Task<ICollection<ProtocolMapperRepresentation>> GetProtocolMappersAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<ProtocolMapperRepresentation>>(
            $"/admin/realms/{RealmName}/clients/{clientId}/protocol-mappers/models",
            cancellationToken);
    }

    public virtual Task<ICollection<ProtocolMapperRepresentation>> GetProtocolMappersAsync(
        string clientId,
        string protocol,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<ProtocolMapperRepresentation>>(
            $"/admin/realms/{RealmName}/clients/{clientId}/protocol-mappers/protocol/{protocol}",
            cancellationToken);
    }

    public virtual Task<ProtocolMapperRepresentation> GetClientScopeProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ProtocolMapperRepresentation>(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}/protocol-mappers/models/{protocolMapperId}",
            cancellationToken);
    }

    public virtual Task<ICollection<ProtocolMapperRepresentation>> GetClientScopeProtocolMappersAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<ProtocolMapperRepresentation>>(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}/protocol-mappers/models",
            cancellationToken);
    }

    public virtual Task<ICollection<ProtocolMapperRepresentation>> GetClientScopeProtocolMappersAsync(
        string clientId,
        string protocol,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<ProtocolMapperRepresentation>>(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}/protocol-mappers/protocol/{protocol}",
            cancellationToken);
    }

    public virtual Task<ProtocolMapperRepresentation> GetClientTemplateProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ProtocolMapperRepresentation>(
            $"/admin/realms/{RealmName}/client-templates/{clientId}/protocol-mappers/models/{protocolMapperId}",
            cancellationToken);
    }

    public virtual Task<ICollection<ProtocolMapperRepresentation>> GetClientTemplateProtocolMappersAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<ProtocolMapperRepresentation>>(
            $"/admin/realms/{RealmName}/client-templates/{clientId}/protocol-mappers/models",
            cancellationToken);
    }

    public virtual Task<ICollection<ProtocolMapperRepresentation>> GetClientTemplateProtocolMappersAsync(
        string clientId,
        string protocol,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<ProtocolMapperRepresentation>>(
            $"/admin/realms/{RealmName}/client-templates/{clientId}/protocol-mappers/protocol/{protocol}",
            cancellationToken);
    }

    public Task CreateClientProtocolMapperAsync(
        string clientId,
        ProtocolMapperRepresentation? protocolMapperRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/protocol-mappers/models",
            protocolMapperRepresentation,
            cancellationToken);
    }

    public virtual Task CreateClientMultipleProtocolMappersAsync(
        string clientId,
        ICollection<ProtocolMapperRepresentation>? protocolMapperRepresentations,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/protocol-mappers/add-models",
            protocolMapperRepresentations,
            cancellationToken);
    }

    public virtual Task CreateClientScopeMultipleProtocolMappersAsync(
        string clientId,
        ICollection<ProtocolMapperRepresentation>? protocolMapperRepresentations,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}/protocol-mappers/add-models",
            protocolMapperRepresentations,
            cancellationToken);
    }

    public virtual Task CreateClientScopeProtocolMapperAsync(
        string clientId,
        ProtocolMapperRepresentation? protocolMapperRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}/protocol-mappers/models",
            protocolMapperRepresentation,
            cancellationToken);
    }

    public virtual Task CreateClientTemplateProtocolMapperAsync(
        string clientId,
        ProtocolMapperRepresentation? protocolMapperRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/client-templates/{clientId}/protocol-mappers/models",
            protocolMapperRepresentation,
            cancellationToken);
    }

    public virtual Task CreateClientTemplateMultipleProtocolMappersAsync(
        string clientId,
        ICollection<ProtocolMapperRepresentation>? protocolMapperRepresentations,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/client-templates/{clientId}/protocol-mappers/add-models",
            protocolMapperRepresentations,
            cancellationToken);
    }

    public virtual Task UpdateClientProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        ProtocolMapperRepresentation? protocolMapperRepresentation = null,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/protocol-mappers/models/{protocolMapperId}",
            protocolMapperRepresentation,
            cancellationToken);
    }

    public virtual Task UpdateClientScopeProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        ProtocolMapperRepresentation? protocolMapperRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}/protocol-mappers/models/{protocolMapperId}",
            protocolMapperRepresentation,
            cancellationToken);
    }

    public virtual Task UpdateClientTemplateProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        ProtocolMapperRepresentation? protocolMapperRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/client-templates/{clientId}/protocol-mappers/models/{protocolMapperId}",
            protocolMapperRepresentation,
            cancellationToken);
    }

    public virtual Task DeleteClientProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/protocol-mappers/models/{protocolMapperId}",
            cancellationToken);
    }

    public virtual Task DeleteClientScopeProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}/protocol-mappers/models/{protocolMapperId}",
            cancellationToken);
    }

    public virtual Task DeleteClientTemplateProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/client-templates/{clientId}/protocol-mappers/models/{protocolMapperId}",
            cancellationToken);
    }

    public virtual Task<ICollection<RealmRepresentation>> GetAccessibleRealmsAsync(
        bool? briefRepresentation = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "briefRepresentation", briefRepresentation } };

        return GetAsync<ICollection<RealmRepresentation>>(
            SetQuery("/", queries),
            cancellationToken);
    }

    public virtual Task<ICollection<AdminEvent>> GetAdminEventsAsync(
        string? authClient = null,
        string? authIpAddress = null,
        string? authRealm = null,
        string? authUser = null,
        DateTime? dateFrom = null,
        DateTime? dateTo = null,
        int? first = null,
        int? max = 100,
        string? operationTypes = null,
        string? resourcePath = null,
        string? resourceTypes = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?>
        {
            { "authClient", authClient },
            { "authIpAddress", authIpAddress },
            { "authRealm", authRealm },
            { "authUser", authUser },
            { "dateFrom", dateFrom },
            { "dateTo", dateTo },
            { "first", first },
            { "max", max },
            { "operationTypes", operationTypes },
            { "resourcePath", resourcePath },
            { "resourceTypes", resourceTypes }
        };

        return GetAsync<ICollection<AdminEvent>>(
            SetQuery($"/admin/realms/{RealmName}/admin-events", queries),
            cancellationToken);
    }

    public virtual Task<RealmRepresentation> GetRealmAsync(CancellationToken cancellationToken = default)
    {
        return GetAsync<RealmRepresentation>(
            $"/admin/realms/{RealmName}",
            cancellationToken);
    }

    public virtual Task<RealmRepresentation> GetRealmAsync(
        string realmName,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<RealmRepresentation>(
            $"/admin/realms/{realmName}",
            cancellationToken);
    }

    public virtual Task<Dictionary<string, object>> GetClientSessionStatsAsync(
        CancellationToken cancellationToken = default)
    {
        return GetAsync<Dictionary<string, object>>(
            $"/admin/realms/{RealmName}/client-session-stats",
            cancellationToken);
    }

    public virtual Task<object> GetCredentialRegistratorsAsync(CancellationToken cancellationToken = default)
    {
        return GetAsync<object>(
            $"/admin/realms/{RealmName}/credential-registrators",
            cancellationToken);
    }

    public virtual Task<ICollection<ClientScopeRepresentation>> GetDefaultDefaultClientScopesAsync(
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<ClientScopeRepresentation>>(
            $"/admin/realms/{RealmName}/default-default-client-scopes",
            cancellationToken);
    }

    public virtual Task<ICollection<GroupRepresentation>> GetDefaultGroupsAsync(
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<GroupRepresentation>>(
            $"/admin/realms/{RealmName}/default-groups",
            cancellationToken);
    }

    public virtual Task<ICollection<ClientScopeRepresentation>> GetDefaultOptionalClientScopesAsync(
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<ClientScopeRepresentation>>(
            $"/admin/realms/{RealmName}/default-optional-client-scopes",
            cancellationToken);
    }

    public virtual Task<ICollection<KeycloakEvent>> GetEventsAsync(
        string? client = null,
        DateTime? dateFrom = null,
        DateTime? dateTo = null,
        int? first = null,
        string? ipAddress = null,
        int? max = 100,
        string? type = null,
        string? user = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?>
        {
            { "client", client },
            { "dateFrom", dateFrom },
            { "dateTo", dateTo },
            { "first", first },
            { "ipAddress", ipAddress },
            { "max", max },
            { "type", type },
            { "user", user }
        };

        return GetAsync<ICollection<KeycloakEvent>>(
            SetQuery($"/admin/realms/{RealmName}/events", queries),
            cancellationToken);
    }

    public virtual Task<RealmEventsConfigRepresentation> GetEventsConfigurationAsync(
        CancellationToken cancellationToken = default)
    {
        return GetAsync<RealmEventsConfigRepresentation>(
            $"/admin/realms/{RealmName}/events/config",
            cancellationToken);
    }

    public virtual Task<GroupRepresentation> GetGroupByPathAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<GroupRepresentation>(
            $"/admin/realms/{RealmName}/group-by-path/{path}",
            cancellationToken);
    }

    public virtual Task<Dictionary<string, string>> GetLocalizationAsync(CancellationToken cancellationToken = default)
    {
        return GetAsync<Dictionary<string, string>>(
            $"/admin/realms/{RealmName}/localization",
            cancellationToken);
    }

    public virtual Task<Dictionary<string, string>> GetLocalizationByLocaleAsync(
        string locale,
        string? useRealmDefaultLocaleFallback = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?>
        {
            { "useRealmDefaultLocaleFallback", useRealmDefaultLocaleFallback }
        };

        return GetAsync<Dictionary<string, string>>(
            SetQuery($"/admin/realms/{RealmName}/localization/{locale}", queries),
            cancellationToken);
    }

    public virtual Task<string> GetLocalizationByLocaleByKeyAsync(
        string locale,
        string key,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<string>(
            $"/admin/realms/{RealmName}/localization/{locale}/{key}",
            cancellationToken);
    }

    public virtual Task<ClientPoliciesRepresentation> GetPoliciesAsync(CancellationToken cancellationToken = default)
    {
        return GetAsync<ClientPoliciesRepresentation>(
            $"/admin/realms/{RealmName}/client-policies/policies",
            cancellationToken);
    }

    public virtual Task<ClientProfilesRepresentation> GetProfilesAsync(
        bool? includeGlobalProfiles = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "includeGlobalProfiles", includeGlobalProfiles } };

        return GetAsync<ClientProfilesRepresentation>(
            SetQuery($"/admin/realms/{RealmName}/client-policies/profiles", queries),
            cancellationToken);
    }

    public virtual Task<ManagementPermissionReference> GetUsersManagementPermissionsAsync(
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ManagementPermissionReference>(
            $"/admin/realms/{RealmName}/users-management-permissions",
            cancellationToken);
    }

    public virtual Task ImportRealmAsync(Stream? body, CancellationToken cancellationToken = default)
    {
        return PostAsync($"/admin/realms/", body, cancellationToken);
    }

    public virtual Task<ClientRepresentation> CreateClientDescriptionConverterAsync(
        string? body,
        CancellationToken cancellationToken = default)
    {
        return PostAsync<ClientRepresentation, string>(
            $"/admin/realms/{RealmName}/client-description-converter",
            body,
            cancellationToken);
    }

    public virtual Task ImportLocalizationAsync(
        string locale,
        string? body,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/localization/{locale}",
            body,
            cancellationToken);
    }

    public virtual Task<GlobalRequestResult> LogoutAllAsync(CancellationToken cancellationToken = default)
    {
        return PostAsync<GlobalRequestResult>(
            $"/admin/realms/{RealmName}/logout-all",
            cancellationToken);
    }

    public virtual Task ExportPartialRealmAsync(
        string? exportClients,
        string? exportGroupsAndRoles,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?>
        {
            { "exportClients", exportClients }, { "exportGroupsAndRoles", exportGroupsAndRoles }
        };

        return PostAsync(
            SetQuery($"/admin/realms/{RealmName}/partial-export", queries),
            cancellationToken);
    }

    public virtual Task ImportPartialRealmAsync(Stream? body, CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/partialImport",
            body,
            cancellationToken);
    }

    public virtual Task<GlobalRequestResult> PushRevocationAsync(CancellationToken cancellationToken = default)
    {
        return PostAsync<GlobalRequestResult>(
            $"/admin/realms/{RealmName}/push-revocation",
            cancellationToken);
    }

    public virtual Task TestSmtpConnectionAsync(string? body, CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/testSMTPConnection",
            body,
            cancellationToken);
    }

    public virtual Task UpdateRealmAsync(
        RealmRepresentation? realmRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync($"/admin/realms/{RealmName}", realmRepresentation, cancellationToken);
    }

    public virtual Task UpdateRealmAsync(
        string realmName,
        RealmRepresentation? realmRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync($"/admin/realms/{RealmName}", realmRepresentation, cancellationToken);
    }

    public virtual Task UpdateDefaultDefaultClientScopeAsync(
        string clientScopeId,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/default-default-client-scopes/{clientScopeId}",
            cancellationToken);
    }

    public virtual Task UpdateDefaultGroupAsync(string groupId, CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/default-groups/{groupId}",
            cancellationToken);
    }

    public virtual Task UpdateDefaultOptionalClientScopeAsync(
        string clientScopeId,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/default-optional-client-scopes/{clientScopeId}",
            cancellationToken);
    }

    public virtual Task UpdateEventsConfigurationAsync(
        RealmEventsConfigRepresentation? realmEventsConfigRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync($"/admin/realms/{RealmName}/events/config", realmEventsConfigRepresentation, cancellationToken);
    }

    public virtual Task UpdateLocalizationAsync(
        string locale,
        string key,
        string? body,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/localization/{locale}/{key}",
            body,
            cancellationToken);
    }

    public virtual Task UpdatePoliciesAsync(
        ClientPoliciesRepresentation? clientPoliciesRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/client-policies/policies",
            clientPoliciesRepresentation,
            cancellationToken);
    }

    public virtual Task UpdateProfilesAsync(
        ClientProfilesRepresentation? clientProfilesRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/client-policies/profiles",
            clientProfilesRepresentation,
            cancellationToken);
    }

    public virtual Task<ManagementPermissionReference> UpdateUsersManagementPermissionsAsync(
        ManagementPermissionReference? managementPermissionReference,
        CancellationToken cancellationToken = default)
    {
        return PutAsync<ManagementPermissionReference, ManagementPermissionReference>(
            $"/admin/realms/{RealmName}/client-policies/profiles",
            managementPermissionReference,
            cancellationToken);
    }

    public virtual Task DeleteAdminEventsAsync(CancellationToken cancellationToken = default)
    {
        return DeleteAsync($"/admin/realms/{RealmName}/admin-events", cancellationToken);
    }

    public virtual Task DeleteRealmAsync(string realmName, CancellationToken cancellationToken = default)
    {
        return DeleteAsync($"/admin/realms/{realmName}", cancellationToken);
    }

    public virtual Task DeleteDefaultGroupAsync(string groupId, CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/default-groups/{groupId}",
            cancellationToken);
    }

    public virtual Task DeleteDefaultOptionalClientScopeAsync(
        string clientScopeId,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/default-optional-client-scopes/{clientScopeId}",
            cancellationToken);
    }

    public virtual Task DeleteEventsAsync(CancellationToken cancellationToken = default)
    {
        return DeleteAsync($"/admin/realms/{RealmName}/events", cancellationToken);
    }

    public virtual Task DeleteLocalizationByLocaleAsync(string locale, CancellationToken cancellationToken = default)
    {
        return DeleteAsync($"/admin/realms/{RealmName}/localization/{locale}", cancellationToken);
    }

    public virtual Task DeleteLocalizationByLocaleByKeyAsync(
        string locale,
        string key,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync($"/admin/realms/{RealmName}/localization/{locale}/{key}", cancellationToken);
    }

    public virtual Task DeleteSessionAsync(string session, CancellationToken cancellationToken = default)
    {
        return DeleteAsync($"/admin/realms/{RealmName}/sessions/{session}", cancellationToken);
    }

    public virtual Task<MappingsRepresentation> GetGroupRoleMappingsAsync(
        string groupId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<MappingsRepresentation>(
            $"/admin/realms/admin/realms/{RealmName}/groups/{groupId}/role-mappings",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetGroupRoleMappingsRealmAsync(
        string groupId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/admin/realms/{RealmName}/groups/{groupId}/role-mappings/realm",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetGroupRoleMappingsRealmAvailableAsync(
        string groupId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/groups/{groupId}/role-mappings/realm/available",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetGroupRoleMappingsRealmCompositeAsync(
        string groupId,
        bool? briefRepresentation = true,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "briefRepresentation", briefRepresentation } };

        return GetAsync<ICollection<RoleRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/groups/{groupId}/role-mappings/realm/composite", queries),
            cancellationToken);
    }

    public virtual Task<MappingsRepresentation> GetUserRoleMappingsAsync(
        string userId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<MappingsRepresentation>(
            $"/admin/realms/{RealmName}/users/{userId}/role-mappings",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetUserRoleMappingsRealmAsync(
        string userId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/users/{userId}/role-mappings/realm",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetUserRoleMappingsRealmAvailableAsync(
        string userId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/users/{userId}/role-mappings/realm/available",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetUserRoleMappingsRealmCompositeAsync(
        string userId,
        bool? briefRepresentation = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "briefRepresentation", briefRepresentation } };

        return GetAsync<ICollection<RoleRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/users/{userId}/role-mappings/realm/composite", queries),
            cancellationToken);
    }

    public virtual Task ChangeGroupRoleMappingsRealmAsync(
        string groupId,
        ICollection<RoleRepresentation>? roleRepresentations,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/groups/{groupId}/role-mappings/realm",
            roleRepresentations,
            cancellationToken);
    }

    public virtual Task ChangeUserRoleMappingsRealmAsync(
        string userId,
        ICollection<RoleRepresentation>? roleRepresentations,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/users/{userId}/role-mappings/realm",
            roleRepresentations,
            cancellationToken);
    }

    public virtual Task DeleteGroupRoleMappingsRealmAsync(
        string groupId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/groups/{groupId}/role-mappings/realm",
            cancellationToken);
    }

    public virtual Task DeleteUserRoleMappingsRealmAsync(
        string userId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/users/{userId}/role-mappings/realm",
            cancellationToken);
    }

    public virtual Task<RoleRepresentation> GetClientRoleAsync(
        string clientId,
        string roleName,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<RoleRepresentation>(
            $"/admin/realms/{RealmName}/clients/{clientId}/roles/{roleName}",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientRoleCompositesAsync(
        string clientId,
        string roleName,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/clients/{clientId}/roles/{roleName}/composites",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientRoleCompositesClientAsync(
        string clientId,
        string roleName,
        string forClientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/clients/{clientId}/roles/{roleName}/composites/clients/{forClientId}",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientRoleCompositesRealmAsync(
        string clientId,
        string roleName,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/clients/{clientId}/roles/{roleName}/composites/realm",
            cancellationToken);
    }

    public virtual Task<ICollection<GroupRepresentation>> GetClientRoleGroupsAsync(
        string clientId,
        string roleName,
        bool? briefRepresentation = true,
        int? first = null,
        int? max = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?>
        {
            { "briefRepresentation", briefRepresentation }, { "first", first }, { "max", max }
        };

        return GetAsync<ICollection<GroupRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/clients/{clientId}/roles/{roleName}/groups", queries),
            cancellationToken);
    }

    public virtual Task<ManagementPermissionReference> GetClientRoleManagementPermissionsAsync(
        string clientId,
        string roleName,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ManagementPermissionReference>(
            $"/admin/realms/{RealmName}/clients/{clientId}/roles/{roleName}/management/permissions",
            cancellationToken);
    }

    public virtual Task<ICollection<UserRepresentation>> GetClientRoleUsersAsync(
        string clientId,
        string roleName,
        int? first = null,
        int? max = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "first", first }, { "max", max } };

        return GetAsync<ICollection<UserRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/clients/{clientId}/roles/{roleName}/users", queries),
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientRolesAsync(
        string clientId,
        bool? briefRepresentation = null,
        int? first = null,
        int? max = null,
        string? search = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?>
        {
            { "briefRepresentation", briefRepresentation }, { "first", first }, { "max", max }, { "search", search }
        };

        return GetAsync<ICollection<RoleRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/clients/{clientId}/roles", queries),
            cancellationToken);
    }

    public virtual Task<RoleRepresentation> GetRoleByNameAsync(
        string roleName,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<RoleRepresentation>($"/admin/realms/{RealmName}/roles/{roleName}", cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetRoleCompositesByNameAsync(
        string roleName,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/roles/{roleName}/composites",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetRoleCompositesClientByNameByClientIdAsync(
        string roleName,
        string clientUuid,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/roles/{roleName}/composites/clients/{clientUuid}",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetRoleCompositesRealmByNameAsync(
        string roleName,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/roles/{roleName}/composites/realm",
            cancellationToken);
    }

    public virtual Task<ICollection<GroupRepresentation>> GetRoleGroupsByNameAsync(
        string roleName,
        bool? briefRepresentation = null,
        int? first = null,
        int? max = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?>
        {
            { "briefRepresentation", briefRepresentation }, { "first", first }, { "max", max }
        };

        return GetAsync<ICollection<GroupRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/roles/{roleName}/groups", queries),
            cancellationToken);
    }

    public virtual Task<ManagementPermissionReference> GetRoleManagementPermissionsByNameAsync(
        string roleName,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ManagementPermissionReference>(
            $"/admin/realms/{RealmName}/roles/{roleName}/management/permissions",
            cancellationToken);
    }

    public virtual Task<ICollection<UserRepresentation>> GetRoleUsersByNameAsync(
        string roleName,
        int? first = null,
        int? max = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "first", first }, { "max", max } };

        return GetAsync<ICollection<UserRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/roles/{roleName}/users", queries),
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetRolesAsync(
        bool? briefRepresentation = null,
        int? first = null,
        int? max = null,
        string? search = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?>
        {
            { "briefRepresentation", briefRepresentation }, { "first", first }, { "max", max }, { "search", search }
        };

        return GetAsync<ICollection<RoleRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/roles", queries),
            cancellationToken);
    }

    public virtual Task CreateClientRoleCompositesAsync(
        string clientId,
        string roleName,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/roles/{roleName}/composites",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task CreateClientRolesAsync(
        string clientId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/roles",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task CreateRoleCompositesByNameAsync(
        string roleName,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/roles/{roleName}/composites",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task CreateRoleAsync(
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/roles",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task UpdateClientRoleAsync(
        string clientId,
        string roleName,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/roles/{roleName}",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task<ManagementPermissionReference> UpdateClientRoleManagementPermissionsAsync(
        string clientId,
        string roleName,
        ManagementPermissionReference? managementPermissionReference,
        CancellationToken cancellationToken = default)
    {
        return PutAsync<ManagementPermissionReference, ManagementPermissionReference>(
            $"/admin/realms/{RealmName}/clients/{clientId}/roles/{roleName}/management/permissions",
            managementPermissionReference,
            cancellationToken);
    }

    public virtual Task UpdateRoleByNameAsync(
        string roleName,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/roles/{roleName}",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task<ManagementPermissionReference> UpdateRoleManagementPermissionsByNameAsync(
        string roleName,
        ManagementPermissionReference? managementPermissionReference,
        CancellationToken cancellationToken = default)
    {
        return PutAsync<ManagementPermissionReference, ManagementPermissionReference>(
            $"/admin/realms/{RealmName}/roles/{roleName}/management/permissions",
            managementPermissionReference,
            cancellationToken);
    }

    public virtual Task DeleteClientRoleAsync(
        string clientId,
        string roleName,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/roles/{roleName}",
            cancellationToken);
    }

    public virtual Task DeleteClientRoleCompositesAsync(
        string clientId,
        string roleName,
        RoleRepresentation roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/roles/{roleName}/composites",
            cancellationToken);
    }

    public virtual Task DeleteRoleByNameAsync(string roleName, CancellationToken cancellationToken = default)
    {
        return DeleteAsync($"/admin/realms/{RealmName}/roles/{roleName}", cancellationToken);
    }

    public virtual Task DeleteRoleCompositesByNameAsync(
        string roleName,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/roles/{roleName}/composites",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task<RoleRepresentation> GetRoleByIdAsync(
        string roleId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<RoleRepresentation>(
            $"/admin/realms/{RealmName}/roles-by-id/{roleId}",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetRoleByIdCompositesAsync(
        string roleId,
        int? first = null,
        int? max = null,
        string? search = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "first", first }, { "max", max }, { "search", search } };

        return GetAsync<ICollection<RoleRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/roles-by-id/{roleId}/composites", queries),
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetRoleByIdCompositesClientAsync(
        string roleId,
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/roles-by-id/{roleId}/composites/clients/{clientId}",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetRoleByIdCompositesRealmAsync(
        string roleId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/roles-by-id/{roleId}/composites/realm",
            cancellationToken);
    }

    public virtual Task<ManagementPermissionReference> GetRoleByIdManagementPermissionsAsync(
        string roleId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ManagementPermissionReference>(
            $"/admin/realms/{RealmName}/roles-by-id/{roleId}/management/permissions",
            cancellationToken);
    }

    public virtual Task CreateRoleByIdCompositesAsync(
        string roleId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/roles-by-id/{roleId}/composites",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task UpdateRoleByIdAsync(
        string roleId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/roles-by-id/{roleId}",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task<ManagementPermissionReference> UpdateRoleByIdManagementPermissionsAsync(
        string roleId,
        ManagementPermissionReference? managementPermissionReference,
        CancellationToken cancellationToken = default)
    {
        return PutAsync<ManagementPermissionReference, ManagementPermissionReference>(
            $"/admin/realms/{RealmName}/roles-by-id/{roleId}/management/permissions",
            managementPermissionReference,
            cancellationToken);
    }

    public virtual Task DeleteRoleByIdAsync(string roleId, CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/roles-by-id/{roleId}",
            cancellationToken);
    }

    public virtual Task DeleteRoleByIdCompositesAsync(
        string roleId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/roles-by-id/{roleId}/composites",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task<MappingsRepresentation> GetClientScopeMappingsAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<MappingsRepresentation>(
            $"/admin/realms/{RealmName}/clients/{clientId}/scope-mappings",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientScopeMappingsClientAsync(
        string clientId,
        string client,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/clients/{clientId}/scope-mappings/clients/{client}",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientScopeMappingsClientAvailableAsync(
        string clientId,
        string client,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/clients/{clientId}/scope-mappings/clients/{client}/available",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientScopeMappingsClientCompositeAsync(
        string clientId,
        string client,
        bool? briefRepresentation = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "briefRepresentation", briefRepresentation } };

        return GetAsync<ICollection<RoleRepresentation>>(
            SetQuery(
                $"/admin/realms/{RealmName}/clients/{clientId}/scope-mappings/clients/{client}/composite",
                queries),
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientScopeMappingsRealmAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/clients/{clientId}/scope-mappings/realm",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientScopeMappingsRealmAvailableAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/clients/{clientId}/scope-mappings/realm/available",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientScopeMappingsRealmCompositeAsync(
        string clientId,
        bool? briefRepresentation = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "briefRepresentation", briefRepresentation } };

        return GetAsync<ICollection<RoleRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/clients/{clientId}/scope-mappings/realm/composite", queries),
            cancellationToken);
    }

    public virtual Task<MappingsRepresentation> GetClientScopeScopeMappingsAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<MappingsRepresentation>(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}/scope-mappings",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientScopeScopeMappingsClientAsync(
        string clientId,
        string client,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}/scope-mappings/clients/{client}",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientScopeScopeMappingsClientAvailableAsync(
        string clientId,
        string client,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}/scope-mappings/clients/{client}/available",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientScopeScopeMappingsClientCompositeAsync(
        string clientId,
        string client,
        bool? briefRepresentation = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "briefRepresentation", briefRepresentation } };

        return GetAsync<ICollection<RoleRepresentation>>(
            SetQuery(
                $"/admin/realms/{RealmName}/client-scopes/{clientId}/scope-mappings/clients/{client}/composite",
                queries),
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientScopeScopeMappingsRealmAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}/scope-mappings/realm",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientScopeScopeMappingsRealmAvailableAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}/scope-mappings/realm/available",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientScopeScopeMappingsRealmCompositeAsync(
        string clientId,
        bool? briefRepresentation = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "briefRepresentation", briefRepresentation } };

        return GetAsync<ICollection<RoleRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/client-scopes/{clientId}/scope-mappings/realm/composite", queries),
            cancellationToken);
    }

    public virtual Task<MappingsRepresentation> GetClientTemplateScopeMappingsAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<MappingsRepresentation>(
            $"/admin/realms/{RealmName}/client-templates/{clientId}/scope-mappings",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientTemplateScopeMappingsClientAsync(
        string clientId,
        string client,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/client-templates/{clientId}/scope-mappings/clients/{client}",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientTemplateScopeMappingsClientAvailableAsync(
        string clientId,
        string client,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/client-templates/{clientId}/scope-mappings/clients/{client}/available",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientTemplateScopeMappingsClientCompositeAsync(
        string clientId,
        string client,
        bool? briefRepresentation = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "briefRepresentation", briefRepresentation } };

        return GetAsync<ICollection<RoleRepresentation>>(
            SetQuery(
                $"/admin/realms/{RealmName}/client-templates/{clientId}/scope-mappings/clients/{client}/composite",
                queries),
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientTemplateScopeMappingsRealmAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/client-templates/{clientId}/scope-mappings/realm",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientTemplateScopeMappingsRealmAvailableAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<RoleRepresentation>>(
            $"/admin/realms/{RealmName}/client-templates/{clientId}/scope-mappings/realm/available",
            cancellationToken);
    }

    public virtual Task<ICollection<RoleRepresentation>> GetClientTemplateScopeMappingsRealmCompositeAsync(
        string clientId,
        bool? briefRepresentation = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "briefRepresentation", briefRepresentation } };

        return GetAsync<ICollection<RoleRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/client-templates/{clientId}/scope-mappings/realm/composite", queries),
            cancellationToken);
    }

    public virtual Task CreateClientScopeMappingsClientAsync(
        string clientId,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/scope-mappings/clients/{client}",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task CreateClientScopeMappingsRealmAsync(
        string clientId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/scope-mappings/realm",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task CreateClientScopeScopeMappingsClientAsync(
        string clientId,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}/scope-mappings/clients/{client}",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task CreateClientScopeScopeMappingsRealmAsync(
        string clientId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}/scope-mappings/realm",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task CreateClientTemplateScopeMappingsClientAsync(
        string clientId,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/client-templates/{clientId}/scope-mappings/clients/{client}",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task CreateClientTemplateScopeMappingsRealmAsync(
        string clientId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/client-templates/{clientId}/scope-mappings/realm",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task DeleteClientScopeMappingsClientAsync(
        string clientId,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/scope-mappings/clients/{client}",
            cancellationToken);
    }

    public virtual Task DeleteClientScopeMappingsRealmAsync(
        string clientId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/clients/{clientId}/scope-mappings/realm",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task DeleteClientScopeScopeMappingsClientAsync(
        string clientId,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}/scope-mappings/clients/{client}",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task DeleteClientScopeScopeMappingsRealmAsync(
        string clientId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/client-scopes/{clientId}/scope-mappings/realm",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task DeleteClientTemplateScopeMappingsClientAsync(
        string clientId,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/client-templates/{clientId}/scope-mappings/clients/{client}",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task DeleteClientTemplateScopeMappingsRealmAsync(
        string clientId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/client-templates/{clientId}/scope-mappings/realm",
            roleRepresentation,
            cancellationToken);
    }

    public virtual Task<object> GetConfiguredUserStorageCredentialTypesAsync(
        string userId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<object>(
            $"/admin/realms/{RealmName}/users/{userId}/configured-user-storage-credential-types",
            cancellationToken);
    }

    public virtual Task<object> GetConsentsAsync(string userId, CancellationToken cancellationToken = default)
    {
        return GetAsync<object>($"/admin/realms/{RealmName}/users/{userId}/consents", cancellationToken);
    }

    public virtual Task<object> GetCredentialsAsync(string userId, CancellationToken cancellationToken = default)
    {
        return GetAsync<object>($"/admin/realms/{RealmName}/users/{userId}/credentials", cancellationToken);
    }

    public virtual Task<ICollection<FederatedIdentityRepresentation>> GetFederatedIdentityAsync(
        string userId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<FederatedIdentityRepresentation>>(
            $"/admin/realms/{RealmName}/users/{userId}/federated-identity",
            cancellationToken);
    }

    public virtual Task<ICollection<UserSession>> GetOfflineSessionAsync(
        string userId,
        string clientId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<UserSession>>(
            $"/admin/realms/{RealmName}/users/{userId}/offline-sessions/{clientId}",
            cancellationToken);
    }

    public virtual Task<string> GetProfileAsync(CancellationToken cancellationToken = default)
    {
        return GetAsync<string>($"/admin/realms/{RealmName}/users/profile", cancellationToken);
    }

    public virtual Task<ICollection<UserSession>> GetSessionsAsync(
        string userId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<ICollection<UserSession>>(
            $"/admin/realms/{RealmName}/users/{userId}/sessions",
            cancellationToken);
    }

    public virtual Task<UserRepresentation> GetUserByIdAsync(
        string userId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<UserRepresentation>($"/admin/realms/{RealmName}/users/{userId}", cancellationToken);
    }

    public virtual Task<ICollection<GroupRepresentation>> GetUserGroupsAsync(
        string userId,
        bool? briefRepresentation = null,
        int? first = null,
        int? max = null,
        string? search = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?>
        {
            { "briefRepresentation", briefRepresentation }, { "first", first }, { "max", max }, { "search", search }
        };

        return GetAsync<ICollection<GroupRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/users/{userId}/groups", queries),
            cancellationToken);
    }

    public virtual Task<Dictionary<string, long>> GetUserGroupsCountAsync(
        string userId,
        string? search = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "search", search } };

        return GetAsync<Dictionary<string, long>>(
            SetQuery($"/admin/realms/{RealmName}/users/{userId}/groups/count", queries),
            cancellationToken);
    }

    public virtual Task<ICollection<UserRepresentation>> GetUsersAsync(
        bool? briefRepresentation = null,
        string? email = null,
        string? emailVerified = null,
        string? enabled = null,
        string? exact = null,
        int? first = null,
        string? firstName = null,
        string? idpAlias = null,
        string? idpUserId = null,
        string? lastName = null,
        int? max = null,
        string? q = null,
        string? search = null,
        string? username = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?>
        {
            { "briefRepresentation", briefRepresentation },
            { "email", email },
            { "emailVerified", emailVerified },
            { "enabled", enabled },
            { "exact", exact },
            { "first", first },
            { "firstName", firstName },
            { "idpAlias", idpAlias },
            { "idpUserId", idpUserId },
            { "lastName", lastName },
            { "max", max },
            { "q", q },
            { "search", search },
            { "username", username }
        };

        return GetAsync<ICollection<UserRepresentation>>(
            SetQuery($"/admin/realms/{RealmName}/users", queries),
            cancellationToken);
    }

    public virtual Task<int> GetUsersCountAsync(
        string? email = null,
        string? emailVerified = null,
        string? enabled = null,
        string? firstName = null,
        string? lastName = null,
        string? q = null,
        string? search = null,
        string? username = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?>
        {
            { "email", email },
            { "emailVerified", emailVerified },
            { "enabled", enabled },
            { "firstName", firstName },
            { "lastName", lastName },
            { "q", q },
            { "search", search },
            { "username", username }
        };

        return GetAsync<int>(
            SetQuery($"/admin/realms/{RealmName}/users/count", queries),
            cancellationToken);
    }

    public virtual Task CreateFederatedIdentityAsync(
        string userId,
        string provider,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/users/{userId}/federated-identity/{provider}",
            cancellationToken);
    }

    public virtual Task<Dictionary<string, object>> ImpersonationUserAsync(
        string userId,
        CancellationToken cancellationToken = default)
    {
        return PostAsync<Dictionary<string, object>>(
            $"/admin/realms/{RealmName}/users/{userId}/impersonation",
            cancellationToken);
    }

    public virtual Task LogoutAsync(string userId, CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/users/{userId}/logout",
            cancellationToken);
    }

    public virtual Task MoveCredentialAfterAsync(
        string userId,
        string credentialId,
        string newPreviousCredentialId,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/users/{userId}/credentials/{credentialId}/moveAfter/{newPreviousCredentialId}",
            cancellationToken);
    }

    public virtual Task MoveCredentialToFirstAsync(
        string userId,
        string credentialId,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"/admin/realms/{RealmName}/users/{userId}/credentials/{credentialId}/moveToFirst",
            cancellationToken);
    }

    public virtual Task CreateUserAsync(
        UserRepresentation? userRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PostAsync($"/admin/realms/{RealmName}/users", userRepresentation, cancellationToken);
    }

    public virtual Task DisableCredentialTypesAsync(
        string userId,
        string? body,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/users/{userId}/disable-credential-types",
            body,
            cancellationToken);
    }

    public virtual Task ExecuteActionsEmailAsync(
        string userId,
        string? clientId = null,
        string? lifespan = null,
        string? redirectUri = null,
        string? body = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?>
        {
            { "clientId", clientId }, { "lifespan", lifespan }, { "redirectUri", redirectUri }
        };

        return PutAsync(
            SetQuery($"/admin/realms/{RealmName}/users/{userId}/execute-actions-email", queries),
            body,
            cancellationToken);
    }

    public virtual Task UpdateProfileAsync(string? body, CancellationToken cancellationToken = default)
    {
        return PutAsync($"/admin/realms/{RealmName}/users/profile", body, cancellationToken);
    }

    public virtual Task ResetPasswordAsync(
        string userId,
        CredentialRepresentation? credentialRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/users/{userId}/reset-password",
            credentialRepresentation,
            cancellationToken);
    }

    public virtual Task ResetPasswordEmailAsync(
        string userId,
        string? clientId = null,
        string? redirectUri = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "clientId", clientId }, { "redirectUri", redirectUri } };

        return PutAsync(
            SetQuery($"/admin/realms/{RealmName}/users/{userId}/reset-password-email", queries),
            cancellationToken);
    }

    public virtual Task SendVerifyEmailAsync(
        string userId,
        string? clientId = null,
        string? redirectUri = null,
        CancellationToken cancellationToken = default)
    {
        var queries = new Dictionary<string, object?> { { "clientId", clientId }, { "redirectUri", redirectUri } };

        return PutAsync(
            SetQuery($"/admin/realms/{RealmName}/users/{userId}/send-verify-email", queries),
            cancellationToken);
    }

    public virtual Task UpdateUserAsync(
        string userId,
        UserRepresentation? userRepresentation,
        CancellationToken cancellationToken = default)
    {
        return PutAsync($"/admin/realms/{RealmName}/users/{userId}", userRepresentation, cancellationToken);
    }

    public virtual Task UpdateUserGroupAsync(
        string userId,
        string groupId,
        CancellationToken cancellationToken = default)
    {
        return PutAsync($"/admin/realms/{RealmName}/users/{userId}/groups/{groupId}", cancellationToken);
    }

    public virtual Task UpdateUserLabelAsync(
        string userId,
        string credentialId,
        string? body,
        CancellationToken cancellationToken = default)
    {
        return PutAsync(
            $"/admin/realms/{RealmName}/users/{userId}/credentials/{credentialId}/userLabel",
            body,
            cancellationToken);
    }

    public virtual Task DeleteConsentAsync(string userId, string client, CancellationToken cancellationToken = default)
    {
        return DeleteAsync($"/admin/realms/{RealmName}/users/{userId}/consents/{client}", cancellationToken);
    }

    public virtual Task DeleteCredentialAsync(
        string userId,
        string credentialId,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync($"/admin/realms/{RealmName}/users/{userId}/credentials/{credentialId}", cancellationToken);
    }

    public virtual Task DeleteFederatedIdentityAsync(
        string userId,
        string provider,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"/admin/realms/{RealmName}/users/{userId}/federated-identity/{provider}",
            cancellationToken);
    }

    public virtual Task DeleteUserByIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        return DeleteAsync($"/admin/realms/{RealmName}/users/{userId}", cancellationToken);
    }

    public virtual Task DeleteUserGroupAsync(
        string userId,
        string groupId,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync($"/admin/realms/{RealmName}/users/{userId}/groups/{groupId}", cancellationToken);
    }

    protected virtual async Task SendAsync<TValue>(
        string path,
        TValue? value,
        HttpMethod method,
        CancellationToken cancellationToken = default)
    {
        cancellationToken = CancellationTokenProvider.FallbackToProvider(cancellationToken);

        using var request = new HttpRequestMessage();

        if (value is not null)
        {
            var content = Serializer.Serialize(value);
            request.Content =
                new StringContent(content, new MediaTypeHeaderValue("application/json") { CharSet = "utf-8" });
        }

        request.Method = method;
        request.RequestUri = CreateUri(path);

        using var httpClient = CreateHttpClient();
        httpClient.DefaultRequestHeaders.Authorization = await GetAuthenticationHeaderAsync();

        using var response = await httpClient.SendAsync(request, cancellationToken);

        response.EnsureSuccessStatusCode();
    }

    protected virtual async Task<TResult> SendAsync<TResult, TValue>(
        string path,
        TValue? value,
        HttpMethod method,
        CancellationToken cancellationToken = default)
    {
        cancellationToken = CancellationTokenProvider.FallbackToProvider(cancellationToken);

        using var request = new HttpRequestMessage();

        if (value is not null)
        {
            request.Content = JsonContent.Create(value);
        }

        request.Method = method;
        request.RequestUri = CreateUri(path);

        using var httpClient = CreateHttpClient();
        httpClient.DefaultRequestHeaders.Authorization = await GetAuthenticationHeaderAsync();

        using var response = await httpClient.SendAsync(request, cancellationToken);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        return Serializer.Deserialize<TResult>(json);
    }

    protected virtual async Task<string> GetAccessTokenAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken = CancellationTokenProvider.FallbackToProvider(cancellationToken);

        using var request = new HttpRequestMessage();

        request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "grant_type", "password" },
            { "username", Options.AdminUserName },
            { "password", Options.AdminPassword },
            { "client_id", Options.AdminClientId }
        });
        request.Method = HttpMethod.Post;
        request.RequestUri = CreateUri($"/realms/{RealmName}/protocol/openid-connect/token");

        using var httpClient = CreateHttpClient();
        using var response = await httpClient.SendAsync(request, cancellationToken);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = Serializer.Deserialize<OAuth2Token>(json);

        return result.AccessToken;
    }

    protected virtual string SetQuery(string uri, Dictionary<string, object?> queries)
    {
        foreach (var (key, value) in queries)
        {
            if (value is null)
            {
                continue;
            }

            uri = QueryHelpers.AddQueryString(uri, key, value.ToString());
        }

        return uri;
    }

    protected virtual HttpClient CreateHttpClient()
    {
        return HttpClientFactory.CreateClient("keycloak");
    }

    protected virtual Uri CreateUri(string path)
    {
        var url = Options.Url.TrimEnd('/');
        path = path.TrimStart('/').TrimEnd('/');

        return new Uri($"{url}/{path}");
    }

    private async Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync()
    {
        return new AuthenticationHeaderValue("Bearer", await GetAccessTokenAsync());
    }

    private Task<TResult> GetAsync<TResult>(
        string path,
        CancellationToken cancellationToken = default)
    {
        return SendAsync<TResult, object>(path, null, HttpMethod.Get, cancellationToken);
    }

    private Task PostAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        return PostAsync<object>(path, null, cancellationToken);
    }

    private Task<TResult> PostAsync<TResult>(
        string path,
        CancellationToken cancellationToken = default)
    {
        return PostAsync<TResult, object>(path, null, cancellationToken);
    }

    private Task PostAsync<TValue>(
        string path,
        TValue? value,
        CancellationToken cancellationToken = default)
    {
        return SendAsync(path, value, HttpMethod.Post, cancellationToken);
    }

    private Task<TResult> PostAsync<TResult, TValue>(
        string path,
        TValue? value,
        CancellationToken cancellationToken = default)
    {
        return SendAsync<TResult, TValue>(path, value, HttpMethod.Post, cancellationToken);
    }

    private Task PutAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        return PutAsync<string>(path, null, cancellationToken);
    }

    private Task PutAsync<TValue>(
        string path,
        TValue? value,
        CancellationToken cancellationToken = default)
    {
        return SendAsync(path, value, HttpMethod.Put, cancellationToken);
    }

    private Task<TResult> PutAsync<TResult, TValue>(
        string path,
        TValue? value,
        CancellationToken cancellationToken = default)
    {
        return SendAsync<TResult, TValue>(path, value, HttpMethod.Put, cancellationToken);
    }

    private Task DeleteAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync<object>(path, null, cancellationToken);
    }

    private Task DeleteAsync<TValue>(
        string path,
        TValue? value,
        CancellationToken cancellationToken = default)
    {
        return SendAsync(path, value, HttpMethod.Delete, cancellationToken);
    }
}
