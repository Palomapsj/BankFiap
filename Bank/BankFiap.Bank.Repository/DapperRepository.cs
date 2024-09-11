using Bank.BankFiap.Bank.Entity;
using Bank.BankFiap.Bank.Interface;
namespace Bank.BankFiap.Bank.Repository
{
    public abstract class DapperRepository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly string _connectionString;
        protected string ConnectionString => _connectionString;

        public DapperRepository(IConfiguration configuration)
        {

            _connectionString = configuration.GetValue<string>("ConnectionStrings:ConnectionString");
        }


        public abstract void Update(T entidade);

        public abstract void Add(T entidade);

        public abstract void Delete(int id);

        public abstract T GetById(int id);

        public abstract IList<T> GetAll();

    }
}
