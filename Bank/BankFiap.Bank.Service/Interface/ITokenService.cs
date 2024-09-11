using Bank.BankFiap.Bank.Entity;

namespace BankFiap.Bank.Service.Interface
{
    public interface ITokenService
    {
        string GetToken(User user);
    }
}
