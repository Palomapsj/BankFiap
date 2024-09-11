using Bank.BankFiap.Bank.Interface;
using Bank.BankFiap.Bank.Entity;
using System.Data.SqlClient;
using System.Text.Json;
using Dapper;
using RabbitMQ.Client;

namespace Bank.BankFiap.Bank.Repository
{
    public class UserRepository: DapperRepository<User>, IUser
    {
        private readonly ConnectionFactory _factory;

        public UserRepository(IConfiguration configuration) : base(configuration)
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public override void Add(User entidade)
        {
            PublishToQueue("queue-user-save", entidade);
        }

        public override void Update(User entidade)
        {
            PublishToQueue("queue-user-update", entidade);

        }

        public override User GetById(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Users where Id = @Id";
            return dbConnection.QueryFirstOrDefault<User>(query, new { Id = id });
        }

        public override void Delete(int id)
        {
            User entidade = new User();
            entidade.Id = id;

            PublishToQueue("queue-user-delete", entidade);
        }

        public override IList<User> GetAll()
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Users";
            return dbConnection.Query<User>(query).ToList();
        }

        public User GetUserByNameAndPassword(string userName, string password)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Users where username = @userName and senha = @password";

            return dbConnection.QueryFirstOrDefault<User>(query, new { userName, password });
        }

        private void PublishToQueue(string queueName, User entidade)
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
