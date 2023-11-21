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
        var result = await _keycloakClient.GetAuthenticatorProvidersAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetAuthenticatorProvidersAsync()
    {
        var result = await _keycloakClient.GetAuthenticatorProvidersAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetClientAuthenticatorProvidersAsync()
    {
        var result = await _keycloakClient.GetClientAuthenticatorProvidersAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetAuthenticatorProvidersConfigurationAsync()
    {
    }

    [Fact]
    public async Task GetAuthenticationExecutionAsync()
    {
    }

    [Fact]
    public async Task GetAuthenticationExecutionConfigurationAsync()
    {
    }

    [Fact]
    public async Task GetAuthenticationExecutionsForFlowAsync()
    {
    }

    [Fact]
    public async Task GetAuthenticationFlowForIdAsync()
    {
    }

    [Fact]
    public async Task GetAuthenticationFlowsAsync()
    {
        var result = await _keycloakClient.GetAuthenticationFlowsAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetFormActionProvidersAsync()
    {
        var result = await _keycloakClient.GetFormActionProvidersAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetFormProvidersAsync()
    {
        var result = await _keycloakClient.GetFormProvidersAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetConfigurationForAllClientsAsync()
    {
        var result = await _keycloakClient.GetConfigurationForAllClientsAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetRequiredActionForAliasAsync()
    {
    }

    [Fact]
    public async Task GetRequiredActionsAsync()
    {
        var result = await _keycloakClient.GetRequiredActionsAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetUnregisteredRequiredActionsAsync()
    {
        var result = await _keycloakClient.GetUnregisteredRequiredActionsAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task CreateAuthenticatorConfigurationAsync()
    {
    }

    [Fact]
    public async Task CopyExistingAuthenticationFlowAsync()
    {
    }

    [Fact]
    public async Task CreateAuthenticationExecutionToFlowAsync()
    {
    }

    [Fact]
    public async Task UpdateExecutionWithConfigurationAsync()
    {
    }

    [Fact]
    public async Task ExecutionLowerPriorityAsync()
    {
    }

    [Fact]
    public async Task ExecutionRaisePriorityAsync()
    {
    }

    [Fact]
    public async Task CreateAuthenticationExecutionAsync()
    {
    }

    [Fact]
    public async Task CreateFlowWithNewExecutionAsync()
    {
    }

    [Fact]
    public async Task CreateAuthenticationFlowAsync()
    {
    }

    [Fact]
    public async Task RegisterRequiredActionAsync()
    {
    }

    [Fact]
    public async Task RequiredActionLowerPriorityAsync()
    {
    }

    [Fact]
    public async Task RequiredActionRaisePriorityAsync()
    {
    }

    [Fact]
    public async Task UpdateAuthenticationConfigurationAsync()
    {
    }

    [Fact]
    public async Task UpdateAuthenticationExecutionsOfFlowAsync()
    {
    }

    [Fact]
    public async Task UpdateAuthenticationFlowAsync()
    {
    }

    [Fact]
    public async Task UpdateRequiredActionAsync()
    {
    }

    [Fact]
    public async Task DeleteAuthenticatorConfigurationAsync()
    {
    }

    [Fact]
    public async Task DeleteExecutionAsync()
    {
    }

    [Fact]
    public async Task DeleteAuthenticationFlowAsync()
    {
    }

    [Fact]
    public async Task DeleteRequiredActionAsync()
    {
    }

    #endregion

    #region ClientAttributeCertificate

    [Fact]
    public async Task GetCertificateAsync()
    {
    }

    [Fact]
    public async Task GetKeystoreFileForClientAsync()
    {
    }

    [Fact]
    public async Task GenerateCertificateAsync()
    {
    }

    [Fact]
    public async Task GenerateKeypairAndCertificateAsync()
    {
    }

    [Fact]
    public async Task UploadCertificateAndPrivateKeyAsync()
    {
    }

    [Fact]
    public async Task UploadOnlyCertificateAsync()
    {
    }

    #endregion

    #region ClientInitialAccess

    [Fact]
    public async Task GetClientInitialAccessAsync()
    {
        var result = await _keycloakClient.GetClientInitialAccessAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task CreateInitialAccessTokenAsync()
    {
    }

    [Fact]
    public async Task DeleteInitialAccessTokenAsync()
    {
    }

    #endregion

    #region ClientRoleMappings

    [Fact]
    public async Task GetGroupRoleMappingsClientAsync()
    {
    }

    [Fact]
    public async Task GetGroupRoleMappingsClientAvailableAsync()
    {
    }

    [Fact]
    public async Task GetGroupRoleMappingsClientCompositeAsync()
    {
    }

    [Fact]
    public async Task GetUserRoleMappingsClientAsync()
    {
    }

    [Fact]
    public async Task GetUserRoleMappingsClientAvailableAsync()
    {
    }

    [Fact]
    public async Task GetUserRoleMappingsClientCompositeAsync()
    {
    }

    [Fact]
    public async Task ChangeGroupRoleMappingsClientAsync()
    {
    }

    [Fact]
    public async Task ChangeUserRoleMappingsClientAsync()
    {
    }

    [Fact]
    public async Task DeleteGroupRoleMappingsClientAsync()
    {
    }

    [Fact]
    public async Task DeleteUserRoleMappingsClientAsync()
    {
    }

    #endregion

    #region Clients

    [Fact]
    public async Task GetClientByIdAsync()
    {
        var client = await GetClientRepresentationAsync();
        var result = await _keycloakClient.GetClientByIdAsync(client.ClientId!);
        result.ShouldNotBeNull();
        result.Id.ShouldBe(client.Id);
    }

    [Fact]
    public async Task GetClientManagementPermissionsAsync()
    {
    }

    [Fact]
    public async Task GetClientSecretAsync()
    {
    }

    [Fact]
    public async Task GetClientUserSessionsAsync()
    {
    }

    [Fact]
    public async Task GetClientsAsync()
    {
        var client = await GetClientRepresentationAsync();
        var result = await _keycloakClient.GetClientsAsync();
        result.ShouldNotBeNull();
        result.Count.ShouldBeGreaterThan(1);        
        result.FirstOrDefault(x => x.ClientId == client.ClientId)?.ClientId.ShouldBe(client.ClientId);
    }

    [Fact]
    public async Task GetDefaultClientScopesAsync()
    {
    }

    [Fact]
    public async Task GetGenerateExampleAccessTokenAsync()
    {
    }

    [Fact]
    public async Task GetGenerateExampleIdTokenAsync()
    {
    }

    [Fact]
    public async Task GetGenerateExampleUserinfoAsync()
    {
    }

    [Fact]
    public async Task GetGrantedAsync()
    {
    }

    [Fact]
    public async Task GetNotGrantedAsync()
    {
    }

    [Fact]
    public async Task GetOfflineSessionCountAsync()
    {
    }

    [Fact]
    public async Task GetOfflineSessionsAsync()
    {
    }

    [Fact]
    public async Task GetOptionalClientScopesAsync()
    {
    }

    [Fact]
    public async Task GetProtocolMappersInTokenGenerationAsync()
    {
    }

    [Fact]
    public async Task GetRotatedClientSecretAsync()
    {
    }

    [Fact]
    public async Task GetServiceAccountUserAsync()
    {
    }

    [Fact]
    public async Task GetSessionCountAsync()
    {
    }

    [Fact]
    public async Task GetTestNodesAvailableAsync()
    {
    }

    [Fact]
    public async Task ClientPushRevocationAsync()
    {
    }

    [Fact]
    public async Task GenerateClientSecretAsync()
    {
    }

    [Fact]
    public async Task CreateClientAsync()
    {
        var client =  new ClientRepresentation
        {
            ClientId = Guid.NewGuid().ToString()
        };
        
        await _keycloakClient.CreateClientAsync(client);
    }

    [Fact]
    public async Task RegisterClusterNodeWithClientAsync()
    {
    }

    [Fact]
    public async Task GenerateRegistrationAccessTokenAsync()
    {
    }

    [Fact]
    public async Task UpdateClientAsync()
    {
        var client = await GetClientRepresentationAsync();
        client.Name = Guid.NewGuid().ToString();
        await _keycloakClient.UpdateClientAsync(client.ClientId!, client);
        var result = await _keycloakClient.GetClientByIdAsync(client.ClientId!);
        result.ShouldNotBeNull();
        result.Name.ShouldBe(client.Name);
    }

    [Fact]
    public async Task UpdateClientManagementPermissionsAsync()
    {
    }

    [Fact]
    public async Task UpdateDefaultClientScopeAsync()
    {
    }

    [Fact]
    public async Task UpdateOptionalClientScopeAsync()
    {
    }

    [Fact]
    public async Task DeleteClientByIdAsync()
    {
        var client = await GetClientRepresentationAsync();
        await _keycloakClient.DeleteClientByIdAsync(client.ClientId!);
    }

    [Fact]
    public async Task DeleteDefaultClientScopeAsync()
    {
    }

    [Fact]
    public async Task UnregisterClusterNodeFromClient()
    {
    }

    [Fact]
    public async Task DeleteOptionalClientScopeAsync()
    {
    }

    [Fact]
    public async Task DeleteRotatedAsync()
    {
    }

    #endregion

    #region ClientScopes

    [Fact]
    public async Task GetClientScopeAsync()
    {
    }

    [Fact]
    public async Task GetClientScopesAsync()
    {
        var result = await _keycloakClient.GetClientScopesAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetClientTemplateAsync()
    {
    }

    [Fact]
    public async Task GetClientTemplatesAsync()
    {
        var result = await _keycloakClient.GetClientTemplatesAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task CreateClientScopeAsync()
    {
    }

    [Fact]
    public async Task CreateClientTemplateAsync()
    {
    }

    [Fact]
    public async Task UpdateClientScopeAsync()
    {
    }

    [Fact]
    public async Task UpdateClientTemplateAsync()
    {
    }

    [Fact]
    public async Task DeleteClientScopeAsync()
    {
    }

    [Fact]
    public async Task DeleteClientTemplateAsync()
    {
    }

    #endregion

    #region Component

    [Fact]
    public async Task GetComponentAsync()
    {
        var component = await GetComponentRepresentationAsync();
        var result = await _keycloakClient.GetComponentAsync(component.Name!);
        result.ShouldNotBeNull();
        result.Name.ShouldBe(component.Name!);
    }

    [Fact]
    public async Task GetComponentsAsync()
    {
        var component = await GetComponentRepresentationAsync();
        var result = await _keycloakClient.GetComponentsAsync();
        result.ShouldNotBeNull();
        result.Count.ShouldBeGreaterThan(1);        
        result.FirstOrDefault(x => x.Name == component.Name)?.Name.ShouldBe(component.Name);
    }

    [Fact]
    public async Task GetSubComponentTypesAsync()
    {
    }

    [Fact]
    public async Task CreateComponentAsync()
    {
        var component =  new ComponentRepresentation
        {
            Name = Guid.NewGuid().ToString()
        };
        
        await _keycloakClient.CreateComponentAsync(component);
    }

    [Fact]
    public async Task UpdateComponentAsync()
    {
        var component = await GetComponentRepresentationAsync();
        component.ProviderType = Guid.NewGuid().ToString();
        await _keycloakClient.UpdateComponentAsync(component.Name!, component);
        var result = await _keycloakClient.GetComponentAsync(component.Name!);
        result.ShouldNotBeNull();
        result.ProviderType.ShouldBe(component.ProviderType);
    }

    [Fact]
    public async Task DeleteComponentAsync()
    {
        var component = await GetComponentRepresentationAsync();
        await _keycloakClient.DeleteComponentAsync(component.Name!);
    }

    #endregion

    #region Groups

    [Fact]
    public async Task GetGroupAsync()
    {
        var group = await GetGroupRepresentationAsync();
        var result = await _keycloakClient.GetGroupAsync(group.Id!);
        result.ShouldNotBeNull();
        result.Name.ShouldBe(group.Name!);
    }

    [Fact]
    public async Task GetGroupManagementPermissionsAsync()
    {
    }

    [Fact]
    public async Task GetGroupsAsync()
    {
        var group = await GetGroupRepresentationAsync();
        var result = await _keycloakClient.GetGroupsAsync();
        result.ShouldNotBeNull();
        result.Count.ShouldBeGreaterThanOrEqualTo(1);        
        result.FirstOrDefault(x => x.Name == group.Name)?.Name.ShouldBe(group.Name);
    }

    [Fact]
    public async Task GetGroupsCountAsync()
    {
        await GetGroupRepresentationAsync();
        var result = await _keycloakClient.GetGroupsCountAsync();
        result.ShouldNotBeNull();
        result.Count.ShouldBeGreaterThanOrEqualTo(1);     
    }

    [Fact]
    public async Task GetGroupUsersAsync()
    {
    }

    [Fact]
    public async Task CreateChildrenAsync()
    {
    }

    [Fact]
    public async Task CreateGroupAsync()
    {
        var group =  new GroupRepresentation
        {
            Name = Guid.NewGuid().ToString()
        };
        
        await _keycloakClient.CreateGroupAsync(group);
    }

    [Fact]
    public async Task UpdateGroupByIdAsync()
    {
        var group = await GetGroupRepresentationAsync();
        group.RealmRoles = new List<string>
        {
            Guid.NewGuid().ToString()
        };
        await _keycloakClient.UpdateGroupByIdAsync(group.Id!, group);
        var result = await _keycloakClient.GetGroupAsync(group.Id!);
        result.ShouldNotBeNull();
        result.RealmRoles?.Count.ShouldBe(group.RealmRoles.Count);
    }

    [Fact]
    public async Task UpdateGroupManagementPermissionsAsync()
    {
    }

    [Fact]
    public async Task DeleteGroupByIdAsync()
    {
        var group = await GetGroupRepresentationAsync();
        await _keycloakClient.DeleteGroupByIdAsync(group.Id!);
    }

    #endregion

    #region IdentityProviders

    [Fact]
    public async Task ExportAsync()
    {
    }

    [Fact]
    public async Task GetIdentityProvidersByIdAsync()
    {
        // ToDo: GetIdentityProvidersByIdAsync not found
    }

    [Fact]
    public async Task GetIdentityProviderAsync()
    {
        var identityProvider = await GetIdentityProviderRepresentationAsync();
        var result = await _keycloakClient.GetIdentityProviderAsync(identityProvider.Alias!);
        result.ShouldNotBeNull();
        result.DisplayName.ShouldBe(identityProvider.DisplayName);
    }

    [Fact]
    public async Task GetManagementPermissionsAsync()
    {
    }

    [Fact]
    public async Task GetIdentityProvidersAsync()
    {
        await GetIdentityProviderRepresentationAsync();
        var result = await _keycloakClient.GetIdentityProvidersAsync();
        result.ShouldNotBeNull();
        result.Count.ShouldBeGreaterThan(1);
    }

    [Fact]
    public async Task GetIdentityProviderMappersByIdAsync()
    {
        // ToDo: GetIdentityProviderMappersByIdAsync not found
    }

    [Fact]
    public async Task GetIdentityProviderMapperTypesAsync()
    {
    }

    [Fact]
    public async Task GetIdentityProviderMappersAsync()
    {
    }

    [Fact]
    public async Task ImportIdentityProviderAsync()
    {
    }

    [Fact]
    public async Task CreateIdentityProviderAsync()
    {
        var identityProvider =  new IdentityProviderRepresentation
        {
            Alias = Guid.NewGuid().ToString(),
            DisplayName = Guid.NewGuid().ToString()
        };
        
        await _keycloakClient.CreateIdentityProviderAsync(identityProvider);
    }

    [Fact]
    public async Task CreateMapperForIdentityProviderAsync()
    {
    }

    [Fact]
    public async Task UpdateIdentityProviderAsync()
    {
        var identityProvider = await GetIdentityProviderRepresentationAsync();
        identityProvider.ProviderId = Guid.NewGuid().ToString();
        await _keycloakClient.UpdateIdentityProviderAsync(identityProvider.Alias!, identityProvider);
        var result = await _keycloakClient.GetIdentityProviderAsync(identityProvider.Alias!);
        result.ShouldNotBeNull();
        result.ProviderId.ShouldBe(identityProvider.ProviderId);
    }

    [Fact]
    public async Task UpdateManagementPermissionsAsync()
    {
    }

    [Fact]
    public async Task UpdateMapperForIdentityProviderAsync()
    {
    }

    [Fact]
    public async Task DeleteIdentityProviderAsync()
    {
        var identityProvider = await GetIdentityProviderRepresentationAsync();
        await _keycloakClient.DeleteIdentityProviderAsync(identityProvider.Alias!);
    }

    [Fact]
    public async Task DeleteMapperForIdentityProviderAsync()
    {
    }

    #endregion

    #region ProtocolMappers

    [Fact]
    public async Task GetProtocolMapperAsync()
    {
    }

    [Fact]
    public async Task GetProtocolMappersAsync()
    {
    }

    [Fact]
    public async Task GetProtocolMappersByProtocolAsync()
    {
        // ToDo: GetProtocolMappersByProtocolAsync not found
    }

    [Fact]
    public async Task GetClientScopeProtocolMapperAsync()
    {
    }

    [Fact]
    public async Task GetClientScopeProtocolMappersAsync()
    {
    }

    [Fact]
    public async Task GetClientScopeProtocolMappersByProtocolAsync()
    {
        // ToDo: GetClientScopeProtocolMappersByProtocolAsync not found
    }

    [Fact]
    public async Task GetClientTemplateProtocolMapperAsync()
    {
    }

    [Fact]
    public async Task GetClientTemplateProtocolMappersAsync()
    {
    }

    [Fact]
    public async Task GetClientTemplateProtocolMappersByProtocolAsync()
    {
        // ToDo: GetClientTemplateProtocolMappersByProtocolAsync not found
    }

    [Fact]
    public async Task CreateClientProtocolMapperAsync()
    {
    }

    [Fact]
    public async Task CreateClientMultipleProtocolMappersAsync()
    {
    }

    [Fact]
    public async Task CreateClientScopeMultipleProtocolMappersAsync()
    {
    }

    [Fact]
    public async Task CreateClientScopeProtocolMapperAsync()
    {
    }

    [Fact]
    public async Task CreateClientTemplateProtocolMapperAsync()
    {
    }

    [Fact]
    public async Task CreateClientTemplateMultipleProtocolMappersAsync()
    {
    }

    [Fact]
    public async Task UpdateClientProtocolMapperAsync()
    {
    }

    [Fact]
    public async Task UpdateClientScopeProtocolMapperAsync()
    {
    }

    [Fact]
    public async Task UpdateClientTemplateProtocolMapperAsync()
    {
    }

    [Fact]
    public async Task DeleteClientProtocolMapperAsync()
    {
    }

    [Fact]
    public async Task DeleteClientScopeProtocolMapperAsync()
    {
    }

    [Fact]
    public async Task DeleteClientTemplateProtocolMapperAsync()
    {
    }

    #endregion

    #region RealmsAdmin

    [Fact]
    public async Task GetAccessibleRealmsAsync()
    {
        var result = await _keycloakClient.GetAccessibleRealmsAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetAdminEventsAsync()
    {
        var result = await _keycloakClient.GetAdminEventsAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetRealmCurrentAsync()
    {
        // ToDo: GetRealmCurrentAsync not found
    }

    [Fact]
    public async Task GetRealmAsync()
    {
        var result = await _keycloakClient.GetRealmAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetClientSessionStatsAsync()
    {
    }

    [Fact]
    public async Task GetCredentialRegistratorsAsync()
    {
        var result = await _keycloakClient.GetCredentialRegistratorsAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetDefaultDefaultClientScopesAsync()
    {
        var result = await _keycloakClient.GetDefaultDefaultClientScopesAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetDefaultGroupsAsync()
    {
        var result = await _keycloakClient.GetDefaultGroupsAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetDefaultOptionalClientScopesAsync()
    {
        var result = await _keycloakClient.GetDefaultOptionalClientScopesAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetEventsAsync()
    {
        var result = await _keycloakClient.GetEventsAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetEventsConfigurationAsync()
    {
        var result = await _keycloakClient.GetEventsConfigurationAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetGroupByPathAsync()
    {
        var group = await GetGroupRepresentationAsync();
        var result = await _keycloakClient.GetGroupByPathAsync(group.Path!);
        result.ShouldNotBeNull();
        result.Id.ShouldBe(group.Id);
    }

    [Fact]
    public async Task GetLocalizationAsync()
    {
        var result = await _keycloakClient.GetLocalizationAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetLocalizationByLocaleAsync()
    {
    }

    [Fact]
    public async Task GetLocalizationByLocaleByKeyAsync()
    {
    }

    [Fact]
    public async Task GetPoliciesAsync()
    {
        var result = await _keycloakClient.GetPoliciesAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetProfilesAsync()
    {
        var result = await _keycloakClient.GetProfilesAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task GetUsersManagementPermissionsAsync()
    {
        var result = await _keycloakClient.GetUsersManagementPermissionsAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task ImportRealmAsync()
    {
    }

    [Fact]
    public async Task CreateClientDescriptionConverterAsync()
    {
    }

    [Fact]
    public async Task ImportLocalizationAsync()
    {
    }

    [Fact]
    public async Task LogoutAllAsync()
    {
        var result = await _keycloakClient.LogoutAllAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task ExportPartialRealmAsync()
    {
    }

    [Fact]
    public async Task ImportPartialRealmAsync()
    {
    }

    [Fact]
    public async Task PushRevocationAsync()
    {
        var result = await _keycloakClient.PushRevocationAsync();
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task TestSmtpConnectionAsync()
    {
    }

    [Fact]
    public async Task UpdateRealmByCurrentAsync()
    {
        // ToDo: UpdateRealmByCurrentAsync not found
    }

    [Fact]
    public async Task UpdateRealmAsync()
    {
    }

    [Fact]
    public async Task UpdateDefaultClientScopeRealmAsync()
    {
        // ToDo: UpdateDefaultClientScopeRealmAsync not found
    }

    [Fact]
    public async Task UpdateDefaultGroupAsync()
    {
    }

    [Fact]
    public async Task UpdateDefaultOptionalClientScopeAsync()
    {
    }

    [Fact]
    public async Task UpdateEventsConfigurationAsync()
    {
    }

    [Fact]
    public async Task UpdateLocalizationAsync()
    {
    }

    [Fact]
    public async Task UpdatePoliciesAsync()
    {
    }

    [Fact]
    public async Task UpdateProfilesAsync()
    {
    }

    [Fact]
    public async Task UpdateUsersManagementPermissionsAsync()
    {
    }

    [Fact]
    public async Task DeleteAdminEventsAsync()
    {
    }

    [Fact]
    public async Task DeleteRealmAsync()
    {
    }

    [Fact]
    public async Task DeleteDefaultClientScopeRealmAsync()
    {
        // ToDo: DeleteDefaultClientScopeRealmAsync not found
    }

    [Fact]
    public async Task DeleteDefaultGroupAsync()
    {
    }

    [Fact]
    public async Task DeleteDefaultOptionalClientScopeAsync()
    {
    }

    [Fact]
    public async Task DeleteEventsAsync()
    {
    }

    [Fact]
    public async Task DeleteLocalizationByLocaleAsync()
    {
    }

    [Fact]
    public async Task DeleteLocalizationByLocaleByKeyAsync()
    {
    }

    [Fact]
    public async Task DeleteSessionAsync()
    {
    }

    #endregion

    private async Task<string> GetUserIdAsync()
    {
        var user = (await _keycloakClient.GetUsersAsync(username: "admin")).First();
        return user.Id!;
    }

    private async Task<ClientRepresentation> GetClientRepresentationAsync()
    {
        var client =  new ClientRepresentation
        {
            ClientId = Guid.NewGuid().ToString()
        };
        
        await _keycloakClient.CreateClientAsync(client);
        return await _keycloakClient.GetClientByIdAsync(client.ClientId);
    }
    
    private async Task<ComponentRepresentation> GetComponentRepresentationAsync()
    {
        var component =  new ComponentRepresentation
        {
            Name = Guid.NewGuid().ToString()
        };
        
        await _keycloakClient.CreateComponentAsync(component);
        return await _keycloakClient.GetComponentAsync(component.Name);
    }
    
    private async Task<GroupRepresentation> GetGroupRepresentationAsync()
    {
        var group =  new GroupRepresentation
        {
            Name = Guid.NewGuid().ToString(),
            Path = Guid.NewGuid().ToString()
        };
        
        await _keycloakClient.CreateGroupAsync(group);
        return (await _keycloakClient.GetGroupsAsync()).Where(x => x.Name == group.Name).First();
    }
    
    private async Task<IdentityProviderRepresentation> GetIdentityProviderRepresentationAsync()
    {
        var identityProvider =  new IdentityProviderRepresentation
        {
            Alias = Guid.NewGuid().ToString(),
            DisplayName = Guid.NewGuid().ToString()
        };
        
        await _keycloakClient.CreateIdentityProviderAsync(identityProvider);
        return await _keycloakClient.GetIdentityProviderAsync(identityProvider.Alias);
    }
}
