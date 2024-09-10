using Bank.BankFiap.Bank.Entity;
namespace Bank.BankFiap.Bank.DTO
{
    public class UserDTO : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }

}
