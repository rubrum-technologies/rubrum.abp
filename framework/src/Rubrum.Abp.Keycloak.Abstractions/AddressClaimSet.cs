using System.Text.Json.Serialization;

namespace Rubrum.Abp.Keycloak;

public class AddressClaimSet
{
    public string? Formatted { get; set; }

    [JsonPropertyName("street_address")]
    public string? StreetAddress { get; set; }

    public string? Locality { get; set; }
    public string? Region { get; set; }

    [JsonPropertyName("postal_code")]
    public string? PostalCode { get; set; }

    public string? Country { get; set; }
}
