using Bank.BankFiap.Bank.Entity;
using Bank.BankFiap.Bank.Interface;
using System.Data.SqlClient;
using Bank.BankFiap.Bank.Entity;
using System.Data.SqlClient;
using System.Text.Json;
using Dapper;

namespace Bank.BankFiap.Bank.Repository
{
    public class AssetRepository : DapperRepository<Asset>, IAsset
    {
        public AssetRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public override void Add(Asset entidade)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<Asset> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Asset GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Asset entidade)
        {
            throw new NotImplementedException();
        }
    }
}