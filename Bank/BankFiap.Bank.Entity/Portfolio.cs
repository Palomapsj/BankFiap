using Bank.BankFiap.Bank.DTO;
using Microsoft.AspNetCore.Identity;
using System.Transactions;

namespace Bank.BankFiap.Bank.Entity
{
    public class Portfolio : BaseEntity
    {
        public string Name { get; set; }  // Example: "Aggressive", "Conservative"
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        public Portfolio(PortfolioDTO portfolioDTO)
        {

            Name = portfolioDTO.Name;
            UserId = portfolioDTO.UserId;
        }

        public Portfolio()
        {
        }
    }


}
