using Bank.BankFiap.Bank.Interface;
using Microsoft.AspNetCore.Connections;
using  Bank.BankFiap.Bank.Repository;
using Bank.BankFiap.Bank.Entity;
using System.Data.SqlClient;
using System.Text.Json;
using Dapper;

namespace Bank.BankFiap.Bank.Repository
{
    public class UserRepository: DapperRepository<User>, IUser
    {
      //  private readonly ConnectionFactory _factory;

        public UserRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public override void Add(User entidade)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "INSERT INTO Alunoss  VALUES (@Nome, @DataNascimento, @Email, @Telefone, @Endereco, @UsuarioId)";
            dbConnection.Execute(query, entidade);
        }

        public override void Update(User entidade)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "UPDATE Alunoss SET ENDERECO = @Endereco, TELEFONE = @Telefone, EMAIL = @Email WHERE aluno_id = @AlunoId ";
            dbConnection.Query(query, entidade);
        }

        public override User GetById(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Alunoss where Aluno_id = @Id";
            return dbConnection.QueryFirstOrDefault<User>(query, new { Id = id });
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();

        }

        public override IList<User> GetAll()
        {
            throw new NotImplementedException();
        }
       
    }
}
