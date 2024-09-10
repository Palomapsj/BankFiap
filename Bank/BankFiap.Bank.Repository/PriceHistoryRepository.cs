using Bank.BankFiap.Bank.Entity;
using Bank.BankFiap.Bank.Interface;

namespace Bank.BankFiap.Bank.Repository
{
    public class PriceHistoryRepository : DapperRepository<PriceHistory>, IPriceHistory
    {
        public PriceHistoryRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public override void Add(PriceHistory entidade)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<PriceHistory> GetAll()
        {
            throw new NotImplementedException();
        }

        public override PriceHistory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(PriceHistory entidade)
        {
            throw new NotImplementedException();
        }
    }
}
