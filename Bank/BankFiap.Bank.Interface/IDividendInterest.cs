using Bank.BankFiap.Bank.Entity;

namespace Bank.BankFiap.Bank.Interface
{
    public interface IDividendInterest : IRepository<DividendInterest>
    {
        IList<DividendInterest> GetDividendsInterestsByPortfolioId(int portfolioId);
    }
}
