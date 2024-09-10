using Bank.BankFiap.Bank.Entity;
using Bank.BankFiap.Bank.Entity.Enum;

namespace Bank.BankFiap.Bank.DTO
{
    public class DividendInterestDTO: BaseEntity
    {
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public PaymentType PaymentType { get; set; }  // Dividend or Interest
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }

}
