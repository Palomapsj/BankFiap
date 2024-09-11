using Bank.BankFiap.Bank.DTO;
using Bank.BankFiap.Bank.Entity.Enum;

namespace Bank.BankFiap.Bank.Entity
{
    public class DividendInterest : BaseEntity
    {
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public PaymentType PaymentType { get; set; }  // Dividend or Interest
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public DividendInterest(DividendInterestDTO dividendInterestDTO)
        {
            PortfolioId = dividendInterestDTO.PortfolioId;
            AssetId = dividendInterestDTO.AssetId;
            PaymentType = dividendInterestDTO.PaymentType;
            Amount = dividendInterestDTO.Amount;
            PaymentDate = dividendInterestDTO.PaymentDate;
        }

        public DividendInterest()
        {
        }
    }

}
