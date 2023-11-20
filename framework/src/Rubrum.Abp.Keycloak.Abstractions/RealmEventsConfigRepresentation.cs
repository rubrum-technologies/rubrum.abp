namespace Rubrum.Abp.Keycloak;

public class RealmEventsConfigRepresentation
{
    public bool? EventsEnabled { get; set; }
    public long? EventsExpiration { get; set; }
    public List<string>? EventsListeners { get; set; }
    public List<string>? EnabledEventTypes { get; set; }
    public bool? AdminEventsEnabled { get; set; }
    public bool? AdminEventsDetailsEnabled { get; set; }
}
