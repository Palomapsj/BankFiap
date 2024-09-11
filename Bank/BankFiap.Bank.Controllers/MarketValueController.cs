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
    }
}
