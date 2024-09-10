using Bank.BankFiap.Bank.Entity;
using Bank.BankFiap.Bank.Interface;

namespace Bank.BankFiap.Bank.Repository
{
    public class PortifolioRepository : DapperRepository<Portfolio>, IPortifolio
    {
        public PortifolioRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public override void Add(Portfolio entidade)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<Portfolio> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Portfolio GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Portfolio entidade)
        {
            throw new NotImplementedException();
        }
    }
}
