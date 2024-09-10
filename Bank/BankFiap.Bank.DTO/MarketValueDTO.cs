using Bank.BankFiap.Bank.Entity;
namespace Bank.BankFiap.Bank.DTO
{
    public class MarketValueDTO : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public DateTime ValueDate { get; set; }
        public decimal Price { get; set; }
    }

}
