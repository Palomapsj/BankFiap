using Microsoft.AspNetCore.Mvc;
using Bank.BankFiap.Bank.Repository;
using Bank.BankFiap.Bank.Interface;
using Microsoft.AspNetCore.Authorization;
using Bank.BankFiap.Bank.DTO;
using Bank.BankFiap.Bank.Entity;

namespace Bank.BankFiap.Bank.Controllers
{
    public class PortfoliosController : ControllerBase
    {
        private IPortfolio _portfolioRepository;
        private readonly ILogger<PortfoliosController> _logger;
        public PortfoliosController(IPortfolio portifolioRepository, ILogger<PortfoliosController> logger)
        {
            _portfolioRepository = portifolioRepository;
            _logger = logger;
        }

        [HttpPost("Register-Portifolio")]
        public IActionResult AddPortifolio(PortfolioDTO portifolioDTO)
        {
            try
            {
                _logger.LogInformation("Tentando cadastrar usuario");
                _portfolioRepository.Add(new Portfolio(portifolioDTO));
                _logger.LogInformation("Usuario cadastrado com sucesso");

                return Ok("Usuario cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar cadastrar usuário no banco de dados");
                return StatusCode(500, "Erro interno ao tentar cadastrar usuário");
            }
        }

        [HttpGet("Get-Portifolio-byId/{id}")]
        public IActionResult GetPortifolioById(int id)
        {
            try
            {
                _logger.LogInformation("Buscando portfolios");
                return Ok(_portfolioRepository.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter portfolios no banco de dados");
                return StatusCode(500, "Erro interno ao tentar obter portfolios");
            }
        }

        [HttpPost("UpdatePortfolios")]
        public IActionResult UpdatePortfolio(PortfolioDTO userDTO)
        {
            try
            {
                _logger.LogInformation("Tentando cadastrar um portfolios");
                _portfolioRepository.Update(new Portfolio(userDTO));
                _logger.LogInformation("Usuario cadastrado com sucesso");

                return Ok("Portfolios cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar cadastrar portfolios no banco de dados");
                return StatusCode(500, "Erro interno ao tentar cadastrar portfolios");
            }
        }
    }
}
