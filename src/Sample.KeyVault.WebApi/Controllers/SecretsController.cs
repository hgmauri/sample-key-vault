using Microsoft.AspNetCore.Mvc;
using Sample.KeyVault.WebApi.Core.Interfaces;

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

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string key)
    {
        var secret = await _keyVaultService.GetSecretByKeyAsync(key);

        return Ok(secret);
    }
}
