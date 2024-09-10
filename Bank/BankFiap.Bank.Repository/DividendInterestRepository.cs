using Bank.BankFiap.Bank.Entity;
using Bank.BankFiap.Bank.Interface;

namespace Bank.BankFiap.Bank.Repository
{
    public class DividendInterestRepository : DapperRepository<DividendInterest>, IDividendInterest
    {
        public DividendInterestRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public override void Add(DividendInterest entidade)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<DividendInterest> GetAll()
        {
            throw new NotImplementedException();
        }

        public override DividendInterest GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(DividendInterest entidade)
        {
            throw new NotImplementedException();
        }
    }
}
