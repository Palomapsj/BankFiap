using Bank.BankFiap.Bank.DTO;
using Bank.BankFiap.Bank.Entity.Enum;
using System.Transactions;

namespace Bank.BankFiap.Bank.Entity
{
    public class Asset : BaseEntity
    {
        public string Name { get; set; }
        public string Symbol { get; set; }  // Example: "AAPL", "BTC", "BOND"
        public AssetType Type { get; set; }
        public string Description { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();



        public Asset(AssetDTO assetDTO)
        {

            Name = assetDTO.Name;
            Symbol = assetDTO.Symbol;
            Type = assetDTO.Type;
            Description = assetDTO.Description;
        }

        public Asset()
        {
        }
    }


}
