using Bank.BankFiap.Bank.Entity;

namespace Bank.BankFiap.Bank.Interface
{
    public interface IMarketValue : IRepository<MarketValue>
    {
        IList<MarketValue> GetMarketValueByAssetId(int assetId);
    }
}
