using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.KeyVault.WebApi.Core.Interfaces;
using Sample.KeyVault.WebApi.Core.Options;
using Sample.KeyVault.WebApi.Core.Services;

namespace Sample.KeyVault.WebApi.Core.Extensions;
public static class KeyVaultExtensions
{
    public static WebApplicationBuilder AddKeyVault(this WebApplicationBuilder builder)
    {
        if (builder.Host == null)
            throw new ArgumentNullException(nameof(builder.Host));

        var optionsConfig = new AzureKeyVaultOptions();
        builder.Configuration.GetSection(nameof(AzureKeyVaultOptions)).Bind(optionsConfig);

        builder.Services.AddScoped<ISecretsService, SecretsService>();
        builder.Services.AddScoped<IKeyVaultService, KeyVaultService>();

        var credential = new ClientSecretCredential(optionsConfig.TenantId, optionsConfig.ClientId, optionsConfig.ClientSecretId);

        builder.Services.AddSingleton(_ => new SecretClient(vaultUri: new Uri(optionsConfig.Endpoint), credential: credential));

        builder.Host.ConfigureAppConfiguration((context, config) =>
        {
            config.AddAzureKeyVault(new Uri(optionsConfig.Endpoint), credential);
        });

        return builder;
    }
}