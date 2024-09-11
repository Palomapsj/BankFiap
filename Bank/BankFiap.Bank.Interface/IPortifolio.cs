using Bank.BankFiap.Bank.Entity;

namespace Bank.BankFiap.Bank.Interface
{
    public interface IPortfolio : IRepository<Portfolio>
    {
        IList<Portfolio> GetPortfoliosByUserId(int userId);
    }
}
