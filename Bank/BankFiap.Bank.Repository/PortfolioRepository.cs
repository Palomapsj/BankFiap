using Bank.BankFiap.Bank.Entity;
using Bank.BankFiap.Bank.Interface;
using Dapper;
using RabbitMQ.Client;
using System.Data.SqlClient;
using System.Text.Json;

namespace Bank.BankFiap.Bank.Repository
{
    public class PortfolioRepository : DapperRepository<Portfolio>, IPortfolio
    {
        private readonly ConnectionFactory _factory;

        public PortfolioRepository(IConfiguration configuration) : base(configuration)
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public override void Add(Portfolio entidade)
        {
            PublishToQueue("queue-portfolio-save", entidade);
        }

        public override void Update(Portfolio entidade)
        {
            PublishToQueue("queue-portfolio-update", entidade);

        }

        public override Portfolio GetById(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Portfolios where id = @Id";
            return dbConnection.QueryFirstOrDefault<Portfolio>(query, new { Id = id });
        }

        public override void Delete(int id)
        {
            Portfolio entidade = new Portfolio();
            entidade.Id = id;

            PublishToQueue("queue-portfolio-delete", entidade);
        }

        public override IList<Portfolio> GetAll()
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Portfolios";
            return dbConnection.Query<Portfolio>(query).ToList();
        }

        private void PublishToQueue(string queueName, Portfolio entidade)
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
