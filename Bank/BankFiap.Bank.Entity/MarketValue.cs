using Bank.BankFiap.Bank.DTO;
using Bank.BankFiap.Bank.Entity.Enum;

namespace Bank.BankFiap.Bank.Entity
{
    public class MarketValue : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public DateTime ValueDate { get; set; }
        public decimal Price { get; set; }

        public MarketValue(MarketValueDTO marketValueDTO)
        {
            AssetId = marketValueDTO.AssetId;
            ValueDate = marketValueDTO.ValueDate;
            Price = marketValueDTO.Price;
        }

        public MarketValue()
        {
        }
    }

}
