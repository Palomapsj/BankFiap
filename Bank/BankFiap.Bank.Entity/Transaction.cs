using Bank.BankFiap.Bank.DTO;
using Bank.BankFiap.Bank.Entity.Enum;
using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;

namespace Bank.BankFiap.Bank.Entity
{
    public class Transaction : BaseEntity
    {
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public TransactionType TransactionType { get; set; }  // Buy or Sell
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime TransactionDate { get; set; }

        public Transaction(TransactionDTO transactionDTO)
        {
            PortfolioId = transactionDTO.PortfolioId;
            AssetId = transactionDTO.AssetId;
            TransactionType = transactionDTO.TransactionType;
            Quantity = transactionDTO.Quantity;
            UnitPrice = transactionDTO.UnitPrice;
            TransactionDate = transactionDTO.TransactionDate;
        }

        public Transaction()
        {
        }
    }
}
