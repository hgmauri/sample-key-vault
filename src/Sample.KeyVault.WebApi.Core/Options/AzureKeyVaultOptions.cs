namespace Sample.KeyVault.WebApi.Core.Options;
public class AzureKeyVaultOptions
{
    public string Endpoint { get; set; }
    public string TenantId { get; set; }
    public string ClientId { get; set; }
    public string ClientSecretId { get; set; }
}
