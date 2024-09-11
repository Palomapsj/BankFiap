using Microsoft.AspNetCore.Mvc;
using Bank.BankFiap.Bank.Repository;
using Bank.BankFiap.Bank.Interface;
using Microsoft.AspNetCore.Authorization;
using Bank.BankFiap.Bank.DTO;
using Bank.BankFiap.Bank.Entity;

namespace Bank.BankFiap.Bank.Controllers
{
    public class AssetsController : ControllerBase
    {
        private IAsset _assetRepository;
        private readonly ILogger<AssetsController> _logger;
        public AssetsController(IAsset assetRepository, ILogger<AssetsController> logger)
        {
            _assetRepository = assetRepository;
            _logger = logger;
        }

        [HttpGet("get-assets")]
        public IActionResult GetAssets()
        {
            try
            {
                _logger.LogInformation("Buscando ativos");
                return Ok(_assetRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter ativos no banco de dados");
                return StatusCode(500, "Erro interno ao tentar obter ativos");
            }
        }
    }
}
