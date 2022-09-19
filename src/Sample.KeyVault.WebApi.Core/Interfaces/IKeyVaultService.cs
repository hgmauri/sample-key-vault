namespace Sample.KeyVault.WebApi.Core.Interfaces;

public interface IKeyVaultService
{
    Task<string> GetSecretByKeyAsync(string keyName);
}