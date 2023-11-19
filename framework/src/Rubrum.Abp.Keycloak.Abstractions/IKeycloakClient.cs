namespace Rubrum.Abp.Keycloak;

public interface IKeycloakClient
{
    #region ClientRegistrationPolicy

    /// <summary>
    /// Base path for retrieve providers with the configProperties properly filled
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-registration-policy/providers
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetBasePathForRetrieveProvidersAsync(CancellationToken cancellationToken = default);

    #endregion

    #region Key

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/keys
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<KeysMetadataRepresentation> GetKeysAsync(CancellationToken cancellationToken = default);

    #endregion

    #region AttackDetection

    /// <summary>
    /// Get status of a username in brute force detection
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/attack-detection/brute-force/users/{userId}
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request</param>
    Task<Dictionary<string, object>> GetUserNameStatusInBruteForceDetectionAsync(
        string userId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Clear any user login failures for all users This can release temporary disabled users
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/attack-detection/brute-force/users
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request</param>
    Task ClearUserLoginFailuresAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Clear any user login failures for the user This can release temporary disabled user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/attack-detection/brute-force/users/{userId}
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request</param>
    Task ClearUserLoginFailuresAsync(string userId, CancellationToken cancellationToken = default);

    #endregion

    #region AuthenticationManagement

    /// <summary>
    /// Get authenticator configuration
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/config/{id}
    /// </remarks>
    /// <param name="configurationId">Configuration id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<AuthenticatorConfigRepresentation> GetAuthenticatorConfigurationAsync(
        string configurationId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get authenticator providers Returns a stream of authenticator providers.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/authenticator-providers
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetAuthenticatorProvidersAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get client authenticator providers Returns a stream of client authenticator providers.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/client-authenticator-providers
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientAuthenticatorProvidersAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get authenticator provider’s configuration description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/config-description/{providerId}
    /// </remarks>
    /// <param name="providerId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<AuthenticatorConfigInfoRepresentation> GetAuthenticatorProvidersConfigurationAsync(
        string providerId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Single Execution
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/executions/{executionId}
    /// </remarks>
    /// <param name="executionId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetAuthenticationExecutionAsync(
        string executionId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get execution’s configuration
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/executions/{executionId}/config/{id}
    /// </remarks>
    /// <param name="executionId">Execution id</param>
    /// <param name="configurationId">Configuration id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<AuthenticatorConfigRepresentation> GetAuthenticationExecutionConfigurationAsync(
        string executionId,
        string configurationId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get authentication executions for a flow
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/flows/{flowAlias}/executions
    /// </remarks>
    /// <param name="flowAlias">Flow alias</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetAuthenticationExecutionsForFlowAsync(
        string flowAlias,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get authentication flow for id
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/flows/{id}
    /// </remarks>
    /// <param name="flowId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<AuthenticationFlowRepresentation> GetAuthenticationFlowForIdAsync(
        string flowId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get authentication flows Returns a stream of authentication flows.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/flows
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<AuthenticationFlowRepresentation>> GetAuthenticationFlowsAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get form action providers Returns a stream of form action providers.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/form-action-providers
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, object>> GetFormActionProvidersAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get form providers Returns a stream of form providers.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/form-providers
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, object>> GetFormProvidersAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get configuration descriptions for all clients
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/per-client-config-description
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, ConfigPropertyRepresentation>> GetConfigurationForAllClientsAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get required action for alias
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/required-actions/{alias}
    /// </remarks>
    /// <param name="alias">Alias of required action</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<RequiredActionProviderRepresentation> GetRequiredActionForAliasAsync(
        string alias,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get required actions Returns a stream of required actions.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/required-actions
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RequiredActionProviderRepresentation>> GetRequiredActionsAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get unregistered required actions Returns a stream of unregistered required actions.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/unregistered-required-actions
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, object>> GetUnregisteredRequiredActionsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Create new authenticator configuration
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/config
    /// </remarks>
    /// <param name="authenticatorConfigRepresentation">AuthenticatorConfigRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateAuthenticatorConfigurationAsync(
        AuthenticatorConfigRepresentation? authenticatorConfigRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Copy existing authentication flow under a new name The new name is given as &amp;#39;newName&amp;#39; attribute of the passed JSON object
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/flows/{flowAlias}/copy
    /// </remarks>
    /// <param name="flowAlias">name of the existing authentication flow</param>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CopyExistingAuthenticationFlowAsync(
        string flowAlias,
        string? body,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add new authentication execution to a flow
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/flows/{flowAlias}/executions/execution
    /// </remarks>
    /// <param name="flowAlias">Alias of parent flow</param>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateAuthenticationExecutionToFlowAsync(
        string flowAlias,
        string? body,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update execution with new configuration
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/executions/{executionId}/config
    /// </remarks>
    /// <param name="executionId">Execution id</param>
    /// <param name="authenticatorConfigRepresentation">AuthenticatorConfigRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateExecutionWithConfigurationAsync(
        string executionId,
        AuthenticatorConfigRepresentation? authenticatorConfigRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Lower execution’s priority
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/executions/{executionId}/lower-priority
    /// </remarks>
    /// <param name="executionId">Execution id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task ExecutionLowerPriorityAsync(string executionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Raise execution’s priority
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/executions/{executionId}/raise-priority
    /// </remarks>
    /// <param name="executionId">Execution id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task ExecutionRaisePriorityAsync(string executionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add new authentication execution
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/executions
    /// </remarks>
    /// <param name="authenticationExecutionRepresentation">AuthenticationExecutionRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateAuthenticationExecutionAsync(
        AuthenticationExecutionRepresentation? authenticationExecutionRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add new flow with new execution to existing flow
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/flows/{flowAlias}/executions/flow
    /// </remarks>
    /// <param name="flowAlias">Alias of parent authentication flow</param>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateFlowWithNewExecutionAsync(
        string flowAlias,
        string? body,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new authentication flow
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/flows
    /// </remarks>
    /// <param name="authenticationFlowRepresentation">AuthenticationFlowRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateAuthenticationFlowAsync(
        AuthenticationFlowRepresentation? authenticationFlowRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Register a new required actions
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/register-required-action
    /// </remarks>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task RegisterRequiredActionAsync(string? body, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lower required action’s priority
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/required-actions/{alias}/lower-priority
    /// </remarks>
    /// <param name="alias">Alias of required action</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task RequiredActionLowerPriorityAsync(string alias, CancellationToken cancellationToken = default);

    /// <summary>
    /// Raise required action’s priority
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/required-actions/{alias}/raise-priority
    /// </remarks>
    /// <param name="alias">Alias of required action</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task RequiredActionRaisePriorityAsync(string alias, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update authenticator configuration
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/config/{id}
    /// </remarks>
    /// <param name="configurationId">Configuration id</param>
    /// <param name="authenticatorConfigRepresentation">AuthenticatorConfigRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateAuthenticationConfigurationAsync(
        string configurationId,
        AuthenticatorConfigRepresentation? authenticatorConfigRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update authentication executions of a Flow
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/flows/{flowAlias}/executions
    /// </remarks>
    /// <param name="flowAlias">Flow alias</param>
    /// <param name="authenticationExecutionInfoRepresentation">AuthenticationExecutionInfoRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateAuthenticationExecutionsOfFlowAsync(
        string flowAlias,
        AuthenticationExecutionInfoRepresentation? authenticationExecutionInfoRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update an authentication flow
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/flows/{id}
    /// </remarks>
    /// <param name="flowId"></param>
    /// <param name="authenticationFlowRepresentation">AuthenticationFlowRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateAuthenticationFlowAsync(
        string flowId,
        AuthenticationFlowRepresentation? authenticationFlowRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update required action
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/required-actions/{alias}
    /// </remarks>
    /// <param name="alias">Alias of required action</param>
    /// <param name="requiredActionProviderRepresentation">RequiredActionProviderRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateRequiredActionAsync(
        string alias,
        RequiredActionProviderRepresentation? requiredActionProviderRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete authenticator configuration
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/config/{id}
    /// </remarks>
    /// <param name="configurationId">Configuration id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteAuthenticatorConfigurationAsync(string configurationId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete execution
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/executions/{executionId}
    /// </remarks>
    /// <param name="executionId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteExecutionAsync(string executionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete an authentication flow
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/flows/{id}
    /// </remarks>
    /// <param name="flowId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteAuthenticationFlowAsync(string flowId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete required action
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/required-actions/{alias}
    /// </remarks>
    /// <param name="alias">Alias of required action</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteRequiredActionAsync(string alias, CancellationToken cancellationToken = default);

    #endregion

    #region ClientAttributeCertificate

    /// <summary>
    /// Get key info
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/certificates/{attr}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="attribute"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<CertificateRepresentation> GetCertificateAsync(
        string id,
        string attribute,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a keystore file for the client, containing private key and public certificate
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/certificates/{attr}/download
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="attribute"></param>
    /// <param name="keyStoreConfig">KeyStoreConfig (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Stream> GetKeystoreFileForClientAsync(
        string clientId,
        string attribute,
        KeyStoreConfig? keyStoreConfig,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Generate a new certificate with new key pair
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/certificates/{attr}/generate
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="attribute"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<CertificateRepresentation> GenerateCertificateAsync(
        string clientId,
        string attribute,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Generate a new keypair and certificate, and get the private key file Generates a keypair and certificate and serves the private key in a specified keystore format. Only generated public certificate is saved in Keycloak DB - the private key is not.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/certificates/{attr}/generate-and-download
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="attribute"></param>
    /// <param name="keyStoreConfig">KeyStoreConfig (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Stream> GenerateKeypairAndCertificateAsync(
        string clientId,
        string attribute,
        KeyStoreConfig? keyStoreConfig,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Upload certificate and eventually private key
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/certificates/{attr}/upload
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="attribute"></param>
    /// <param name="file"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<CertificateRepresentation> UploadCertificateAndPrivateKeyAsync(
        string clientId,
        string attribute,
        Stream file,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Upload only certificate, not private key
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/certificates/{attr}/upload-certificate
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="attribute"></param>
    /// <param name="file"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<CertificateRepresentation> UploadOnlyCertificateAsync(
        string clientId,
        string attribute,
        Stream file,
        CancellationToken cancellationToken = default);

    #endregion

    #region ClientInitialAccess

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients-initial-access
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<ClientInitialAccessPresentation>> GetClientInitialAccessAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new initial access token.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients-initial-access
    /// </remarks>
    /// <param name="clientInitialAccessCreatePresentation">ClientInitialAccessCreatePresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ClientInitialAccessPresentation> CreateInitialAccessTokenAsync(
        ClientInitialAccessCreatePresentation? clientInitialAccessCreatePresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients-initial-access/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteInitialAccessTokenAsync(string id, CancellationToken cancellationToken = default);

    #endregion

    #region ClientRoleMappings

    /// <summary>
    /// Get client-level role mappings for the user, and the app
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/clients/{client}
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetGroupRoleMappingsClientAsync(
        string groupId,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get available client-level roles that can be mapped to the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/clients/{client}/available
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetGroupRoleMappingsClientAvailableAsync(
        string groupId,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective client-level role mappings This recurses any composite roles
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/clients/{client}/composite
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetGroupRoleMappingsClientCompositeAsync(
        string groupId,
        string client,
        bool briefRepresentation = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get client-level role mappings for the user, and the app
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/clients/{client}
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetUserRoleMappingsClientAsync(
        string userId,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get available client-level roles that can be mapped to the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/clients/{client}/available
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetUserRoleMappingsClientAvailableAsync(
        string userId,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective client-level role mappings This recurses any composite roles
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/clients/{client}/composite
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetUserRoleMappingsClientCompositeAsync(
        string userId,
        string client,
        bool briefRepresentation = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add client-level roles to the user role mapping
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/clients/{client}
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task ChangeGroupRoleMappingsClientAsync(
        string groupId,
        string client,
        RoleRepresentation roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add client-level roles to the user role mapping
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/clients/{client}
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task ChangeUserRoleMappingsClientAsync(
        string userId,
        string client,
        RoleRepresentation roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete client-level roles from user role mapping
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/clients/{client}
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteGroupRoleMappingsClientAsync(
        string groupId,
        string client,
        RoleRepresentation roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete client-level roles from user role mapping
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/clients/{client}
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteUserRoleMappingsClientAsync(
        string userId,
        string client,
        RoleRepresentation roleRepresentation,
        CancellationToken cancellationToken = default);

    #endregion

    #region Clients

    /// <summary>
    /// Get representation of the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ClientRepresentation> GetClientByIdAsync(string clientId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/management/permissions
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> GetClientManagementPermissionsAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the client secret
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/client-secret
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<CredentialRepresentation> GetClientSecretAsync(string clientId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get user sessions for client Returns a list of user sessions associated with this client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/user-sessions
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="first">Paging offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<UserSession>> GetClientUserSessionsAsync(
        string clientId,
        int? first = null,
        int? max = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get clients belonging to the realm.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients
    /// </remarks>
    /// <param name="clientId">filter by clientId (optional)</param>
    /// <param name="first">the first result (optional)</param>
    /// <param name="max">the max results to return (optional)</param>
    /// <param name="q"> (optional)</param>
    /// <param name="search">whether this is a search query or a getClientById query (optional)</param>
    /// <param name="viewableOnly">filter clients that cannot be viewed in full by admin (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<ClientRepresentation>> GetClientsAsync(
        string? clientId = null,
        int? first = null,
        int? max = null,
        string? q = null,
        string? search = null,
        bool? viewableOnly = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get default client scopes. Only name and ids are returned.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/default-client-scopes
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<ClientScopeRepresentation>> GetDefaultClientScopesAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create JSON with payload of example access token
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/evaluate-scopes/generate-example-access-token
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<AccessToken> GetGenerateExampleAccessTokenAsync(
        string clientId,
        string? scope = null,
        string? userId = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create JSON with payload of example id token
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/evaluate-scopes/generate-example-id-token
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<IdToken> GetGenerateExampleIdTokenAsync(
        string clientId,
        string? scope = null,
        string? userId = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create JSON with payload of example user info
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/evaluate-scopes/generate-example-userinfo
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, object>> GetGenerateExampleUserinfoAsync(
        string clientId,
        string? scope = null,
        string? userId = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective scope mapping of all roles of particular role container, which this client is defacto allowed to have in the accessToken issued for him.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/evaluate-scopes/scope-mappings/{roleContainerId}/granted
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleContainerId">either realm name OR client UUID</param>
    /// <param name="scope"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetGrantedAsync(
        string clientId,
        string roleContainerId,
        string? scope = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get roles, which this client doesn’t have scope for and can’t have them in the accessToken issued for him.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/evaluate-scopes/scope-mappings/{roleContainerId}/not-granted
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleContainerId">either realm name OR client UUID</param>
    /// <param name="scope"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetNotGrantedAsync(
        string clientId,
        string roleContainerId,
        string? scope = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get application offline session count Returns a number of offline user sessions associated with this client { \\\&amp;quot;count\\\&amp;quot;: number }
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/offline-session-count
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, long>> GetOfflineSessionCountAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get offline sessions for client Returns a list of offline user sessions associated with this client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/offline-sessions
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="first">Paging offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<UserSession>> GetOfflineSessionsAsync(
        string clientId,
        int? first = null,
        int? max = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get optional client scopes. Only name and ids are returned.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/optional-client-scopes
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<ClientScopeRepresentation>> GetOptionalClientScopesAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return list of all protocol mappers, which will be used when generating tokens issued for particular client.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/evaluate-scopes/protocol-mappers
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="scope"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<ClientScopeEvaluateResourceProtocolMapperEvaluation>> GetProtocolMappersInTokenGenerationAsync(
        string clientId,
        string? scope = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the rotated client secret
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/client-secret/rotated
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<CredentialRepresentation> GetRotatedClientSecretAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a user dedicated to the service account
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/service-account-user
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<UserRepresentation> GetServiceAccountUserAsync(string clientId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get application session count Returns a number of user sessions associated with this client { \\\&amp;quot;count\\\&amp;quot;: number }
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/session-count
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, long>> GetSessionCountAsync(string clientId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Test if registered cluster nodes are available Tests availability by sending &amp;#39;ping&amp;#39; request to all cluster nodes.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/test-nodes-available
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<GlobalRequestResult> GetTestNodesAvailableAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Push the client’s revocation policy to its admin URL If the client has an admin URL, push revocation policy to it.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/push-revocation
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<GlobalRequestResult> ClientPushRevocationAsync(string clientId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Generate a new secret for the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/client-secret
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<CredentialRepresentation> GenerateClientSecretAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new client Client’s client_id must be unique!
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients
    /// </remarks>
    /// <param name="clientRepresentation">ClientRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientAsync(ClientRepresentation? clientRepresentation, CancellationToken cancellationToken = default);

    /// <summary>
    /// Register a cluster node with the client Manually register cluster node to this client - usually it’s not needed to call this directly as adapter should handle by sending registration request to Keycloak
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/nodes
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task RegisterClusterNodeWithClientAsync(
        string clientId,
        string? body = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Generate a new registration access token for the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/registration-access-token
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ClientRepresentation> GenerateRegistrationAccessTokenAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="clientRepresentation">ClientRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateClientAsync(
        string clientId,
        ClientRepresentation? clientRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/management/permissions
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="managementPermissionReference">ManagementPermissionReference (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> UpdateClientManagementPermissionsAsync(
        string clientId,
        ManagementPermissionReference? managementPermissionReference,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/default-client-scopes/{clientScopeId}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="clientScopeId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateDefaultClientScopeAsync(
        string clientId,
        string clientScopeId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/optional-client-scopes/{clientScopeId}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="clientScopeId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateOptionalClientScopeAsync(
        string clientId,
        string clientScopeId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientByIdAsync(string clientId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/default-client-scopes/{clientScopeId}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="clientScopeId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteDefaultClientScopeAsync(
        string clientId,
        string clientScopeId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Unregister a cluster node from the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/nodes/{node}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="node"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UnregisterClusterNodeFromClient(
        string clientId,
        string node,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/optional-client-scopes/{clientScopeId}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="clientScopeId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteOptionalClientScopeAsync(
        string clientId,
        string clientScopeId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Invalidate the rotated secret for the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/client-secret/rotated
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteRotatedAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    #endregion

    #region ClientScopes

    /// <summary>
    /// Get representation of the client scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ClientScopeRepresentation> GetClientScopeAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get client scopes belonging to the realm Returns a list of client scopes belonging to the realm
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<ClientScopeRepresentation>> GetClientScopesAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get representation of the client scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ClientScopeRepresentation> GetClientTemplateAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get client scopes belonging to the realm Returns a list of client scopes belonging to the realm
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<ClientScopeRepresentation>> GetClientTemplatesAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new client scope Client Scope’s name must be unique!
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes
    /// </remarks>
    /// <param name="clientScopeRepresentation">ClientScopeRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientScopeAsync(
        ClientScopeRepresentation? clientScopeRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new client scope Client Scope’s name must be unique!
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates
    /// </remarks>
    /// <param name="clientScopeRepresentation">ClientScopeRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientTemplateAsync(
        ClientScopeRepresentation? clientScopeRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the client scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="clientScopeRepresentation">ClientScopeRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateClientScopeAsync(
        string clientId,
        ClientScopeRepresentation? clientScopeRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the client scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="clientScopeRepresentation">ClientScopeRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateClientTemplateAsync(
        string clientId,
        ClientScopeRepresentation? clientScopeRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the client scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientScopeAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the client scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientTemplateAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    #endregion

    #region Component

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/components/{id}
    /// </remarks>
    /// <param name="componentId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ComponentRepresentation> GetComponentAsync(string componentId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/components
    /// </remarks>
    /// <param name="name"> (optional)</param>
    /// <param name="parent"> (optional)</param>
    /// <param name="type"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<ComponentRepresentation>> GetComponentsAsync(
        string? name = null,
        string? parent = null,
        string? type = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// List of subcomponent types that are available to configure for a particular parent component.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/components/{id}/sub-component-types
    /// </remarks>
    /// <param name="componentId"></param>
    /// <param name="type"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<ComponentRepresentation>> GetSubComponentTypesAsync(
        string componentId,
        string? type = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/components
    /// </remarks>
    /// <param name="componentRepresentation">ComponentRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateComponentAsync(
        ComponentRepresentation? componentRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/components/{id}
    /// </remarks>
    /// <param name="componentId"></param>
    /// <param name="componentRepresentation">ComponentRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateComponentAsync(
        string componentId,
        ComponentRepresentation? componentRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/components/{id}
    /// </remarks>
    /// <param name="componentId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteComponentAsync(string componentId, CancellationToken cancellationToken = default);

    #endregion

    #region Groups

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<GroupRepresentation> GetGroupAsync(string groupId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/management/permissions
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> GetGroupManagementPermissionsAsync(
        string groupId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get group hierarchy. Only name and ids are returned.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups
    /// </remarks>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="exact"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="populateHierarchy"> (optional)</param>
    /// <param name="q"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<GroupRepresentation>> GetGroupsAsync(
        bool? briefRepresentation = true,
        bool? exact = false,
        int? first = null,
        int? max = null,
        bool? populateHierarchy = true,
        string? q = null,
        string? search = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the groups counts.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/count
    /// </remarks>
    /// <param name="search"> (optional)</param>
    /// <param name="top"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, long>> GetGroupsCountAsync(
        string? search = null,
        bool? top = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get users Returns a stream of users, filtered according to query parameters
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/members
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="briefRepresentation">Only return basic information (only guaranteed to return id, username, created, first and last name, email, enabled state, email verification state, federation link, and access. Note that it means that namely user attributes, required actions, and not before are not returned.) (optional)</param>
    /// <param name="first">Pagination offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<UserRepresentation>> GetGroupUsersAsync(
        string groupId,
        bool? briefRepresentation = null,
        int? first = null,
        int? max = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Set or create child.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/children
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="groupRepresentation">GroupRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateChildrenAsync(
        string groupId,
        GroupRepresentation? groupRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create or add a top level realm groupSet or create child.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups
    /// </remarks>
    /// <param name="groupRepresentation">GroupRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateGroupAsync(
        GroupRepresentation? groupRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update group, ignores subgroups.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="groupRepresentation">GroupRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateGroupByIdAsync(
        string groupId,
        GroupRepresentation? groupRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/management/permissions
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="managementPermissionReference">ManagementPermissionReference (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> UpdateGroupManagementPermissionsAsync(
        string groupId,
        ManagementPermissionReference? managementPermissionReference,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteGroupByIdAsync(string groupId, CancellationToken cancellationToken = default);

    #endregion

    #region IdentityProviders

    /// <summary>
    /// Export public broker configuration for identity provider
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/instances/{alias}/export
    /// </remarks>
    /// <param name="alias"></param>
    /// <param name="format">Format to use</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Stream> ExportAsync(string alias, string? format, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get identity providers
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/providers/{provider_id}
    /// </remarks>
    /// <param name="providerId">Provider id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<IdentityProviderRepresentation>> GetIdentityProvidersAsync(
        string providerId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the identity provider
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/instances/{alias}
    /// </remarks>
    /// <param name="alias"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<IdentityProviderRepresentation> GetIdentityProviderAsync(
        string alias,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/instances/{alias}/management/permissions
    /// </remarks>
    /// <param name="alias"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> GetManagementPermissionsAsync(
        string alias,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get identity providers
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/instances
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<IdentityProviderRepresentation>> GetIdentityProvidersAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mapper by id for the identity provider
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/instances/{alias}/mappers/{id}
    /// </remarks>
    /// <param name="alias"></param>
    /// <param name="mapperId">Mapper id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<IdentityProviderMapperRepresentation> GetIdentityProviderMappersAsync(
        string alias,
        string mapperId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mapper types for identity provider
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/instances/{alias}/mapper-types
    /// </remarks>
    /// <param name="alias"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, IdentityProviderMapperTypeRepresentation>> GetIdentityProviderMapperTypesAsync(
        string alias,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mappers for identity provider
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/instances/{alias}/mappers
    /// </remarks>
    /// <param name="alias"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<IdentityProviderMapperRepresentation>> GetIdentityProviderMappersAsync(
        string alias,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Import identity provider from JSON body
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/import-config
    /// </remarks>
    /// <param name="body">[object] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, string>> ImportIdentityProviderAsync(
        object? body,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new identity provider
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/instances
    /// </remarks>
    /// <param name="identityProviderRepresentation">IdentityProviderRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateIdentityProviderAsync(
        IdentityProviderRepresentation? identityProviderRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add a mapper to identity provider
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/instances/{alias}/mappers
    /// </remarks>
    /// <param name="alias"></param>
    /// <param name="identityProviderMapperRepresentation">IdentityProviderMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateMapperForIdentityProviderAsync(
        string alias,
        IdentityProviderMapperRepresentation? identityProviderMapperRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the identity provider
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/instances/{alias}
    /// </remarks>
    /// <param name="alias"></param>
    /// <param name="identityProviderRepresentation">IdentityProviderRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateIdentityProviderAsync(
        string alias,
        IdentityProviderRepresentation? identityProviderRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/instances/{alias}/management/permissions
    /// </remarks>
    /// <param name="alias"></param>
    /// <param name="managementPermissionReference">ManagementPermissionReference (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> UpdateManagementPermissionsAsync(
        string alias,
        ManagementPermissionReference? managementPermissionReference,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a mapper for the identity provider
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/instances/{alias}/mappers/{id}
    /// </remarks>
    /// <param name="alias"></param>
    /// <param name="mapperId">Mapper id</param>
    /// <param name="identityProviderMapperRepresentation">IdentityProviderMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateMapperForIdentityProviderAsync(
        string alias,
        string mapperId,
        IdentityProviderMapperRepresentation? identityProviderMapperRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the identity provider
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/instances/{alias}
    /// </remarks>
    /// <param name="alias"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteIdentityProviderAsync(
        string alias,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete a mapper for the identity provider
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/instances/{alias}/mappers/{id}
    /// </remarks>
    /// <param name="alias"></param>
    /// <param name="mapperId">Mapper id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteMapperForIdentityProviderAsync(
        string alias,
        string mapperId,
        CancellationToken cancellationToken = default);

    #endregion

    #region ProtocolMappers

    /// <summary>
    /// Get mapper by id
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocolMapperId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ProtocolMapperRepresentation> GetProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mappers
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/protocol-mappers/models
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<ProtocolMapperRepresentation>> GetProtocolMappersAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mappers by name for a specific protocol
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/protocol-mappers/protocol/{protocol}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocol"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<ProtocolMapperRepresentation>> GetProtocolMappersAsync(
        string clientId,
        string protocol,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mapper by id
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocolMapperId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ProtocolMapperRepresentation> GetClientScopeProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mappers
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/protocol-mappers/models
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<ProtocolMapperRepresentation>> GetClientScopeProtocolMappersAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mappers by name for a specific protocol
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/protocol-mappers/protocol/{protocol}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocol"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<ProtocolMapperRepresentation>> GetClientScopeProtocolMappersAsync(
        string clientId,
        string protocol,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mapper by id
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocolMapperId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ProtocolMapperRepresentation> GetClientTemplateProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mappers
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/protocol-mappers/models
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<ProtocolMapperRepresentation>> GetClientTemplateProtocolMappersAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mappers by name for a specific protocol
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/protocol-mappers/protocol/{protocol}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocol"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<ProtocolMapperRepresentation>> GetClientTemplateProtocolMappersAsync(
        string clientId,
        string protocol,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/protocol-mappers/models
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocolMapperRepresentation">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientProtocolMapperAsync(
        string clientId,
        ProtocolMapperRepresentation? protocolMapperRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create multiple mappers
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/protocol-mappers/add-models
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocolMapperRepresentations">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientMultipleProtocolMappersAsync(
        string clientId,
        ICollection<ProtocolMapperRepresentation>? protocolMapperRepresentations,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create multiple mappers
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/protocol-mappers/add-models
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocolMapperRepresentations">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientScopeMultipleProtocolMappersAsync(
        string clientId,
        ICollection<ProtocolMapperRepresentation>? protocolMapperRepresentations,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/protocol-mappers/models
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocolMapperRepresentation">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientScopeProtocolMapperAsync(
        string clientId,
        ProtocolMapperRepresentation? protocolMapperRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/protocol-mappers/models
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocolMapperRepresentation">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientTemplateProtocolMapperAsync(
        string clientId,
        ProtocolMapperRepresentation? protocolMapperRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create multiple mappers
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/protocol-mappers/add-models
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocolMapperRepresentations">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientTemplateMultipleProtocolMappersAsync(
        string clientId,
        ICollection<ProtocolMapperRepresentation>? protocolMapperRepresentations,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocolMapperId"></param>
    /// <param name="protocolMapperRepresentation">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateClientProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        ProtocolMapperRepresentation? protocolMapperRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocolMapperId"></param>
    /// <param name="protocolMapperRepresentation">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateClientScopeProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        ProtocolMapperRepresentation? protocolMapperRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocolMapperId"></param>
    /// <param name="protocolMapperRepresentation">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateClientTemplateProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        ProtocolMapperRepresentation? protocolMapperRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocolMapperId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocolMapperId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientScopeProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="protocolMapperId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientTemplateProtocolMapperAsync(
        string clientId,
        string protocolMapperId,
        CancellationToken cancellationToken = default);

    #endregion

    #region RealmsAdmin

    /// <summary>
    /// Get accessible realms Returns a list of accessible realms. The list is filtered based on what realms the caller is allowed to view.
    /// </summary>
    /// <remarks>
    /// Url: /
    /// </remarks>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RealmRepresentation>> GetAccessibleRealmsAsync(
        bool? briefRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get admin events Returns all admin events, or filters events based on URL query parameters listed here
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/admin-events
    /// </remarks>
    /// <param name="authClient"> (optional)</param>
    /// <param name="authIpAddress"> (optional)</param>
    /// <param name="authRealm"> (optional)</param>
    /// <param name="authUser">user id (optional)</param>
    /// <param name="dateFrom"> (optional)</param>
    /// <param name="dateTo"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="operationTypes">[String] (optional)</param>
    /// <param name="resourcePath"> (optional)</param>
    /// <param name="resourceTypes">[String] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<AdminEvent>> GetAdminEventsAsync(
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
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the top-level representation of the realm It will not include nested information like User and Client representations.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<RealmRepresentation> GetRealmAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the top-level representation of the realm It will not include nested information like User and Client representations.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}
    /// </remarks>
    /// <param name="realmName">realm name (not id!)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<RealmRepresentation> GetRealmAsync(
        string realmName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get client session stats Returns a JSON map.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-session-stats
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, object>> GetClientSessionStatsAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/credential-registrators
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetCredentialRegistratorsAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm default client scopes. Only name and ids are returned.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/default-default-client-scopes
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<ClientScopeRepresentation>> GetDefaultDefaultClientScopesAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get group hierarchy. Only name and ids are returned.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/default-groups
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<GroupRepresentation>> GetDefaultGroupsAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm optional client scopes. Only name and ids are returned.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/default-optional-client-scopes
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<ClientScopeRepresentation>> GetDefaultOptionalClientScopesAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get events Returns all events, or filters them based on URL query parameters listed here
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/events
    /// </remarks>
    /// <param name="client">App or oauth client name (optional)</param>
    /// <param name="dateFrom">From date (optional)</param>
    /// <param name="dateTo">To date (optional)</param>
    /// <param name="first">Paging offset (optional)</param>
    /// <param name="ipAddress">IP Address (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="type">The types of events to return [String] (optional)</param>
    /// <param name="user">User id (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<KeycloakEvent>> GetEventsAsync(
        string? client = null,
        DateTime? dateFrom = null,
        DateTime? dateTo = null,
        int? first = null,
        string? ipAddress = null,
        int? max = 100,
        string? type = null,
        string? user = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the events provider configuration Returns JSON object with events provider configuration
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/events/config
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<RealmEventsConfigRepresentation> GetEventsConfigurationAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/group-by-path/{path}
    /// </remarks>
    /// <param name="path"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<GroupRepresentation> GetGroupByPathAsync(
        string path,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/localization
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, string>> GetLocalizationAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/localization/{locale}
    /// </remarks>
    /// <param name="locale"></param>
    /// <param name="useRealmDefaultLocaleFallback"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, string>> GetLocalizationByLocaleAsync(
        string locale,
        string? useRealmDefaultLocaleFallback = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/localization/{locale}/{key}
    /// </remarks>
    /// <param name="locale"></param>
    /// <param name="key"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<string> GetLocalizationByLocaleByKeyAsync(
        string locale,
        string key,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-policies/policies
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ClientPoliciesRepresentation> GetPoliciesAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-policies/profiles
    /// </remarks>
    /// <param name="includeGlobalProfiles"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ClientProfilesRepresentation> GetProfilesAsync(
        bool? includeGlobalProfiles = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users-management-permissions
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> GetUsersManagementPermissionsAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Import a realm. Imports a realm from a full representation of that realm.
    /// </summary>
    /// <remarks>
    /// Url: /
    /// </remarks>
    /// <param name="body">[file] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task ImportRealmAsync(
        Stream? body,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Base path for importing clients under this realm.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-description-converter
    /// </remarks>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ClientRepresentation> CreateClientDescriptionConverterAsync(
        string? body,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Import localization from uploaded JSON file
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/localization/{locale}
    /// </remarks>
    /// <param name="locale"></param>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task ImportLocalizationAsync(
        string locale,
        string? body,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes all user sessions.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/logout-all
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<GlobalRequestResult> LogoutAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Partial export of existing realm into a JSON file.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/partial-export
    /// </remarks>
    /// <param name="exportClients"> (optional)</param>
    /// <param name="exportGroupsAndRoles"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task ExportPartialRealmAsync(
        string? exportClients,
        string? exportGroupsAndRoles,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Partial import from a JSON file to an existing realm.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/partialImport
    /// </remarks>
    /// <param name="body">[file] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task ImportPartialRealmAsync(Stream? body, CancellationToken cancellationToken = default);

    /// <summary>
    /// Push the realm’s revocation policy to any client that has an admin url associated with it.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/push-revocation
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<GlobalRequestResult> PushRevocationAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Test SMTP connection with current logged in user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/testSMTPConnection
    /// </remarks>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task TestSmtpConnectionAsync(string? body, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the top-level information of the realm Any user, roles or client information in the representation will be ignored.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}
    /// </remarks>
    /// <param name="realmRepresentation">RealmRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateRealmAsync(RealmRepresentation? realmRepresentation, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the top-level information of the realm Any user, roles or client information in the representation will be ignored.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}
    /// </remarks>
    /// <param name="realmName">realm name (not id!)</param>
    /// <param name="realmRepresentation">RealmRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateRealmAsync(
        string realmName,
        RealmRepresentation? realmRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/default-default-client-scopes/{clientScopeId}
    /// </remarks>
    /// <param name="clientScopeId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateDefaultClientScopeAsync(string clientScopeId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/default-groups/{groupId}
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateDefaultGroupAsync(string groupId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/default-optional-client-scopes/{clientScopeId}
    /// </remarks>
    /// <param name="clientScopeId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateDefaultOptionalClientScopeAsync(string clientScopeId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/events/config
    /// </remarks>
    /// <param name="realmEventsConfigRepresentation">RealmEventsConfigRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateEventsConfigurationAsync(
        RealmEventsConfigRepresentation? realmEventsConfigRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/localization/{locale}/{key}
    /// </remarks>
    /// <param name="locale"></param>
    /// <param name="key"></param>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateLocalizationAsync(
        string locale,
        string key,
        string? body,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-policies/policies
    /// </remarks>
    /// <param name="clientPoliciesRepresentation">ClientPoliciesRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdatePoliciesAsync(
        ClientPoliciesRepresentation? clientPoliciesRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-policies/profiles
    /// </remarks>
    /// <param name="clientProfilesRepresentation">ClientProfilesRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateProfilesAsync(
        ClientProfilesRepresentation? clientProfilesRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-policies/profiles
    /// </remarks>
    /// <param name="managementPermissionReference">ManagementPermissionReference (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> UpdateUsersManagementPermissionsAsync(
        ManagementPermissionReference? managementPermissionReference,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete all admin events
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/admin-events
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteAdminEventsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the realm
    /// </summary>
    /// <remarks>
    /// Url: /{realm}
    /// </remarks>
    /// <param name="realmName">realm name (not id!)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteRealmAsync(
        string realmName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/default-client-scopes/{clientScopeId}
    /// </remarks>
    /// <param name="clientScopeId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteDefaultClientScopeAsync(
        string clientScopeId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/default-groups/{groupId}
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteDefaultGroupAsync(
        string groupId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/default-optional-client-scopes/{clientScopeId}
    /// </remarks>
    /// <param name="clientScopeId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteDefaultOptionalClientScopeAsync(
        string clientScopeId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete all events
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/events
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteEventsAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/localization/{locale}
    /// </remarks>
    /// <param name="locale"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteLocalizationByLocaleAsync(
        string locale,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/localization/{locale}/{key}
    /// </remarks>
    /// <param name="locale"></param>
    /// <param name="key"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteLocalizationByLocaleByKeyAsync(
        string locale,
        string key,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove a specific user session.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/sessions/{session}
    /// </remarks>
    /// <param name="session"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteSessionAsync(
        string session,
        CancellationToken cancellationToken = default);

    #endregion

    #region RoleMapper

    /// <summary>
    /// Get role mappings
    /// </summary>
    /// <remarks>
    /// Url: /admin/realms/{realm}/groups/{id}/role-mappings
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<MappingsRepresentation> GetGroupRoleMappingsAsync(
        string groupId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level role mappings 
    /// </summary>
    /// <remarks>
    /// Url: /admin/realms/{realm}/groups/{id}/role-mappings/realm
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetGroupRoleMappingsRealmAsync(
        string groupId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles that can be mapped
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/realm/available
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetGroupRoleMappingsRealmAvailableAsync(
        string groupId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective realm-level role mappings This will recurse all composite roles to get the result.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/realm/composite
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetGroupRoleMappingsRealmCompositeAsync(
        string groupId,
        bool? briefRepresentation = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get role mappings
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<MappingsRepresentation> GetUserRoleMappingsAsync(
        string userId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level role mappings
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/realm
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetUserRoleMappingsRealmAsync(
        string userId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles that can be mapped
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/realm/available
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetUserRoleMappingsRealmAvailableAsync(
        string userId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective realm-level role mappings This will recurse all composite roles to get the result.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/realm/composite
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetUserRoleMappingsRealmCompositeAsync(
        string userId,
        bool? briefRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add realm-level role mappings to the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/realm
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="roleRepresentations">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task ChangeGroupRoleMappingsRealmAsync(
        string groupId,
        ICollection<RoleRepresentation>? roleRepresentations,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add realm-level role mappings to the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/realm
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="roleRepresentations">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task ChangeUserRoleMappingsRealmAsync(
        string userId,
        ICollection<RoleRepresentation>? roleRepresentations,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete realm-level role mappings
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/realm
    /// </remarks>
    /// <param name="groupId"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteGroupRoleMappingsRealmAsync(
        string groupId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete realm-level role mappings
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/realm
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteUserRoleMappingsRealmAsync(
        string userId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    #endregion

    #region Roles

    /// <summary>
    /// Get a role by name
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<RoleRepresentation> GetClientRoleAsync(
        string clientId,
        string roleName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get composites of the role
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/composites
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientRoleCompositesAsync(
        string clientId,
        string roleName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/composites/clients/{clientUuid}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="forClientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientRoleCompositesClientAsync(
        string clientId,
        string roleName,
        string forClientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles of the role’s composite
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/composites/realm
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientRoleCompositesRealmAsync(
        string clientId,
        string roleName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a stream of groups that have the specified role name
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/groups
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleName">the role name.</param>
    /// <param name="briefRepresentation">if false, return a full representation of the {@code GroupRepresentation} objects. (optional)</param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<GroupRepresentation>> GetClientRoleGroupsAsync(
        string clientId,
        string roleName,
        bool? briefRepresentation = true,
        int? first = null,
        int? max = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/management/permissions
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleName"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> GetClientRoleManagementPermissionsAsync(
        string clientId,
        string roleName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a stream of users that have the specified role name.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/users
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleName">the role name.</param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<UserRepresentation>> GetClientRoleUsersAsync(
        string clientId,
        string roleName,
        int? first = null,
        int? max = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all roles for the realm or client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientRolesAsync(
        string clientId,
        bool? briefRepresentation = null,
        int? first = null,
        int? max = null,
        string? search = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a role by name
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles/{role-name}
    /// </remarks>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<RoleRepresentation> GetRoleByNameAsync(
        string roleName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get composites of the role
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles/{role-name}/composites
    /// </remarks>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetRoleCompositesByNameAsync(
        string roleName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles/{role-name}/composites/clients/{clientUuid}
    /// </remarks>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="clientUuid"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetRoleCompositesClientByNameByClientIdAsync(
        string roleName,
        string clientUuid,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles of the role’s composite
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles/{role-name}/composites/realm
    /// </remarks>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetRoleCompositesRealmByNameAsync(
        string roleName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a stream of groups that have the specified role name
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles/{role-name}/groups
    /// </remarks>
    /// <param name="roleName">the role name.</param>
    /// <param name="briefRepresentation">if false, return a full representation of the {@code GroupRepresentation} objects. (optional)</param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<GroupRepresentation>> GetRoleGroupsByNameAsync(
        string roleName,
        bool? briefRepresentation = null,
        int? first = null,
        int? max = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles/{role-name}/management/permissions
    /// </remarks>
    /// <param name="roleName"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> GetRoleManagementPermissionsByNameAsync(
        string roleName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a stream of users that have the specified role name.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles/{role-name}/users
    /// </remarks>
    /// <param name="roleName">the role name.</param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<UserRepresentation>> GetRoleUsersByNameAsync(
        string roleName,
        int? first = null,
        int? max = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all roles for the realm or client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles
    /// </remarks>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetRolesAsync(
        bool? briefRepresentation = null,
        int? first = null,
        int? max = null,
        string? search = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add a composite to the role
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/composites
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientRoleCompositesAsync(
        string clientId,
        string roleName,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new role for the realm or client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientRolesAsync(
        string clientId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add a composite to the role
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles/{role-name}/composites
    /// </remarks>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateRoleCompositesByNameAsync(
        string roleName,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new role for the realm or client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles
    /// </remarks>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateRoleAsync(
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a role by name
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateClientRoleAsync(
        string clientId,
        string roleName,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/management/permissions
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleName"></param>
    /// <param name="managementPermissionReference">ManagementPermissionReference (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> UpdateClientRoleManagementPermissionsAsync(
        string clientId,
        string roleName,
        ManagementPermissionReference? managementPermissionReference,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a role by name
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles/{role-name}
    /// </remarks>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateRoleByNameAsync(
        string roleName,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles/{role-name}/management/permissions
    /// </remarks>
    /// <param name="roleName"></param>
    /// <param name="managementPermissionReference">ManagementPermissionReference (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> UpdateRoleManagementPermissionsByNameAsync(
        string roleName,
        ManagementPermissionReference? managementPermissionReference,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete a role by name
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientRoleAsync(
        string clientId,
        string roleName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove roles from the role’s composite
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/composites
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientRoleCompositesAsync(
        string clientId,
        string roleName,
        RoleRepresentation roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete a role by name
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles/{role-name}
    /// </remarks>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteRoleByNameAsync(
        string roleName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove roles from the role’s composite
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles/{role-name}/composites
    /// </remarks>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteRoleCompositesByNameAsync(
        string roleName,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    #endregion

    #region RolesById

    /// <summary>
    /// Get a specific role’s representation
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles-by-id/{role-id}
    /// </remarks>
    /// <param name="roleId">id of role</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<RoleRepresentation> GetRoleByIdAsync(string roleId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get role’s children Returns a set of role’s children provided the role is a composite.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles-by-id/{role-id}/composites
    /// </remarks>
    /// <param name="roleId"></param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetRoleByIdCompositesAsync(
        string roleId,
        int? first = null,
        int? max = null,
        string? search = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles-by-id/{role-id}/composites/clients/{clientUuid}
    /// </remarks>
    /// <param name="roleId"></param>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetRoleByIdCompositesClientAsync(
        string roleId,
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles-by-id/{role-id}/composites/realm
    /// </remarks>
    /// <param name="roleId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetRoleByIdCompositesRealmAsync(
        string roleId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles-by-id/{role-id}/management/permissions
    /// </remarks>
    /// <param name="roleId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> GetRoleByIdManagementPermissionsAsync(
        string roleId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Make the role a composite role by associating some child roles
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles-by-id/{role-id}/composites
    /// </remarks>
    /// <param name="roleId"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateRoleByIdCompositesAsync(
        string roleId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the role
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles-by-id/{role-id}
    /// </remarks>
    /// <param name="roleId">id of role</param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateRoleByIdAsync(
        string roleId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles-by-id/{role-id}/management/permissions
    /// </remarks>
    /// <param name="roleId"></param>
    /// <param name="managementPermissionReference">ManagementPermissionReference (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> UpdateRoleByIdManagementPermissionsAsync(
        string roleId,
        ManagementPermissionReference? managementPermissionReference,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the role
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles-by-id/{role-id}
    /// </remarks>
    /// <param name="roleId">id of role</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteRoleByIdAsync(
        string roleId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove a set of roles from the role’s composite
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles-by-id/{role-id}/composites
    /// </remarks>
    /// <param name="roleId"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteRoleByIdCompositesAsync(
        string roleId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    #endregion

    #region ScopeMappings

    /// <summary>
    /// Get all scope mappings for the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<MappingsRepresentation> GetClientScopeMappingsAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the roles associated with a client’s scope Returns roles for the client.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientScopeMappingsClientAsync(
        string clientId,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// The available client-level roles Returns the roles for the client that can be associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/clients/{client}/available
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientScopeMappingsClientAvailableAsync(
        string clientId,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective client roles Returns the roles for the client that are associated with the client’s scope.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/clients/{client}/composite
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientScopeMappingsClientCompositeAsync(
        string clientId,
        string client,
        bool? briefRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientScopeMappingsRealmAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles that are available to attach to this client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/realm/available
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientScopeMappingsRealmAvailableAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective realm-level roles associated with the client’s scope What this does is recurse any composite roles associated with the client’s scope and adds the roles to this lists.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/realm/composite
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientScopeMappingsRealmCompositeAsync(
        string clientId,
        bool? briefRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all scope mappings for the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<MappingsRepresentation> GetClientScopeScopeMappingsAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the roles associated with a client’s scope Returns roles for the client.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientScopeScopeMappingsClientAsync(
        string clientId,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// The available client-level roles Returns the roles for the client that can be associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/clients/{client}/available
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientScopeScopeMappingsClientAvailableAsync(
        string clientId,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective client roles Returns the roles for the client that are associated with the client’s scope.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/clients/{client}/composite
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientScopeScopeMappingsClientCompositeAsync(
        string clientId,
        string client,
        bool? briefRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientScopeScopeMappingsRealmAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles that are available to attach to this client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/realm/available
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientScopeScopeMappingsRealmAvailableAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective realm-level roles associated with the client’s scope What this does is recurse any composite roles associated with the client’s scope and adds the roles to this lists.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/realm/composite
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientScopeScopeMappingsRealmCompositeAsync(
        string clientId,
        bool? briefRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all scope mappings for the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<MappingsRepresentation> GetClientTemplateScopeMappingsAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the roles associated with a client’s scope Returns roles for the client.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientTemplateScopeMappingsClientAsync(
        string clientId,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// The available client-level roles Returns the roles for the client that can be associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/clients/{client}/available
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientTemplateScopeMappingsClientAvailableAsync(
        string clientId,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective client roles Returns the roles for the client that are associated with the client’s scope.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/clients/{client}/composite
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientTemplateScopeMappingsClientCompositeAsync(
        string clientId,
        string client,
        bool? briefRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientTemplateScopeMappingsRealmAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles that are available to attach to this client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/realm/available
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientTemplateScopeMappingsRealmAvailableAsync(
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective realm-level roles associated with the client’s scope What this does is recurse any composite roles associated with the client’s scope and adds the roles to this lists.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/realm/composite
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<RoleRepresentation>> GetClientTemplateScopeMappingsRealmCompositeAsync(
        string clientId,
        bool? briefRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add client-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientScopeMappingsClientAsync(
        string clientId,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add a set of realm-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientScopeMappingsRealmAsync(
        string clientId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add client-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientScopeScopeMappingsClientAsync(
        string clientId,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add a set of realm-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientScopeScopeMappingsRealmAsync(
        string clientId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add client-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientTemplateScopeMappingsClientAsync(
        string clientId,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add a set of realm-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientTemplateScopeMappingsRealmAsync(
        string clientId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove client-level roles from the client’s scope.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientScopeMappingsClientAsync(
        string clientId,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove a set of realm-level roles from the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientScopeMappingsRealmAsync(
        string clientId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove client-level roles from the client’s scope.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientScopeScopeMappingsClientAsync(
        string clientId,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove a set of realm-level roles from the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientScopeScopeMappingsRealmAsync(
        string clientId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove client-level roles from the client’s scope.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientTemplateScopeMappingsClientAsync(
        string clientId,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove a set of realm-level roles from the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="clientId"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientTemplateScopeMappingsRealmAsync(
        string clientId,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    #endregion

    #region Users

    /// <summary>
    /// Return credential types, which are provided by the user storage where user is stored.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/configured-user-storage-credential-types
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetConfiguredUserStorageCredentialTypesAsync(
        string userId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get consents granted by the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/consents
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetConsentsAsync(
        string userId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/credentials
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetCredentialsAsync(
        string userId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get social logins associated with the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/federated-identity
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<FederatedIdentityRepresentation>> GetFederatedIdentityAsync(
        string userId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get offline sessions associated with the user and client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/offline-sessions/{clientUuid}
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<UserSession>> GetOfflineSessionAsync(
        string userId,
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/profile
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<string> GetProfileAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get sessions associated with the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/sessions
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<UserSession>> GetSessionsAsync(
        string userId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get representation of the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<UserRepresentation> GetUserByIdAsync(string userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/groups
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<GroupRepresentation>> GetUserGroupsAsync(
        string userId,
        bool? briefRepresentation = null,
        int? first = null,
        int? max = null,
        string? search = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/groups/count
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="search"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, long>> GetUserGroupsCountAsync(
        string userId,
        string? search = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get users Returns a stream of users, filtered according to query parameters.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users
    /// </remarks>
    /// <param name="briefRepresentation">Boolean which defines whether brief representations are returned (default: false) (optional)</param>
    /// <param name="email">A String contained in email, or the complete email, if param &amp;quot;exact&amp;quot; is true (optional)</param>
    /// <param name="emailVerified">whether the email has been verified (optional)</param>
    /// <param name="enabled">Boolean representing if user is enabled or not (optional)</param>
    /// <param name="exact">Boolean which defines whether the params &amp;quot;last&amp;quot;, &amp;quot;first&amp;quot;, &amp;quot;email&amp;quot; and &amp;quot;username&amp;quot; must match exactly (optional)</param>
    /// <param name="first">Pagination offset (optional)</param>
    /// <param name="firstName">A String contained in firstName, or the complete firstName, if param &amp;quot;exact&amp;quot; is true (optional)</param>
    /// <param name="idpAlias">The alias of an Identity Provider linked to the user (optional)</param>
    /// <param name="idpUserId">The userId at an Identity Provider linked to the user (optional)</param>
    /// <param name="lastName">A String contained in lastName, or the complete lastName, if param &amp;quot;exact&amp;quot; is true (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="q">A query to search for custom attributes, in the format &#39;key1:value2 key2:value2&#39; (optional)</param>
    /// <param name="search">A String contained in username, first or last name, or email. Default search behavior is prefix-based (e.g., foo or foo*). Use foo for infix search and &amp;quot;foo&amp;quot; for exact search. (optional)</param>
    /// <param name="username">A String contained in username, or the complete username, if param &amp;quot;exact&amp;quot; is true (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ICollection<UserRepresentation>> GetUsersAsync(
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
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the number of users that match the given criteria.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/count
    /// </remarks>
    /// <param name="email">email filter (optional)</param>
    /// <param name="emailVerified"> (optional)</param>
    /// <param name="enabled">Boolean representing if user is enabled or not (optional)</param>
    /// <param name="firstName">first name filter (optional)</param>
    /// <param name="lastName">last name filter (optional)</param>
    /// <param name="q"> (optional)</param>
    /// <param name="search">arbitrary search string for all the fields below. Default search behavior is prefix-based (e.g., foo or foo*). Use foo for infix search and &amp;quot;foo&amp;quot; for exact search. (optional)</param>
    /// <param name="username">username filter (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<int> GetUsersCountAsync(
        string? email = null,
        string? emailVerified = null,
        string? enabled = null,
        string? firstName = null,
        string? lastName = null,
        string? q = null,
        string? search = null,
        string? username = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add a social login provider to the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/federated-identity/{provider}
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="provider">Social login provider id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateFederatedIdentityAsync(
        string userId,
        string provider,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Impersonate the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/impersonation
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, object>> ImpersonationUserAsync(
        string userId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove all user sessions associated with the user Also send notification to all clients that have an admin URL to invalidate the sessions for the particular user.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/logout
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task LogoutAsync(
        string userId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Move a credential to a position behind another credential
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/credentials/{credentialId}/moveAfter/{newPreviousCredentialId}
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="credentialId">The credential to move</param>
    /// <param name="newPreviousCredentialId">The credential that will be the previous element in the list. If set to null, the moved credential will be the first element in the list.</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task MoveCredentialAfterAsync(
        string userId,
        string credentialId,
        string newPreviousCredentialId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Move a credential to a first position in the credentials list of the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/credentials/{credentialId}/moveToFirst
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="credentialId">The credential to move</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task MoveCredentialToFirstAsync(
        string userId,
        string credentialId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new user Username must be unique.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users
    /// </remarks>
    /// <param name="userRepresentation">UserRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateUserAsync(
        UserRepresentation? userRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Disable all credentials for a user of a specific type
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/disable-credential-types
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DisableCredentialTypesAsync(
        string userId,
        string? body,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Send an email to the user with a link they can click to execute particular actions.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/execute-actions-email
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="clientId">Client id (optional)</param>
    /// <param name="lifespan">Number of seconds after which the generated token expires (optional)</param>
    /// <param name="redirectUri">Redirect uri (optional)</param>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task ExecuteActionsEmailAsync(
        string userId,
        string? clientId = null,
        string? lifespan = null,
        string? redirectUri = null,
        string? body = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/profile
    /// </remarks>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateProfileAsync(
        string? body,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Set up a new password for the user.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/reset-password
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="credentialRepresentation">CredentialRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task ResetPasswordAsync(
        string userId,
        CredentialRepresentation? credentialRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Send an email to the user with a link they can click to reset their password.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/reset-password-email
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="clientId">client id (optional)</param>
    /// <param name="redirectUri">redirect uri (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task ResetPasswordEmailAsync(
        string userId,
        string? clientId = null,
        string? redirectUri = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Send an email-verification email to the user An email contains a link the user can click to verify their email address.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/send-verify-email
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="clientId">Client id (optional)</param>
    /// <param name="redirectUri">Redirect uri (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task SendVerifyEmailAsync(
        string userId,
        string? clientId = null,
        string? redirectUri = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="userRepresentation">UserRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateUserAsync(
        string userId,
        UserRepresentation? userRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/groups/{groupId}
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="groupId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateUserGroupAsync(
        string userId,
        string groupId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a credential label for a user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/credentials/{credentialId}/userLabel
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="credentialId"></param>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateUserLabelAsync(
        string userId,
        string credentialId,
        string? body,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Revoke consent and offline tokens for particular client from user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/consents/{client}
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="client">Client id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteConsentAsync(
        string userId,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove a credential for a user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/credentials/{credentialId}
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="credentialId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteCredentialAsync(
        string userId,
        string credentialId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove a social login provider from user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/federated-identity/{provider}
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="provider">Social login provider id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteFederatedIdentityAsync(
        string userId,
        string provider,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteUserByIdAsync(
        string userId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/groups/{groupId}
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="groupId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteUserGroupAsync(
        string userId,
        string groupId,
        CancellationToken cancellationToken = default);

    #endregion
}
