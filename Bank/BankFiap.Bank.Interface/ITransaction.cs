using Bank.BankFiap.Bank.Entity;

namespace Bank.BankFiap.Bank.Interface
{
    public interface ITransaction : IRepository<Transaction>
    {
        IList<Transaction> GetTransactionsByPortfolioId(int portfolioId);
    }
}
