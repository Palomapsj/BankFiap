using Bank.BankFiap.Bank.Entity;
using Bank.BankFiap.Bank.Interface;
using Dapper;
using RabbitMQ.Client;
using System.Data.SqlClient;
using System.Text.Json;

namespace Bank.BankFiap.Bank.Repository
{
    public class PriceHistoryRepository : DapperRepository<PriceHistory>, IPriceHistory
    {
        private readonly ConnectionFactory _factory;

        public PriceHistoryRepository(IConfiguration configuration) : base(configuration)
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public override void Add(PriceHistory entidade)
        {
            PublishToQueue("queue-pricehistory-save", entidade);
        }

        public override void Update(PriceHistory entidade)
        {
            PublishToQueue("queue-pricehistory-update", entidade);

        }

        public override PriceHistory GetById(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM PriceHistories where id = @Id";
            return dbConnection.QueryFirstOrDefault<PriceHistory>(query, new { Id = id });
        }

        public override void Delete(int id)
        {
            PriceHistory entidade = new PriceHistory();
            entidade.Id = id;

            PublishToQueue("queue-pricehistory-delete", entidade);
        }

        public override IList<PriceHistory> GetAll()
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM PriceHistories";
            return dbConnection.Query<PriceHistory>(query).ToList();
        }

        public IList<PriceHistory> GetPriceHistoryByAssetId(int assetId)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM PriceHistories where AssetId = @assetId";
            return dbConnection.Query<PriceHistory>(query, new { AssetId = assetId }).ToList();
        }

        private void PublishToQueue(string queueName, PriceHistory entidade)
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
