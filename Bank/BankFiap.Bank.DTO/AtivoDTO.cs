using System.Transactions;
using Bank.BankFiap.Bank.Entity;
using Bank.BankFiap.Bank.Entity.Enum;

namespace Bank.BankFiap.Bank.DTO
{
    public class AssetDTO : BaseEntity
    {
        public string Name { get; set; }
        public string Symbol { get; set; }  // Example: "AAPL", "BTC", "BOND"
        public AssetType Type { get; set; }
        public string Description { get; set; }
       // public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }


}
