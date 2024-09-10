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
        private IPortifolio _portifolioRepository;
        private readonly ILogger<PortfoliosController> _logger;
        public PortfoliosController(IPortifolio portifolioRepository, ILogger<PortfoliosController> logger)
        {
            _portifolioRepository = portifolioRepository;
            _logger = logger;
        }

        [HttpPost("Register-Portifolio")]
        public IActionResult AddPortifolio(PortfolioDTO portfolioDTO)
        {
            try
            {
                _logger.LogInformation("Tentando cadastrar usuario");
                _portifolioRepository.Add(new Portfolio(portfolioDTO));
                _logger.LogInformation("Usuario cadastrado com sucesso");

                return Ok("Usuario cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar cadastrar usuário no banco de dados");
                return StatusCode(500, "Erro interno ao tentar cadastrar usuário");
            }
        }

        [HttpGet("Get-user-byId/{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                _logger.LogInformation("Buscando usuario");
                return Ok(_portifolioRepository.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter usuário no banco de dados");
                return StatusCode(500, "Erro interno ao tentar obter usuário");
            }
        }

        [HttpPost("UpdateUser")]
        public IActionResult UpdateUser(PortfolioDTO userDTO)
        {
            try
            {
                _logger.LogInformation("Tentando cadastrar usuario");
                _portifolioRepository.Update(new Portfolio(userDTO));
                _logger.LogInformation("Usuario cadastrado com sucesso");

                return Ok("Usuario cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar cadastrar usuário no banco de dados");
                return StatusCode(500, "Erro interno ao tentar cadastrar usuário");
            }
        }
    }
}
