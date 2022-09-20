using Microsoft.AspNetCore.Mvc;
using Sample.KeyVault.WebApi.Core.Interfaces;
using Sample.KeyVault.WebApi.ViewModels;

namespace Sample.KeyVault.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SecretsController : ControllerBase
{
    private readonly ISecretsService _secretsService;
    private readonly IKeyVaultService _keyVaultService;

    public SecretsController(ISecretsService secretsService, IKeyVaultService keyVaultService)
    {
        _secretsService = secretsService;
        _keyVaultService = keyVaultService;
    }

    [HttpGet("configuration")]
    public async Task<IActionResult> GetSecretFromConfiguration([FromQuery] GetSecretsViewModel model)
    {
        var secret = await _keyVaultService.GetSecretByKeyAsync(model.Key);

        return Ok(secret);
    }

    [HttpGet("key-vault")]
    public async Task<IActionResult> GetSecretFromAzure([FromQuery] GetSecretsViewModel model)
    {
        var secret = await _secretsService.GetSecretsAsync(model.Key);

        return Ok(secret);
    }

    [HttpPost]
    public async Task<IActionResult> PostSecret([FromBody] SaveSecretsViewModel model)
    {
        var secret = await _secretsService.SetSecretAsync(model.Key, model.Value);

        return Ok(secret);
    }
}
