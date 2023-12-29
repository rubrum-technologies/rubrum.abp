namespace Rubrum.Abp.Keycloak;

public class AdminUserNotProvidedException : Exception
{
    public AdminUserNotProvidedException()
        : base("Keycloak admin user is not provided, check if KEYCLOAK_ADMIN environment variable is passed properly.")
    {
    }
}
