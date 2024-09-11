using Bank.BankFiap.Bank.DTO;
using Bank.BankFiap.Bank.Entity.Enum;

namespace Bank.BankFiap.Bank.Entity
{
    public class PriceHistory : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public DateTime QuoteDate { get; set; }
        public decimal OpeningPrice { get; set; }
        public decimal ClosingPrice { get; set; }
        public decimal Low { get; set; }
        public decimal High { get; set; }
        public decimal Volume { get; set; }

        public PriceHistory(PriceHistoryDTO transactionDTO)
        {
            AssetId = transactionDTO.AssetId;
            QuoteDate = transactionDTO.QuoteDate;
            OpeningPrice = transactionDTO.OpeningPrice;
            ClosingPrice = transactionDTO.ClosingPrice;
            Low = transactionDTO.Low;
            High = transactionDTO.High;
            Volume = transactionDTO.Volume;
        }

        public PriceHistory()
        {
        }
    }

}
