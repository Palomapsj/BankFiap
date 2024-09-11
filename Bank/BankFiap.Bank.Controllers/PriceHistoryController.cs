using Microsoft.AspNetCore.Mvc;
using Bank.BankFiap.Bank.Repository;
using Bank.BankFiap.Bank.Interface;
using Microsoft.AspNetCore.Authorization;
using Bank.BankFiap.Bank.DTO;
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
    }
}
