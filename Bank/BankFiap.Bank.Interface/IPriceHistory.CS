using Bank.BankFiap.Bank.Entity;

namespace Bank.BankFiap.Bank.Interface
{
    public interface IPriceHistory : IRepository<PriceHistory>
    {
        IList<PriceHistory> GetPriceHistoryByAssetId(int assetId);
    }
}
