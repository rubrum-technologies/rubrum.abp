using System.Text.Json.Serialization;

namespace Rubrum.Abp.Keycloak;

public class IdToken
{
    public string? Jti { get; set; }

    public long? Exp { get; set; }

    public long? Nbf { get; set; }

    public long? Iat { get; set; }

    public string? Iss { get; set; }

    public string? Sub { get; set; }

    public string? Typ { get; set; }

    public string? Azp { get; set; }

    public Dictionary<string, object>? OtherClaims { get; set; }

    public string? Nonce { get; set; }

    [JsonPropertyName("auth_time")]
    public long? AuthTime { get; set; }

    [JsonPropertyName("session_state")]
    public string? SessionState { get; set; }

    [JsonPropertyName("at_hash")]
    public string? AtHash { get; set; }

    [JsonPropertyName("c_hash")]
    public string? CHash { get; set; }

    public string? Name { get; set; }

    [JsonPropertyName("given_name")]
    public string? GivenName { get; set; }

    [JsonPropertyName("family_name")]
    public string? FamilyName { get; set; }

    [JsonPropertyName("middle_name")]
    public string? MiddleName { get; set; }

    public string? Nickname { get; set; }

    [JsonPropertyName("preferred_username")]
    public string? PreferredUsername { get; set; }

    public string? Profile { get; set; }

    public string? Picture { get; set; }

    public string? Website { get; set; }

    public string? Email { get; set; }

    [JsonPropertyName("email_verified")]
    public bool? EmailVerified { get; set; }

    public string? Gender { get; set; }

    public string? Birthdate { get; set; }

    public string? Zoneinfo { get; set; }

    public string? Locale { get; set; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("phone_number_verified")]
    public bool? PhoneNumberVerified { get; set; }

    public AddressClaimSet? Address { get; set; }

    [JsonPropertyName("updated_at")]
    public long? UpdatedAt { get; set; }

    [JsonPropertyName("claims_locales")]
    public string? ClaimsLocales { get; set; }

    public string? Acr { get; set; }

    [JsonPropertyName("s_hash")]
    public string? SHash { get; set; }

    public string? Sid { get; set; }
}
