﻿using Bank.BankFiap.Bank.Entity;
using Bank.BankFiap.Bank.Entity.Enum;

namespace Bank.BankFiap.Bank.DTO
{
    public class TransactionDTO : BaseEntity
    {
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public TransactionType TransactionType { get; set; }  // Buy or Sell
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime TransactionDate { get; set; }
    }

}
