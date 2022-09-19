using Microsoft.Extensions.Configuration;
using Sample.KeyVault.WebApi.Core.Interfaces;

namespace Sample.KeyVault.WebApi.Core.Services;

public class KeyVaultService: IKeyVaultService
{
    private readonly IConfiguration _configuration;

    public KeyVaultService(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public Task<string> GetSecretByKeyAsync(string keyName)
    {
        return Task.FromResult(_configuration[keyName]);
    }
}