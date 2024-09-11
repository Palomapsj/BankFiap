using Bank.BankFiap.Bank.Entity;
using Bank.BankFiap.Bank.Interface;
using Dapper;
using RabbitMQ.Client;
using System.Data.SqlClient;
using System.Text.Json;

namespace Bank.BankFiap.Bank.Repository
{
    public class DividendInterestRepository : DapperRepository<DividendInterest>, IDividendInterest
    {
        private readonly ConnectionFactory _factory;

        public DividendInterestRepository(IConfiguration configuration) : base(configuration)
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public override void Add(DividendInterest entidade)
        {
            PublishToQueue("queue-dividendinterest-save", entidade);
        }

        public override void Update(DividendInterest entidade)
        {
            PublishToQueue("queue-dividendinterest-update", entidade);

        }

        public override DividendInterest GetById(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM DividendsInterests where id = @Id";
            return dbConnection.QueryFirstOrDefault<DividendInterest>(query, new { Id = id });
        }

        public override void Delete(int id)
        {
            DividendInterest entidade = new DividendInterest();
            entidade.Id = id;

            PublishToQueue("queue-dividendinterest-delete", entidade);
        }

        public override IList<DividendInterest> GetAll()
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM DividendsInterests";
            return dbConnection.Query<DividendInterest>(query).ToList();
        }

        public IList<DividendInterest> GetDividendsInterestsByPortfolioId(int portfolioId)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM DividendsInterests where PortfolioId = @portfolioId";
            return dbConnection.Query<DividendInterest>(query, new { PortfolioId = portfolioId }).ToList();
        }

        private void PublishToQueue(string queueName, DividendInterest entidade)
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = JsonSerializer.SerializeToUtf8Bytes(entidade);
                channel.BasicPublish(exchange: "",
                                     routingKey: queueName,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
