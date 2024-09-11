using Bank.BankFiap.Bank.DTO;

namespace Bank.BankFiap.Bank.Entity
{
    public class User : BaseEntity
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();

        public User(UserDTO userDto)
        {

            Name = userDto.Name;
            Email = userDto.Email;
            PasswordHash = userDto.PasswordHash;
        }

        public User()
        {
        }
    }
}
