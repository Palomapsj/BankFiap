using Bank.BankFiap.Bank.Entity;
using Bank.BankFiap.Bank.Interface;
using Dapper;
using RabbitMQ.Client;
using System.Data.SqlClient;
using System.Text.Json;

namespace Bank.BankFiap.Bank.Repository
{
    public class MarketValueRepository : DapperRepository<MarketValue>, IMarketValue
    {
        private readonly ConnectionFactory _factory;

        public MarketValueRepository(IConfiguration configuration) : base(configuration)
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public override void Add(MarketValue entidade)
        {
            PublishToQueue("queue-marketvalues-save", entidade);
        }

        public override void Update(MarketValue entidade)
        {
            PublishToQueue("queue-marketvalues-update", entidade);

        }

        public override MarketValue GetById(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM MarketValues where id = @Id";
            return dbConnection.QueryFirstOrDefault<MarketValue>(query, new { Id = id });
        }

        public override void Delete(int id)
        {
            MarketValue entidade = new MarketValue();
            entidade.Id = id;

            PublishToQueue("queue-marketvalues-delete", entidade);
        }

        public override IList<MarketValue> GetAll()
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM MarketValues";
            return dbConnection.Query<MarketValue>(query).ToList();
        }

        public IList<MarketValue> GetMarketValueByAssetId(int assetId)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM MarketValues where AssetId = @assetId";
            return dbConnection.Query<MarketValue>(query, new { AssetId = assetId }).ToList();
        }

        private void PublishToQueue(string queueName, MarketValue entidade)
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
