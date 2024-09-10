using Bank.BankFiap.Bank.Entity;
using Bank.BankFiap.Bank.Interface;

namespace Bank.BankFiap.Bank.Repository
{
    public class TransactionRepository : DapperRepository<Transaction>, ITransaction
    {
        public TransactionRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public override void Add(Transaction entidade)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<Transaction> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Transaction GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Transaction entidade)
        {
            throw new NotImplementedException();
        }
    }
}
