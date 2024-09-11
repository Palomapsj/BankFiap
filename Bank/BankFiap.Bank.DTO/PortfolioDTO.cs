using System.Transactions;
using Bank.BankFiap.Bank.Entity;
using Microsoft.AspNetCore.Identity;

namespace Bank.BankFiap.Bank.DTO
{
    public class PortfolioDTO : BaseEntity
    {
        public string Name { get; set; }  // Example: "Aggressive", "Conservative"
        public int UserId { get; set; }
        public User User { get; set; }
        // public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();


      
    }


}
