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
    }
}
