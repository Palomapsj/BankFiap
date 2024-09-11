using Bank.BankFiap.Bank.Entity;
using Bank.BankFiap.Bank.Interface;
using System.Data.SqlClient;
using Bank.BankFiap.Bank.Entity;
using System.Data.SqlClient;
using System.Text.Json;
using Dapper;
using RabbitMQ.Client;

namespace Bank.BankFiap.Bank.Repository
{
    public class AssetRepository : DapperRepository<Asset>, IAsset
    {
        private readonly ConnectionFactory _factory;

        public AssetRepository(IConfiguration configuration) : base(configuration)
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public override void Add(Asset entidade)
        {
            PublishToQueue("queue-assets-save", entidade);
        }

        public override void Update(Asset entidade)
        {
            PublishToQueue("queue-assets-update", entidade);

        }

        public override Asset GetById(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Assets where id = @Id";
            return dbConnection.QueryFirstOrDefault<Asset>(query, new { Id = id });
        }

        public override void Delete(int id)
        {
            Asset entidade = new Asset();
            entidade.Id = id;

            PublishToQueue("queue-assets-delete", entidade);
        }

        public override IList<Asset> GetAll()
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Assets";
            return dbConnection.Query<Asset>(query).ToList();
        }

        public IList<Asset> GetAssetsByType(int type)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Assets where Type = @type";
            return dbConnection.Query<Asset>(query, new { Type = type }).ToList();
        }

        private void PublishToQueue(string queueName, Asset entidade)
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