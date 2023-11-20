using Shouldly;
using Xunit;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace Rubrum.Abp.Keycloak;

public class KeycloakClientTests : RubrumAbpKeycloakTestBase
{
    private readonly IKeycloakClient _keycloakClient;

    public KeycloakClientTests()
    {
        _keycloakClient = GetRequiredService<IKeycloakClient>();
    }

    #region ClientRegistrationPolicy

    [Fact]
    public async Task GetBasePathForRetrieveProvidersAsync()
    {
        var result = await _keycloakClient.GetBasePathForRetrieveProvidersAsync();
        result.Count.ShouldBeGreaterThan(0);
    }

    #endregion

    #region Key

    [Fact]
    public async Task GetKeysAsync()
    {
        var result = await _keycloakClient.GetKeysAsync();
        result.ShouldNotBeNull();
    }

    #endregion

    #region AttackDetection

    [Fact]
    public async Task GetUserNameStatusInBruteForceDetectionAsync()
    {
        var userId = await GetUserIdAsync();
        var result = await _keycloakClient.GetUserNameStatusInBruteForceDetectionAsync(userId);
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task ClearUserLoginFailuresAsync()
    {
        await _keycloakClient.ClearUserLoginFailuresAsync();
    }

    [Fact]
    public async Task ClearUserLoginFailuresByUserIdAsync()
    {
        var userId = await GetUserIdAsync();
        await _keycloakClient.ClearUserLoginFailuresAsync(userId);
    }

    #endregion

    #region AuthenticationManagement

    [Fact]
    public async Task GetAuthenticatorConfigurationAsync()
    {
    }

    [Fact]
    public async Task GetAuthenticatorProvidersAsync() { }

    [Fact]
    public async Task GetClientAuthenticatorProvidersAsync() { }

    [Fact]
    public async Task GetAuthenticatorProvidersConfigurationAsync() { }

    [Fact]
    public async Task GetAuthenticationExecutionAsync() { }

    [Fact]
    public async Task GetAuthenticationExecutionConfigurationAsync() { }

    [Fact]
    public async Task GetAuthenticationExecutionsForFlowAsync() { }

    [Fact]
    public async Task GetAuthenticationFlowForIdAsync() { }

    [Fact]
    public async Task GetAuthenticationFlowsAsync() { }

    [Fact]
    public async Task GetFormActionProvidersAsync() { }

    [Fact]
    public async Task GetFormProvidersAsync() { }

    [Fact]
    public async Task GetConfigurationForAllClientsAsync() { }

    [Fact]
    public async Task GetRequiredActionForAliasAsync() { }

    [Fact]
    public async Task GetRequiredActionsAsync() { }

    [Fact]
    public async Task GetUnregisteredRequiredActionsAsync() { }

    [Fact]
    public async Task CreateAuthenticatorConfigurationAsync() { }

    [Fact]
    public async Task CopyExistingAuthenticationFlowAsync() { }

    [Fact]
    public async Task CreateAuthenticationExecutionToFlowAsync() { }

    [Fact]
    public async Task UpdateExecutionWithConfigurationAsync()
    {
    }

    [Fact]
    public async Task ExecutionLowerPriorityAsync() { }

    [Fact]
    public async Task ExecutionRaisePriorityAsync() { }

    [Fact]
    public async Task CreateAuthenticationExecutionAsync() { }

    [Fact]
    public async Task CreateFlowWithNewExecutionAsync() { }

    [Fact]
    public async Task CreateAuthenticationFlowAsync() { }

    [Fact]
    public async Task RegisterRequiredActionAsync() { }

    [Fact]
    public async Task RequiredActionLowerPriorityAsync() { }

    [Fact]
    public async Task RequiredActionRaisePriorityAsync() { }

    [Fact]
    public async Task UpdateAuthenticationConfigurationAsync() { }

    [Fact]
    public async Task UpdateAuthenticationExecutionsOfFlowAsync() { }

    [Fact]
    public async Task UpdateAuthenticationFlowAsync() { }

    [Fact]
    public async Task UpdateRequiredActionAsync() { }

    [Fact]
    public async Task DeleteAuthenticatorConfigurationAsync() { }

    [Fact]
    public async Task DeleteExecutionAsync() { }

    [Fact]
    public async Task DeleteAuthenticationFlowAsync() { }

    [Fact]
    public async Task DeleteRequiredActionAsync() { }

    #endregion

    #region ClientAttributeCertificate

    [Fact]
    public async Task GetCertificateAsync() { }

    [Fact]
    public async Task GetKeystoreFileForClientAsync() { }

    [Fact]
    public async Task GenerateCertificateAsync() { }

    [Fact]
    public async Task GenerateKeypairAndCertificateAsync() { }

    [Fact]
    public async Task UploadCertificateAndPrivateKeyAsync() { }

    [Fact]
    public async Task UploadOnlyCertificateAsync() { }

    #endregion

    #region ClientInitialAccess

    [Fact]
    public async Task GetClientInitialAccessAsync() { }

    [Fact]
    public async Task CreateInitialAccessTokenAsync() { }

    [Fact]
    public async Task DeleteInitialAccessTokenAsync() { }

    #endregion

    #region ClientRoleMappings

    [Fact]
    public async Task GetGroupRoleMappingsClientAsync() { }

    [Fact]
    public async Task GetGroupRoleMappingsClientAvailableAsync() { }

    [Fact]
    public async Task GetGroupRoleMappingsClientCompositeAsync() { }

    [Fact]
    public async Task GetUserRoleMappingsClientAsync() { }

    [Fact]
    public async Task GetUserRoleMappingsClientAvailableAsync() { }

    [Fact]
    public async Task GetUserRoleMappingsClientCompositeAsync() { }

    [Fact]
    public async Task ChangeGroupRoleMappingsClientAsync() { }

    [Fact]
    public async Task ChangeUserRoleMappingsClientAsync() { }

    [Fact]
    public async Task DeleteGroupRoleMappingsClientAsync() { }

    [Fact]
    public async Task DeleteUserRoleMappingsClientAsync() { }

    #endregion

    #region Clients

    [Fact]
    public async Task GetClientByIdAsync() { }

    [Fact]
    public async Task GetClientManagementPermissionsAsync() { }

    [Fact]
    public async Task GetClientSecretAsync() { }

    [Fact]
    public async Task GetClientUserSessionsAsync() { }

    [Fact]
    public async Task GetClientsAsync() { }

    [Fact]
    public async Task GetDefaultClientScopesAsync() { }

    [Fact]
    public async Task GetGenerateExampleAccessTokenAsync() { }

    [Fact]
    public async Task GetGenerateExampleIdTokenAsync() { }

    [Fact]
    public async Task GetGenerateExampleUserinfoAsync() { }

    [Fact]
    public async Task GetGrantedAsync() { }

    [Fact]
    public async Task GetNotGrantedAsync() { }

    [Fact]
    public async Task GetOfflineSessionCountAsync() { }

    [Fact]
    public async Task GetOfflineSessionsAsync() { }

    [Fact]
    public async Task GetOptionalClientScopesAsync() { }

    [Fact]
    public async Task GetProtocolMappersInTokenGenerationAsync() { }

    [Fact]
    public async Task GetRotatedClientSecretAsync() { }

    [Fact]
    public async Task GetServiceAccountUserAsync() { }

    [Fact]
    public async Task GetSessionCountAsync() { }

    [Fact]
    public async Task GetTestNodesAvailableAsync() { }

    [Fact]
    public async Task ClientPushRevocationAsync() { }

    [Fact]
    public async Task GenerateClientSecretAsync() { }

    [Fact]
    public async Task CreateClientAsync() { }

    [Fact]
    public async Task RegisterClusterNodeWithClientAsync() { }

    [Fact]
    public async Task GenerateRegistrationAccessTokenAsync() { }

    [Fact]
    public async Task UpdateClientAsync() { }

    [Fact]
    public async Task UpdateClientManagementPermissionsAsync() { }

    [Fact]
    public async Task UpdateDefaultClientScopeAsync() { }

    [Fact]
    public async Task UpdateOptionalClientScopeAsync() { }

    [Fact]
    public async Task DeleteClientByIdAsync() { }

    [Fact]
    public async Task DeleteDefaultClientScopeAsync() { }

    [Fact]
    public async Task UnregisterClusterNodeFromClient() { }

    [Fact]
    public async Task DeleteOptionalClientScopeAsync() { }

    [Fact]
    public async Task DeleteRotatedAsync() { }

    #endregion

    #region ClientScopes

    [Fact]
    public async Task GetClientScopeAsync() { }

    [Fact]
    public async Task GetClientScopesAsync() { }

    [Fact]
    public async Task GetClientTemplateAsync() { }

    [Fact]
    public async Task GetClientTemplatesAsync() { }

    [Fact]
    public async Task CreateClientScopeAsync() { }

    [Fact]
    public async Task CreateClientTemplateAsync() { }

    [Fact]
    public async Task UpdateClientScopeAsync() { }

    [Fact]
    public async Task UpdateClientTemplateAsync() { }

    [Fact]
    public async Task DeleteClientScopeAsync() { }

    [Fact]
    public async Task DeleteClientTemplateAsync() { }

    #endregion

    #region Component

    [Fact]
    public async Task GetComponentAsync() { }

    [Fact]
    public async Task GetComponentsAsync() { }

    [Fact]
    public async Task GetSubComponentTypesAsync() { }

    [Fact]
    public async Task CreateComponentAsync() { }

    [Fact]
    public async Task UpdateComponentAsync() { }

    [Fact]
    public async Task DeleteComponentAsync() { }

    #endregion

    #region Groups

    [Fact]
    public async Task GetGroupAsync() { }

    [Fact]
    public async Task GetGroupManagementPermissionsAsync() { }

    [Fact]
    public async Task GetGroupsAsync() { }

    [Fact]
    public async Task GetGroupsCountAsync() { }

    [Fact]
    public async Task GetGroupUsersAsync() { }

    [Fact]
    public async Task CreateChildrenAsync() { }

    [Fact]
    public async Task CreateGroupAsync() { }

    [Fact]
    public async Task UpdateGroupByIdAsync() { }

    [Fact]
    public async Task UpdateGroupManagementPermissionsAsync() { }

    [Fact]
    public async Task DeleteGroupByIdAsync() { }

    #endregion

    #region IdentityProviders

    [Fact]
    public async Task ExportAsync() { }

    [Fact]
    public async Task GetIdentityProvidersByIdAsync() { }

    [Fact]
    public async Task GetIdentityProviderAsync() { }

    [Fact]
    public async Task GetManagementPermissionsAsync() { }

    [Fact]
    public async Task GetIdentityProvidersAsync() { }

    [Fact]
    public async Task GetIdentityProviderMappersByIdAsync() { }

    [Fact]
    public async Task GetIdentityProviderMapperTypesAsync() { }

    [Fact]
    public async Task GetIdentityProviderMappersAsync() { }

    [Fact]
    public async Task ImportIdentityProviderAsync() { }

    [Fact]
    public async Task CreateIdentityProviderAsync() { }

    [Fact]
    public async Task CreateMapperForIdentityProviderAsync() { }

    [Fact]
    public async Task UpdateIdentityProviderAsync() { }

    [Fact]
    public async Task UpdateManagementPermissionsAsync() { }

    [Fact]
    public async Task UpdateMapperForIdentityProviderAsync() { }

    [Fact]
    public async Task DeleteIdentityProviderAsync() { }

    [Fact]
    public async Task DeleteMapperForIdentityProviderAsync() { }

    #endregion

    #region ProtocolMappers

    [Fact]
    public async Task GetProtocolMapperAsync() { }

    [Fact]
    public async Task GetProtocolMappersAsync() { }

    [Fact]
    public async Task GetProtocolMappersByProtocolAsync() { }

    [Fact]
    public async Task GetClientScopeProtocolMapperAsync() { }

    [Fact]
    public async Task GetClientScopeProtocolMappersAsync() { }

    [Fact]
    public async Task GetClientScopeProtocolMappersByProtocolAsync() { }

    [Fact]
    public async Task GetClientTemplateProtocolMapperAsync() { }

    [Fact]
    public async Task GetClientTemplateProtocolMappersAsync() { }

    [Fact]
    public async Task GetClientTemplateProtocolMappersByProtocolAsync() { }

    [Fact]
    public async Task CreateClientProtocolMapperAsync() { }

    [Fact]
    public async Task CreateClientMultipleProtocolMappersAsync() { }

    [Fact]
    public async Task CreateClientScopeMultipleProtocolMappersAsync() { }

    [Fact]
    public async Task CreateClientScopeProtocolMapperAsync() { }

    [Fact]
    public async Task CreateClientTemplateProtocolMapperAsync() { }

    [Fact]
    public async Task CreateClientTemplateMultipleProtocolMappersAsync() { }

    [Fact]
    public async Task UpdateClientProtocolMapperAsync() { }

    [Fact]
    public async Task UpdateClientScopeProtocolMapperAsync() { }

    [Fact]
    public async Task UpdateClientTemplateProtocolMapperAsync() { }

    [Fact]
    public async Task DeleteClientProtocolMapperAsync() { }

    [Fact]
    public async Task DeleteClientScopeProtocolMapperAsync() { }

    [Fact]
    public async Task DeleteClientTemplateProtocolMapperAsync() { }

    #endregion
    
     #region RealmsAdmin

     [Fact]
     public async Task GetAccessibleRealmsAsync(){}

     [Fact]
     public async Task GetAdminEventsAsync(){}

     [Fact]
     public async Task GetRealmCurrentAsync(){}

     [Fact]
     public async Task GetRealmAsync(){}

     [Fact]
     public async Task GetClientSessionStatsAsync(){}

     [Fact]
     public async Task GetCredentialRegistratorsAsync(){}

     [Fact]
     public async Task GetDefaultDefaultClientScopesAsync(){}

     [Fact]
     public async Task GetDefaultGroupsAsync(){}

     [Fact]
     public async Task GetDefaultOptionalClientScopesAsync(){}

     [Fact]
     public async Task GetEventsAsync(){}

     [Fact]
     public async Task GetEventsConfigurationAsync(){}

     [Fact]
     public async Task GetGroupByPathAsync(){}

     [Fact]
     public async Task GetLocalizationAsync(){}

     [Fact]
     public async Task GetLocalizationByLocaleAsync(){}

     [Fact]
     public async Task GetLocalizationByLocaleByKeyAsync(){}

     [Fact]
     public async Task GetPoliciesAsync(){}

     [Fact]
     public async Task GetProfilesAsync(){}

     [Fact]
     public async Task GetUsersManagementPermissionsAsync(){}

     [Fact]
     public async Task ImportRealmAsync(){}

     [Fact]
     public async Task CreateClientDescriptionConverterAsync(){}

     [Fact]
     public async Task ImportLocalizationAsync(){}

     [Fact]
     public async Task LogoutAllAsync(){}

     [Fact]
     public async Task ExportPartialRealmAsync(){}

     [Fact]
     public async Task ImportPartialRealmAsync(){}

     [Fact]
     public async Task PushRevocationAsync(){}

     [Fact]
     public async Task TestSmtpConnectionAsync(){}

     [Fact]
     public async Task UpdateRealmByCurrentAsync(){}

     [Fact]
     public async Task UpdateRealmAsync(){}

     [Fact]
     public async Task UpdateDefaultClientScopeRealmAsync(){}

     [Fact]
     public async Task UpdateDefaultGroupAsync(){}

     [Fact]
     public async Task UpdateDefaultOptionalClientScopeAsync(){}

     [Fact]
     public async Task UpdateEventsConfigurationAsync(){}

     [Fact]
     public async Task UpdateLocalizationAsync(){}

     [Fact]
     public async Task UpdatePoliciesAsync(){}

     [Fact]
     public async Task UpdateProfilesAsync(){}

     [Fact]
     public async Task UpdateUsersManagementPermissionsAsync(){}

     [Fact]
     public async Task DeleteAdminEventsAsync(){}

     [Fact]
     public async Task DeleteRealmAsync(){}

     [Fact]
     public async Task DeleteDefaultClientScopeRealmAsync(){}

     [Fact]
     public async Task DeleteDefaultGroupAsync(){}

     [Fact]
     public async Task DeleteDefaultOptionalClientScopeAsync(){}

     [Fact]
     public async Task DeleteEventsAsync(){}

     [Fact]
     public async Task DeleteLocalizationByLocaleAsync(){}

     [Fact]
     public async Task DeleteLocalizationByLocaleByKeyAsync(){}

     [Fact]
     public async Task DeleteSessionAsync(){}

    #endregion

    private async Task<string> GetUserIdAsync()
    {
        var user = (await _keycloakClient.GetUsersAsync(username: "admin")).First();
        return user.Id!;
    }
}
