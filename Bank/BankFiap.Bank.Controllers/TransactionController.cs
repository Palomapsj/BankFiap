using Microsoft.AspNetCore.Mvc;
using Bank.BankFiap.Bank.Repository;
using Bank.BankFiap.Bank.Interface;
using Microsoft.AspNetCore.Authorization;
using Bank.BankFiap.Bank.DTO;
using Bank.BankFiap.Bank.Entity;

namespace Bank.BankFiap.Bank.Controllers
{
    public class TransactionController : ControllerBase
    {
        private ITransaction _transactionRepository;
        private readonly ILogger<TransactionController> _logger;
        public TransactionController(ITransaction transactionRepository, ILogger<TransactionController> logger)
        {
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        [HttpPost("add-transaction")]
        public IActionResult Add([FromBody] TransactionDTO transaction)
        {
            try
            {
                _transactionRepository.Add(new Transaction(transaction));
                return Ok("Transação adicionada com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar adicionar transação");
                return StatusCode(500, "Erro interno ao tentar adicionar transação");
            }
        }

        [HttpGet("get-transactions-by-portfolio/{portfolioId}")]
        public IActionResult GetTransactionsByPortfolioId(int portfolioId)
        {
            try
            {
                var transactions = _transactionRepository.GetTransactionsByPortfolioId(portfolioId);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter transações do portfólio");
                return StatusCode(500, "Erro interno ao tentar obter transações do portfólio");
            }
        }

    }
}
