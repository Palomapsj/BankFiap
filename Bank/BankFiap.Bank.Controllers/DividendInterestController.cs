using Microsoft.AspNetCore.Mvc;
using Bank.BankFiap.Bank.Repository;
using Bank.BankFiap.Bank.Interface;
using Microsoft.AspNetCore.Authorization;
using Bank.BankFiap.Bank.DTO;
using Bank.BankFiap.Bank.Entity;

namespace Bank.BankFiap.Bank.Controllers
{
    public class DividendInterestController : ControllerBase
    {
        private IDividendInterest _dividendInterestRepository;
        private readonly ILogger<DividendInterestController> _logger;
        public DividendInterestController(IDividendInterest dividendInterestRepository, ILogger<DividendInterestController> logger)
        {
            _dividendInterestRepository = dividendInterestRepository;
            _logger = logger;
        }

        [HttpPost("add-dividend-interest")]
        public IActionResult Add([FromBody] DividendInterestDTO dividendInterest)
        {
            try
            {
                _dividendInterestRepository.Add(new DividendInterest(dividendInterest));
                return Ok("Dividendo ou juro adicionado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar adicionar dividendo ou juro");
                return StatusCode(500, "Erro interno ao tentar adicionar dividendo ou juro");
            }
        }

        [HttpGet("get-dividends-interests-by-portfolio/{portfolioId}")]
        public IActionResult GetDividendsInterestsByPortfolioId(int portfolioId)
        {
            try
            {
                var dividendsInterests = _dividendInterestRepository.GetDividendsInterestsByPortfolioId(portfolioId);
                return Ok(dividendsInterests);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter dividendos e juros do portfólio");
                return StatusCode(500, "Erro interno ao tentar obter dividendos e juros do portfólio");
            }
        }

    }
}
