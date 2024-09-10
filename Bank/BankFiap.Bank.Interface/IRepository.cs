using Bank.BankFiap.Bank.Entity;

namespace Bank.BankFiap.Bank.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        IList<T> GetAll();

        T GetById(int id);

        void Add(T entidade);

        void Update(T entidade);

        void Delete(int id);

    }
}
