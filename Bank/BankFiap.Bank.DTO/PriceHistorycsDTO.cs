using Bank.BankFiap.Bank.Entity;
namespace Bank.BankFiap.Bank.DTO
{
    public class PriceHistoryDTO : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public DateTime QuoteDate { get; set; }
        public decimal OpeningPrice { get; set; }
        public decimal ClosingPrice { get; set; }
        public decimal Low { get; set; }
        public decimal High { get; set; }
        public decimal Volume { get; set; }
    }

}
