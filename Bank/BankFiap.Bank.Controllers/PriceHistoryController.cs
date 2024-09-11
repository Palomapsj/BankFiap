using Microsoft.AspNetCore.Mvc;
using Bank.BankFiap.Bank.Interface;
using Bank.BankFiap.Bank.Entity;

namespace Bank.BankFiap.Bank.Controllers
{
    public class PriceHistoryController : ControllerBase
    {
        private IPriceHistory _priceHistoryRepository;
        private readonly ILogger<PriceHistoryController> _logger;
        public PriceHistoryController(IPriceHistory priceHistoryRepository, ILogger<PriceHistoryController> logger)
        {
            _priceHistoryRepository = priceHistoryRepository;
            _logger = logger;
        }

        [HttpPost("add-price-history")]
        public IActionResult Add([FromBody] PriceHistory priceHistory)
        {
            try
            {
                _priceHistoryRepository.Add(priceHistory);
                return Ok("Histórico de preços adicionado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar adicionar histórico de preços");
                return StatusCode(500, "Erro interno ao tentar adicionar histórico de preços");
            }
        }

        [HttpGet("get-price-history-by-asset/{assetId}")]
        public IActionResult GetPriceHistoryByAssetId(int assetId)
        {
            try
            {
                var priceHistories = _priceHistoryRepository.GetPriceHistoryByAssetId(assetId);
                return Ok(priceHistories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter histórico de preços por ativo");
                return StatusCode(500, "Erro interno ao tentar obter histórico de preços por ativo");
            }
        }

    }
}
