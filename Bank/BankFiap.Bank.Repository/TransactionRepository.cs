using Bank.BankFiap.Bank.Interface;
using Dapper;
using RabbitMQ.Client;
using System.Data.SqlClient;
using System.Text.Json;
using Transaction = Bank.BankFiap.Bank.Entity.Transaction;

namespace Bank.BankFiap.Bank.Repository
{
    public class TransactionRepository : DapperRepository<Transaction>, ITransaction
    {
        private readonly ConnectionFactory _factory;

        public TransactionRepository(IConfiguration configuration) : base(configuration)
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public override void Add(Transaction entidade)
        {
            PublishToQueue("queue-transaction-save", entidade);
        }

        public override void Update(Transaction entidade)
        {
            PublishToQueue("queue-transaction-update", entidade);

        }

        public override Transaction GetById(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Transactions where id = @Id";
            return dbConnection.QueryFirstOrDefault<Transaction>(query, new { Id = id });
        }

        public override void Delete(int id)
        {
            Transaction entidade = new Transaction();
            entidade.Id = id;

            PublishToQueue("queue-transaction-delete", entidade);
        }

        public override IList<Transaction> GetAll()
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Transactions";
            return dbConnection.Query<Transaction>(query).ToList();
        }

        private void PublishToQueue(string queueName, Transaction entidade)
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
