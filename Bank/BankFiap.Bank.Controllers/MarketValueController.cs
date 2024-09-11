using Microsoft.AspNetCore.Mvc;
using Bank.BankFiap.Bank.Repository;
using Bank.BankFiap.Bank.Interface;
using Microsoft.AspNetCore.Authorization;
using Bank.BankFiap.Bank.DTO;
using Bank.BankFiap.Bank.Entity;

namespace Bank.BankFiap.Bank.Controllers
{
    public class MarketValueController : ControllerBase
    {
        private IMarketValue _marketValueRepository;
        private readonly ILogger<MarketValueController> _logger;
        public MarketValueController(IMarketValue marketValueRepository, ILogger<MarketValueController> logger)
        {
            _marketValueRepository = marketValueRepository;
            _logger = logger;
        }

        [HttpPost("add-market-value")]
        public IActionResult AddMarketValue([FromBody] MarketValueDTO marketValue)
        {
            try
            {
                _marketValueRepository.Add(new MarketValue(marketValue));
                return Ok("Valor de mercado adicionado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar adicionar valor de mercado");
                return StatusCode(500, "Erro interno ao tentar adicionar valor de mercado");
            }
        }

        [HttpGet("get-market-value-by-asset/{assetId}")]
        public IActionResult GetMarketValueByAssetId(int assetId)
        {
            try
            {
                var marketValues = _marketValueRepository.GetMarketValueByAssetId(assetId);
                return Ok(marketValues);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter valor de mercado por ativo");
                return StatusCode(500, "Erro interno ao tentar obter valor de mercado por ativo");
            }
        }

    }
}
