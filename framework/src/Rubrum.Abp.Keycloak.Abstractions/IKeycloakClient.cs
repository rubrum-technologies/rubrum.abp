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
    Task<object> GetBasePathForRetrieveProvidersAsync(
        CancellationToken cancellationToken = default);

    #endregion

    #region Key

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/keys
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<KeysMetadataRepresentation> GetKeysAsync(
        CancellationToken cancellationToken = default);

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
    Task<Dictionary<string, object>> GetBruteForceUserAsync(
        string userId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Clear any user login failures for all users This can release temporary disabled users
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/attack-detection/brute-force/users
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request</param>
    Task DeleteUsersAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Clear any user login failures for the user This can release temporary disabled user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/attack-detection/brute-force/users/{userId}
    /// </remarks>
    /// <param name="userId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request</param>
    Task DeleteBruteForceUserAsync(string userId, CancellationToken cancellationToken = default);

    #endregion

    #region AuthenticationManagement

    /// <summary>
    /// Get authenticator configuration
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/config/{id}
    /// </remarks>
    /// <param name="id">Configuration id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<AuthenticatorConfigRepresentation> GetAuthenticatorConfigurationAsync(
        string id,
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
    Task GetSingleExecutionAsync(
        string executionId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get execution’s configuration
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/executions/{executionId}/config/{id}
    /// </remarks>
    /// <param name="executionId">Execution id</param>
    /// <param name="id">Configuration id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<AuthenticatorConfigRepresentation> GetExecutionConfigurationAsync(
        string executionId,
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get authentication executions for a flow
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/flows/{flowAlias}/executions
    /// </remarks>
    /// <param name="flowAlias">Flow alias</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task GetAuthenticationExecutionsForFlowAsync(
        string flowAlias,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get authentication flow for id
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/flows/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<AuthenticationFlowRepresentation> GetAuthenticationFlowForIdAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get authentication flows Returns a stream of authentication flows.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/flows
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetAuthenticationFlowsAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get form action providers Returns a stream of form action providers.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/form-action-providers
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetFormActionProvidersAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get form providers Returns a stream of form providers.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/form-providers
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetFormProvidersAsync(
        CancellationToken cancellationToken = default);

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
    Task<object> GetRequiredActionsAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get unregistered required actions Returns a stream of unregistered required actions.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/unregistered-required-actions
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetUnregisteredRequiredActionsAsync(
        CancellationToken cancellationToken = default);

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
    Task ExecutionLowerPriorityAsync(
        string executionId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Raise execution’s priority
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/executions/{executionId}/raise-priority
    /// </remarks>
    /// <param name="executionId">Execution id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task ExecutionRaisePriorityAsync(
        string executionId,
        CancellationToken cancellationToken = default);

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
    Task RegisterRequiredActionAsync(
        string? body,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Lower required action’s priority
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/required-actions/{alias}/lower-priority
    /// </remarks>
    /// <param name="alias">Alias of required action</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task RequiredActionLowerPriorityAsync(
        string alias,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Raise required action’s priority
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/required-actions/{alias}/raise-priority
    /// </remarks>
    /// <param name="alias">Alias of required action</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task RequiredActionRaisePriorityAsync(
        string alias,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update authenticator configuration
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/config/{id}
    /// </remarks>
    /// <param name="id">Configuration id</param>
    /// <param name="authenticatorConfigRepresentation">AuthenticatorConfigRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateAuthenticationConfigurationAsync(
        string id,
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
    /// <param name="id"></param>
    /// <param name="authenticationFlowRepresentation">AuthenticationFlowRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateAuthenticationFlowAsync(
        string id,
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
    /// <param name="id">Configuration id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteAuthenticatorConfigurationAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete execution
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/executions/{executionId}
    /// </remarks>
    /// <param name="executionId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteExecutionAsync(
        string executionId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete an authentication flow
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/flows/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteAuthenticationFlowAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete required action
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/authentication/required-actions/{alias}
    /// </remarks>
    /// <param name="alias">Alias of required action</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteRequiredActionAsync(
        string alias,
        CancellationToken cancellationToken = default);

    #endregion

    #region ClientAttributeCertificate

    /// <summary>
    /// Get key info
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/certificates/{attr}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="attr"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<CertificateRepresentation> GetCertificateAsync(
        string id,
        string attr,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a keystore file for the client, containing private key and public certificate
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/certificates/{attr}/download
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="attr"></param>
    /// <param name="keyStoreConfig">KeyStoreConfig (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Stream> GetKeystoreFileForClientAsync(
        string id,
        string attr,
        KeyStoreConfig? keyStoreConfig,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Generate a new certificate with new key pair
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/certificates/{attr}/generate
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="attr"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<CertificateRepresentation> GenerateCertificateAsync(
        string id,
        string attr,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Generate a new keypair and certificate, and get the private key file Generates a keypair and certificate and serves the private key in a specified keystore format. Only generated public certificate is saved in Keycloak DB - the private key is not.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/certificates/{attr}/generate-and-download
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="attr"></param>
    /// <param name="keyStoreConfig">KeyStoreConfig (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Stream> GenerateKeypairAndCertificateAsync(
        string id,
        string attr,
        KeyStoreConfig? keyStoreConfig,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Upload certificate and eventually private key
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/certificates/{attr}/upload
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="attr"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<CertificateRepresentation> UploadCertificateAndPrivateKeyAsync(
        string id,
        string attr,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Upload only certificate, not private key
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/certificates/{attr}/upload-certificate
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="attr"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<CertificateRepresentation> UploadOnlyCertificateAsync(
        string id,
        string attr,
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
    Task<object> GetClientsInitialAccessAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new initial access token.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients-initial-access
    /// </remarks>
    /// <param name="clientInitialAccessCreatePresentation">ClientInitialAccessCreatePresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ClientInitialAccessPresentation> CreateClientsInitialAccessAsync(
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
    Task DeleteClientsInitialAccessAsync(
        string id,
        CancellationToken cancellationToken = default);

    #endregion

    #region ClientRoleMappings

    /// <summary>
    /// Get client-level role mappings for the user, and the app
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/clients/{client}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetGroupRoleMappingsClientAsync(
        string id,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get available client-level roles that can be mapped to the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/clients/{client}/available
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetGroupRoleMappingsClientAvailableAsync(
        string id,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective client-level role mappings This recurses any composite roles
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/clients/{client}/composite
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetGroupRoleMappingsClientCompositeAsync(
        string id,
        string client,
        string briefRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get client-level role mappings for the user, and the app
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/clients/{client}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetUserRoleMappingsClientAsync(
        string id,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get available client-level roles that can be mapped to the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/clients/{client}/available
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetUserRoleMappingsClientAvailableAsync(
        string id,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective client-level role mappings This recurses any composite roles
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/clients/{client}/composite
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetUserRoleMappingsClientCompositeAsync(
        string id,
        string client,
        string briefRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add client-level roles to the user role mapping
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/clients/{client}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateGroupRoleMappingsClientAsync(
        string id,
        string client,
        RoleRepresentation roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add client-level roles to the user role mapping
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/clients/{client}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateUserRoleMappingsClientAsync(
        string id,
        string client,
        RoleRepresentation roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete client-level roles from user role mapping
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/clients/{client}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteGroupRoleMappingsClientAsync(
        string id,
        string client,
        RoleRepresentation roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete client-level roles from user role mapping
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/clients/{client}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteUserRoleMappingsClientAsync(
        string id,
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
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ClientRepresentation> GetClientByIdAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/management/permissions
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> GetClientManagementPermissionsAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the client secret
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/client-secret
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<CredentialRepresentation> GetClientSecretAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get user sessions for client Returns a list of user sessions associated with this client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/user-sessions
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="first">Paging offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientUserSessionsAsync(
        string id,
        string? first = null,
        string? max = null,
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
    Task<object> GetClientsAsync(
        string? clientId = null,
        string? first = null,
        string? max = null,
        string? q = null,
        string? search = null,
        string? viewableOnly = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get default client scopes. Only name and ids are returned.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/default-client-scopes
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetDefaultClientScopesAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create JSON with payload of example access token
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/evaluate-scopes/generate-example-access-token
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<AccessToken> GetGenerateExampleAccessTokenAsync(
        string id,
        string? scope = null,
        string? userId = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create JSON with payload of example id token
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/evaluate-scopes/generate-example-id-token
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<IdToken> GetGenerateExampleIdTokenAsync(
        string id,
        string? scope = null,
        string? userId = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create JSON with payload of example user info
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/evaluate-scopes/generate-example-userinfo
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, object>> GetGenerateExampleUserinfoAsync(
        string id,
        string? scope = null,
        string? userId = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective scope mapping of all roles of particular role container, which this client is defacto allowed to have in the accessToken issued for him.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/evaluate-scopes/scope-mappings/{roleContainerId}/granted
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleContainerId">either realm name OR client UUID</param>
    /// <param name="scope"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetGrantedAsync(
        string id,
        string roleContainerId,
        string? scope = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/installation/providers/{providerId}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="providerId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task GetInstallationProviderAsync(
        string id,
        string providerId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get roles, which this client doesn’t have scope for and can’t have them in the accessToken issued for him.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/evaluate-scopes/scope-mappings/{roleContainerId}/not-granted
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleContainerId">either realm name OR client UUID</param>
    /// <param name="scope"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetNotGrantedAsync(
        string id,
        string roleContainerId,
        string? scope = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get application offline session count Returns a number of offline user sessions associated with this client { \\\&amp;quot;count\\\&amp;quot;: number }
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/offline-session-count
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, long>> GetOfflineSessionCountAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get offline sessions for client Returns a list of offline user sessions associated with this client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/offline-sessions
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="first">Paging offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetOfflineSessionsAsync(
        string id,
        string? first = null,
        string? max = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get optional client scopes. Only name and ids are returned.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/optional-client-scopes
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetOptionalClientScopesAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return list of all protocol mappers, which will be used when generating tokens issued for particular client.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/evaluate-scopes/protocol-mappers
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="scope"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetProtocolMappersAsync(
        string id,
        string? scope = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the rotated client secret
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/client-secret/rotated
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<CredentialRepresentation> GetRotatedClientSecretAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a user dedicated to the service account
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/service-account-user
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<UserRepresentation> GetServiceAccountUserAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get application session count Returns a number of user sessions associated with this client { \\\&amp;quot;count\\\&amp;quot;: number }
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/session-count
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, long>> GetSessionCountAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Test if registered cluster nodes are available Tests availability by sending &amp;#39;ping&amp;#39; request to all cluster nodes.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/test-nodes-available
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<GlobalRequestResult> GetTestNodesAvailableAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Push the client’s revocation policy to its admin URL If the client has an admin URL, push revocation policy to it.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/push-revocation
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<GlobalRequestResult> ClientPushRevocationAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Generate a new secret for the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/client-secret
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<CredentialRepresentation> GenerateClientSecretAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new client Client’s client_id must be unique!
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients
    /// </remarks>
    /// <param name="clientRepresentation">ClientRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientAsync(
        ClientRepresentation? clientRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Register a cluster node with the client Manually register cluster node to this client - usually it’s not needed to call this directly as adapter should handle by sending registration request to Keycloak
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/nodes
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task RegisterClusterNodeWithClientAsync(
        string id,
        string? body = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Generate a new registration access token for the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/registration-access-token
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ClientRepresentation> GenerateRegistrationAccessTokenAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="clientRepresentation">ClientRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateClientAsync(
        string id,
        ClientRepresentation? clientRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/management/permissions
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="managementPermissionReference">ManagementPermissionReference (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> UpdateClientManagementPermissionsAsync(
        string id,
        ManagementPermissionReference? managementPermissionReference,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/default-client-scopes/{clientScopeId}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="clientScopeId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateDefaultClientScopeAsync(
        string id,
        string clientScopeId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/optional-client-scopes/{clientScopeId}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="clientScopeId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateOptionalClientScopeAsync(
        string id,
        string clientScopeId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientByIdAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/default-client-scopes/{clientScopeId}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="clientScopeId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteDefaultClientScopeAsync(
        string id,
        string clientScopeId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Unregister a cluster node from the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/nodes/{node}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="node"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UnregisterClusterNodeFromClient(
        string id,
        string node,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/optional-client-scopes/{clientScopeId}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="clientScopeId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteOptionalClientScopeAsync(
        string id,
        string clientScopeId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Invalidate the rotated secret for the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/client-secret/rotated
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteRotatedAsync(
        string id,
        CancellationToken cancellationToken = default);

    #endregion

    #region ClientScopes

    /// <summary>
    /// Get representation of the client scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ClientScopeRepresentation> GetClientScopeAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get client scopes belonging to the realm Returns a list of client scopes belonging to the realm
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientScopesAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get representation of the client scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ClientScopeRepresentation> GetClientTemplateAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get client scopes belonging to the realm Returns a list of client scopes belonging to the realm
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientTemplatesAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new client scope Client Scope’s name must be unique!
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes
    /// </remarks>
    /// <param name="clientScopeRepresentation">ClientScopeRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientScopesAsync(
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
    Task CreateClientTemplatesAsync(
        ClientScopeRepresentation? clientScopeRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the client scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="clientScopeRepresentation">ClientScopeRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateClientScopeAsync(
        string id,
        ClientScopeRepresentation? clientScopeRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the client scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="clientScopeRepresentation">ClientScopeRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateClientTemplateAsync(
        string id,
        ClientScopeRepresentation? clientScopeRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the client scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientScopeAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the client scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientTemplateAsync(
        string id,
        CancellationToken cancellationToken = default);

    #endregion

    #region Component

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/components/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ComponentRepresentation> GetComponentAsync(
        string id,
        CancellationToken cancellationToken = default);

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
    Task<object> GetComponentsAsync(
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
    /// <param name="id"></param>
    /// <param name="type"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetSubComponentTypesAsync(
        string id,
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
    /// <param name="id"></param>
    /// <param name="componentRepresentation">ComponentRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateComponentAsync(
        string id,
        ComponentRepresentation? componentRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/components/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteComponentAsync(
        string id,
        CancellationToken cancellationToken = default);

    #endregion

    #region Groups

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<GroupRepresentation> GetGroupAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/management/permissions
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> GetGroupManagementPermissionsAsync(
        string id,
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
    Task<object> GetGroupsAsync(
        string? briefRepresentation = null,
        string? exact = null,
        string? first = null,
        string? max = null,
        string? populateHierarchy = null,
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
        string? top = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get users Returns a stream of users, filtered according to query parameters
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/members
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">Only return basic information (only guaranteed to return id, username, created, first and last name, email, enabled state, email verification state, federation link, and access. Note that it means that namely user attributes, required actions, and not before are not returned.) (optional)</param>
    /// <param name="first">Pagination offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetMembersAsync(
        string id,
        string? briefRepresentation = null,
        string? first = null,
        string? max = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Set or create child.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/children
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="groupRepresentation">GroupRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateChildrenAsync(
        string id,
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
        GroupRepresentation? groupRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update group, ignores subgroups.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="groupRepresentation">GroupRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateGroupByIdAsync(
        string id,
        GroupRepresentation? groupRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/management/permissions
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="managementPermissionReference">ManagementPermissionReference (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> UpdateGroupManagementPermissionsAsync(
        string id,
        ManagementPermissionReference? managementPermissionReference = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteGroupByIdAsync(
        string id,
        CancellationToken cancellationToken = default);

    #endregion

    #region IdentityProviders

    /// <summary>
    /// Export public broker configuration for identity provider
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/instances/{alias}/export
    /// </remarks>
    /// <param name="alias"></param>
    /// <param name="format">Format to use (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task GetExportAsync(
        string alias,
        string? format = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get identity providers
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/providers/{provider_id}
    /// </remarks>
    /// <param name="providerId">Provider id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task GetIdentityProvidersAsync(
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
    Task<object> GetIdentityProvidersAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mapper by id for the identity provider
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/instances/{alias}/mappers/{id}
    /// </remarks>
    /// <param name="alias"></param>
    /// <param name="id">Mapper id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<IdentityProviderMapperRepresentation> GetMapperForIdentityProviderAsync(
        string alias,
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mapper types for identity provider
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/identity-provider/instances/{alias}/mapper-types
    /// </remarks>
    /// <param name="alias"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, IdentityProviderMapperTypeRepresentation>> GetMapperTypesForIdentityProviderAsync(
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
    Task<object> GetMappersForIdentityProviderAsync(
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
    /// <param name="id">Mapper id</param>
    /// <param name="identityProviderMapperRepresentation">IdentityProviderMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateMapperForIdentityProviderAsync(
        string alias,
        string id,
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
    /// <param name="id">Mapper id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteMapperForIdentityProviderAsync(
        string alias,
        string id,
        CancellationToken cancellationToken = default);

    #endregion

    #region ProtocolMappers

    /// <summary>
    /// Get mapper by id
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ProtocolMapperRepresentation> GetClientProtocolMappersAsync(
        string id1,
        string id2,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mappers
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/protocol-mappers/models
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientProtocolMappersAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mappers by name for a specific protocol
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/protocol-mappers/protocol/{protocol}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="protocol"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientProtocolMappersProtocolAsync(
        string id,
        string protocol,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mapper by id
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ProtocolMapperRepresentation> GetClientScopeProtocolMappersAsync(
        string id1,
        string id2,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mappers
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/protocol-mappers/models
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientScopeProtocolMappersAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mappers by name for a specific protocol
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/protocol-mappers/protocol/{protocol}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="protocol"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientScopeProtocolMappersProtocolAsync(
        string id,
        string protocol,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mapper by id
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ProtocolMapperRepresentation> GetClientTemplateProtocolMappersAsync(
        string id1,
        string id2,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mappers
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/protocol-mappers/models
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientTemplateProtocolMappersAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get mappers by name for a specific protocol
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/protocol-mappers/protocol/{protocol}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="protocol"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientTemplateProtocolMappersProtocolAsync(
        string id,
        string protocol,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create multiple mappers
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/protocol-mappers/add-models
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="protocolMapperRepresentation">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientProtocolMappersAsync(
        string id,
        ProtocolMapperRepresentation? protocolMapperRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/protocol-mappers/models
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="protocolMapperRepresentation">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientTemplatesProtocolMappersAsync(
        string id,
        ProtocolMapperRepresentation? protocolMapperRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create multiple mappers
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/protocol-mappers/add-models
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="protocolMapperRepresentation">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientScopeProtocolMultipleMappersAsync(
        string id,
        ProtocolMapperRepresentation? protocolMapperRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/protocol-mappers/models
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="protocolMapperRepresentation">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientScopeProtocolMappersAsync(
        string id,
        ProtocolMapperRepresentation? protocolMapperRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create multiple mappers
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/protocol-mappers/add-models
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="protocolMapperRepresentation">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientTemplateProtocolMultipleMappersAsync(
        string id,
        ProtocolMapperRepresentation? protocolMapperRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/protocol-mappers/models
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="protocolMapperRepresentation">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientTemplateProtocolMappersAsync(
        string id,
        ProtocolMapperRepresentation? protocolMapperRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <param name="protocolMapperRepresentation">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateClientProtocolMappersAsync(
        string id1,
        string id2,
        ProtocolMapperRepresentation? protocolMapperRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <param name="protocolMapperRepresentation">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateClientScopeProtocolMappersAsync(
        string id1,
        string id2,
        ProtocolMapperRepresentation? protocolMapperRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <param name="protocolMapperRepresentation">ProtocolMapperRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateClientTemplateProtocolMappersAsync(
        string id1,
        string id2,
        ProtocolMapperRepresentation? protocolMapperRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientProtocolMappersAsync(
        string id1,
        string id2,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientScopeProtocolMappersAsync(
        string id1,
        string id2,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the mapper
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id1}/protocol-mappers/models/{id2}
    /// </remarks>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientTemplateProtocolMappersAsync(
        string id1,
        string id2,
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
    Task<object> GetAccessibleRealmsAsync(
        string? briefRepresentation = null,
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
    Task<object> GetAdminEventsAsync(
        string? authClient = null,
        string? authIpAddress = null,
        string? authRealm = null,
        string? authUser = null,
        string? dateFrom = null,
        string? dateTo = null,
        string? first = null,
        string? max = null,
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
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<RealmRepresentation> GetRealmAsync(
        string realm,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get client session stats Returns a JSON map.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-session-stats
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientSessionStatsAsync(
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
    Task<object> GetDefaultDefaultClientScopesAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get group hierarchy. Only name and ids are returned.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/default-groups
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetDefaultGroupsAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm optional client scopes. Only name and ids are returned.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/default-optional-client-scopes
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetDefaultOptionalClientScopesAsync(
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
    Task<object> GetEventsAsync(
        string? client = null,
        string? dateFrom = null,
        string? dateTo = null,
        string? first = null,
        string? ipAddress = null,
        string? max = null,
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
    Task<object> GetLocalizationAsync(
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
        string? includeGlobalProfiles = null,
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
    Task<GlobalRequestResult> LogoutAllAsync(
        CancellationToken cancellationToken = default);

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
    Task ImportPartialRealmAsync(
        Stream? body,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Push the realm’s revocation policy to any client that has an admin url associated with it.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/push-revocation
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<GlobalRequestResult> PushRevocationByRealmAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Test SMTP connection with current logged in user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/testSMTPConnection
    /// </remarks>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task TestSmtpConnectionAsync(
        string? body,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the top-level information of the realm Any user, roles or client information in the representation will be ignored.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}
    /// </remarks>
    /// <param name="realmRepresentation">RealmRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateRealmAsync(
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
    Task UpdateDefaultDefaultClientScopeAsync(
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
    Task UpdateDefaultGroupAsync(
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
    Task UpdateDefaultOptionalClientScopeAsync(
        string clientScopeId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: 
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
    /// Url: /{realm}/events/config
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
    /// Url: 
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
    Task DeleteAdminEventsAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the realm
    /// </summary>
    /// <remarks>
    /// Url: /{realm}
    /// </remarks>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteRealmAsync(
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
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<MappingsRepresentation> GetGroupRoleMappingsAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level role mappings 
    /// </summary>
    /// <remarks>
    /// Url: /admin/realms/{realm}/groups/{id}/role-mappings/realm
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetGroupRoleMappingsRealmAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles that can be mapped
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/realm/available
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetGroupRoleMappingsRealmAvailableAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective realm-level role mappings This will recurse all composite roles to get the result.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/realm/composite
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetGroupRoleMappingsRealmCompositeAsync(
        string id,
        string? briefRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get role mappings
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<MappingsRepresentation> GetUserRoleMappingsAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level role mappings
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/realm
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetUserRoleMappingsRealmAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles that can be mapped
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/realm/available
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetUserRoleMappingsRealmAvailableAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective realm-level role mappings This will recurse all composite roles to get the result.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/realm/composite
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetUserRoleMappingsRealmCompositeAsync(
        string id,
        string? briefRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add realm-level role mappings to the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/realm
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateGroupRoleMappingsRealmAsync(
        string id,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add realm-level role mappings to the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/realm
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateUserRoleMappingsRealmAsync(
        string id,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete realm-level role mappings
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/groups/{id}/role-mappings/realm
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteGroupRoleMappingsRealmAsync(
        string id,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete realm-level role mappings
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/role-mappings/realm
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteUserRoleMappingsRealmAsync(
        string id,
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
    /// <param name="id"></param>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<RoleRepresentation> GetClientRoleAsync(
        string id,
        string roleName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get composites of the role
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/composites
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientRoleCompositesAsync(
        string id,
        string roleName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/composites/clients/{clientUuid}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientRoleCompositesClientAsync(
        string id,
        string roleName,
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles of the role’s composite
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/composites/realm
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientRoleCompositesRealmAsync(
        string id,
        string roleName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a stream of groups that have the specified role name
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/groups
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleName">the role name.</param>
    /// <param name="briefRepresentation">if false, return a full representation of the {@code GroupRepresentation} objects. (optional)</param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientRoleGroupsAsync(
        string id,
        string roleName,
        string? briefRepresentation = null,
        string? first = null,
        string? max = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/management/permissions
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleName"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> GetClientRoleManagementPermissionsAsync(
        string id,
        string roleName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a stream of users that have the specified role name.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/users
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleName">the role name.</param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientRoleUsersAsync(
        string id,
        string roleName,
        string? first = null,
        string? max = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all roles for the realm or client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientRolesAsync(
        string id,
        string? briefRepresentation = null,
        string? first = null,
        string? max = null,
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
    Task<object> GetRoleCompositesByNameAsync(
        string roleName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles/{role-name}/composites/clients/{clientUuid}
    /// </remarks>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetRoleCompositesClientByNameByClientIdAsync(
        string roleName,
        string clientId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles of the role’s composite
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/roles/{role-name}/composites/realm
    /// </remarks>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetRoleCompositesRealmByNameAsync(
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
    Task<object> GetRoleGroupsByNameAsync(
        string roleName,
        string? briefRepresentation = null,
        string? first = null,
        string? max = null,
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
    Task<object> GetRoleUsersByNameAsync(
        string roleName,
        string? first = null,
        string? max = null,
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
    Task<object> GetRolesAsync(
        string? briefRepresentation = null,
        string? first = null,
        string? max = null,
        string? search = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add a composite to the role
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/composites
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientRoleCompositesAsync(
        string id,
        string roleName,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new role for the realm or client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientRolesAsync(
        string id,
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
    Task CreateRolesAsync(
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a role by name
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateClientRoleAsync(
        string id,
        string roleName,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/management/permissions
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleName"></param>
    /// <param name="managementPermissionReference">ManagementPermissionReference (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<ManagementPermissionReference> UpdateClientRoleManagementPermissionsAsync(
        string id,
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
    /// <param name="id"></param>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientRoleAsync(
        string id,
        string roleName,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove roles from the role’s composite
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/roles/{role-name}/composites
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleName">role&#39;s name (not id!)</param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientRoleCompositesAsync(
        string id,
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
    Task<RoleRepresentation> GetRoleByIdAsync(
        string roleId,
        CancellationToken cancellationToken = default);

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
    Task<object> GetRoleByIdCompositesAsync(
        string roleId,
        string? first = null,
        string? max = null,
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
    Task<object> GetRoleByIdCompositesClientAsync(
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
    Task<object> GetRoleByIdCompositesRealmAsync(
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
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<MappingsRepresentation> GetClientScopeMappingsAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the roles associated with a client’s scope Returns roles for the client.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientScopeMappingsClientAsync(
        string id,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// The available client-level roles Returns the roles for the client that can be associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/clients/{client}/available
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientScopeMappingsClientAvailableAsync(
        string id,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective client roles Returns the roles for the client that are associated with the client’s scope.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/clients/{client}/composite
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientScopeMappingsClientCompositeAsync(
        string id,
        string client,
        string? briefRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientScopeMappingsRealmAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles that are available to attach to this client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/realm/available
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientScopeMappingsRealmAvailableAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective realm-level roles associated with the client’s scope What this does is recurse any composite roles associated with the client’s scope and adds the roles to this lists.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/realm/composite
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientScopeMappingsRealmCompositeAsync(
        string id,
        string? briefRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all scope mappings for the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<MappingsRepresentation> GetClientScopeScopeMappingsAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the roles associated with a client’s scope Returns roles for the client.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientScopeScopeMappingsClientAsync(
        string id,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// The available client-level roles Returns the roles for the client that can be associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/clients/{client}/available
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientScopeScopeMappingsClientAvailableAsync(
        string id,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective client roles Returns the roles for the client that are associated with the client’s scope.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/clients/{client}/composite
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientScopeScopeMappingsClientCompositeAsync(
        string id,
        string client,
        string? briefRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientScopeScopeMappingsRealmAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles that are available to attach to this client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/realm/available
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientScopeScopeMappingsRealmAvailableAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective realm-level roles associated with the client’s scope What this does is recurse any composite roles associated with the client’s scope and adds the roles to this lists.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/realm/composite
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientScopeScopeMappingsRealmCompositeAsync(
        string id,
        string? briefRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all scope mappings for the client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<MappingsRepresentation> GetClientTemplateScopeMappingsAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the roles associated with a client’s scope Returns roles for the client.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientTemplateScopeMappingsClientAsync(
        string id,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// The available client-level roles Returns the roles for the client that can be associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/clients/{client}/available
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientTemplateScopeMappingsClientAvailableAsync(
        string id,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective client roles Returns the roles for the client that are associated with the client’s scope.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/clients/{client}/composite
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientTemplateScopeMappingsClientCompositeAsync(
        string id,
        string client,
        string? briefRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientTemplateScopeMappingsRealmAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get realm-level roles that are available to attach to this client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/realm/available
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientTemplateScopeMappingsRealmAvailableAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get effective realm-level roles associated with the client’s scope What this does is recurse any composite roles associated with the client’s scope and adds the roles to this lists.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/realm/composite
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetClientTemplateScopeMappingsRealmCompositeAsync(
        string id,
        string? briefRepresentation = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add client-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientScopeMappingsClientAsync(
        string id,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add a set of realm-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientScopeMappingsRealmAsync(
        string id,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add client-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientScopeScopeMappingsClientAsync(
        string id,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add a set of realm-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientScopeScopeMappingsRealmAsync(
        string id,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add client-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientTemplateScopeMappingsClientAsync(
        string id,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add a set of realm-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateClientTemplateScopeMappingsRealmAsync(
        string id,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove client-level roles from the client’s scope.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientScopeMappingsClientAsync(
        string id,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove a set of realm-level roles from the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/clients/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientScopeMappingsRealmAsync(
        string id,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove client-level roles from the client’s scope.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientScopeScopeMappingsClientAsync(
        string id,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove a set of realm-level roles from the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-scopes/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientScopeScopeMappingsRealmAsync(
        string id,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove client-level roles from the client’s scope.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/clients/{client}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientTemplateScopeMappingsClientAsync(
        string id,
        string client,
        RoleRepresentation? roleRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove a set of realm-level roles from the client’s scope
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/client-templates/{id}/scope-mappings/realm
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="roleRepresentation">RoleRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteClientTemplateScopeMappingsRealmAsync(
        string id,
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
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetConfiguredUserStorageCredentialTypesAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get consents granted by the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/consents
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetConsentsAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/credentials
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetCredentialsAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get social logins associated with the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/federated-identity
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetFederatedIdentityAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get offline sessions associated with the user and client
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/offline-sessions/{clientUuid}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="clientId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetOfflineSessionAsync(
        string id,
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
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetSessionsAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get representation of the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<UserRepresentation> GetUserByIdAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/groups
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<object> GetUserGroupsAsync(
        string id,
        string? briefRepresentation = null,
        string? first = null,
        string? max = null,
        string? search = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/groups/count
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="search"> (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, long>> GetUserGroupsCountAsync(
        string id,
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
    Task<object> GetUsersAsync(
        string? briefRepresentation = null,
        string? email = null,
        string? emailVerified = null,
        string? enabled = null,
        string? exact = null,
        string? first = null,
        string? firstName = null,
        string? idpAlias = null,
        string? idpUserId = null,
        string? lastName = null,
        string? max = null,
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
    /// <param name="id"></param>
    /// <param name="provider">Social login provider id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task CreateFederatedIdentityAsync(
        string id,
        string provider,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Impersonate the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/impersonation
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task<Dictionary<string, object>> ImpersonationUserAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove all user sessions associated with the user Also send notification to all clients that have an admin URL to invalidate the sessions for the particular user.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/logout
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task LogoutAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Move a credential to a position behind another credential
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/credentials/{credentialId}/moveAfter/{newPreviousCredentialId}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="credentialId">The credential to move</param>
    /// <param name="newPreviousCredentialId">The credential that will be the previous element in the list. If set to null, the moved credential will be the first element in the list.</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task MoveCredentialAfterAsync(
        string id,
        string credentialId,
        string newPreviousCredentialId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Move a credential to a first position in the credentials list of the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/credentials/{credentialId}/moveToFirst
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="credentialId">The credential to move</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task MoveCredentialToFirstAsync(
        string id,
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
    Task CreateUsersAsync(
        UserRepresentation? userRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Disable all credentials for a user of a specific type
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/disable-credential-types
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DisableCredentialTypesAsync(
        string id,
        string? body,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Send an email to the user with a link they can click to execute particular actions.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/execute-actions-email
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="clientId">Client id (optional)</param>
    /// <param name="lifespan">Number of seconds after which the generated token expires (optional)</param>
    /// <param name="redirectUri">Redirect uri (optional)</param>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task ExecuteActionsEmailAsync(
        string id,
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
    /// <param name="id"></param>
    /// <param name="credentialRepresentation">CredentialRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task ResetPasswordAsync(
        string id,
        CredentialRepresentation? credentialRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Send an email to the user with a link they can click to reset their password.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/reset-password-email
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="clientId">client id (optional)</param>
    /// <param name="redirectUri">redirect uri (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task ResetPasswordEmailAsync(
        string id,
        string? clientId = null,
        string? redirectUri = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Send an email-verification email to the user An email contains a link the user can click to verify their email address.
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/send-verify-email
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="clientId">Client id (optional)</param>
    /// <param name="redirectUri">Redirect uri (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task SendVerifyEmailAsync(
        string id,
        string? clientId = null,
        string? redirectUri = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the user
    /// </summary>
    /// <remarks>
    /// Url: 
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="userRepresentation">UserRepresentation (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateUserAsync(
        string id,
        UserRepresentation? userRepresentation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/groups/{groupId}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="groupId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateUserGroupAsync(
        string id,
        string groupId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a credential label for a user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/credentials/{credentialId}/userLabel
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="credentialId"></param>
    /// <param name="body">[string] (optional)</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task UpdateUserLabelAsync(
        string id,
        string credentialId,
        string? body,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Revoke consent and offline tokens for particular client from user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/consents/{client}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="client">Client id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteConsentAsync(
        string id,
        string client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove a credential for a user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/credentials/{credentialId}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="credentialId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteCredentialAsync(
        string id,
        string credentialId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove a social login provider from user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/federated-identity/{provider}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="provider">Social login provider id</param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteFederatedIdentityAsync(
        string id,
        string provider,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the user
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteUserByRealmByIdAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Missing description
    /// </summary>
    /// <remarks>
    /// Url: /{realm}/users/{id}/groups/{groupId}
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="groupId"></param>
    /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
    Task DeleteUserGroupAsync(
        string id,
        string groupId,
        CancellationToken cancellationToken = default);

    #endregion
}
