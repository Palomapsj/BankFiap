using Bank.BankFiap.Bank.Entity;
using Bank.BankFiap.Bank.Interface;

namespace Bank.BankFiap.Bank.Repository
{
    public class MarketValueRepository : DapperRepository<MarketValue>, IMarketValue
    {
        public MarketValueRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public override void Add(MarketValue entidade)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<MarketValue> GetAll()
        {
            throw new NotImplementedException();
        }

        public override MarketValue GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(MarketValue entidade)
        {
            throw new NotImplementedException();
        }
    }
}
