namespace Rubrum.Abp.Keycloak;

public class ClientInitialAccessPresentation
{
    public string? Id { get; set; }

    public string? Token { get; set; }

    public int? Timestamp { get; set; }

    public int? Expiration { get; set; }

    public int? Count { get; set; }

    public int? RemainingCount { get; set; }
}
