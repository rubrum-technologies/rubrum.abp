namespace Rubrum.Abp.Keycloak;

public class GlobalRequestResult
{
    public List<string>? SuccessRequests { get; set; }
    public List<string>? FailedRequests { get; set; }
}
