namespace Sample.KeyVault.WebApi.Core.Interfaces;

public interface ISecretsService
{
    Task<string> GetSecretsAsync(string key);

    Task<string> SetSecretAsync(string key, string value);

    Task<string> DeleteSecretAsync(string key);
}