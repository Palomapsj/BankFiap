using Bank.BankFiap.Bank.Entity;

namespace Bank.BankFiap.Bank.Interface
{
    public interface IUser : IRepository<User>
    {
        User GetUserByNameAndPassword(string userName, string password);
    }
}
