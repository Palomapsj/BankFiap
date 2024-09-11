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

        [HttpPost("add-portfolio")]
        public IActionResult Add([FromBody] Portfolio portfolio)
        {
            try
            {
                _portfolioRepository.Add(portfolio);
                return Ok("Portfólio adicionado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar adicionar portfólio");
                return StatusCode(500, "Erro interno ao tentar adicionar portfólio");
            }
        }

        [HttpGet("get-portfolio/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var portfolio = _portfolioRepository.GetById(id);
                if (portfolio == null)
                    return NotFound("Portfólio não encontrado");
                return Ok(portfolio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter portfólio");
                return StatusCode(500, "Erro interno ao tentar obter portfólio");
            }
        }

        [HttpGet("get-portfolios-by-user/{userId}")]
        public IActionResult GetPortfoliosByUserId(int userId)
        {
            try
            {
                var portfolios = _portfolioRepository.GetPortfoliosByUserId(userId);
                return Ok(portfolios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter portfólios do usuário");
                return StatusCode(500, "Erro interno ao tentar obter portfólios do usuário");
            }
        }

        [HttpPut("update-portfolio")]
        public IActionResult Update([FromBody] Portfolio portfolio)
        {
            try
            {
                _portfolioRepository.Update(portfolio);
                return Ok("Portfólio atualizado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar atualizar portfólio");
                return StatusCode(500, "Erro interno ao tentar atualizar portfólio");
            }
        }

        [HttpDelete("delete-portfolio/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _portfolioRepository.Delete(id);
                return Ok("Portfólio excluído com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar excluir portfólio");
                return StatusCode(500, "Erro interno ao tentar excluir portfólio");
            }
        }

    }
}
