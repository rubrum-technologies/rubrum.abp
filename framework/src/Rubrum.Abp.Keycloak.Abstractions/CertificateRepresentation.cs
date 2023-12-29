namespace Rubrum.Abp.Keycloak;

public class CertificateRepresentation
{
    public string? PrivateKey { get; set; }

    public string? PublicKey { get; set; }

    public string? Certificate { get; set; }

    public string? Kid { get; set; }
}
