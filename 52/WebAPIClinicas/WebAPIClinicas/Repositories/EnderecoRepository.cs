using Npgsql;
using WebAPIClinicas.Data;
using WebAPIClinicas.Models;

namespace WebAPIClinicas.Repositories
{
    public class EnderecoRepository
    {
        private readonly NpgsqlConnection _connection;
        private readonly AppDbContext _context;

        public EnderecoRepository(NpgsqlConnection connection, AppDbContext appDbContext)
        {
            _connection = connection;
            _context = appDbContext;
        }
        public Endereco GetEnderecoById(int id)
        {
            _connection.Open();
            using var cmd = _connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM \"Enderecos\" WHERE \"EnderecoId\" = @id";
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            _connection.Close();

            if (reader.Read())
            {
                return new Endereco
                {
                    Enderecoid = reader.GetInt32(reader.GetOrdinal("EnderecoId")),
                    Logradouro = reader.GetString(reader.GetOrdinal("Logradouro")),
                    Numero = reader.GetInt32(reader.GetOrdinal("Numero")),
                    Bairro = reader.GetString(reader.GetOrdinal("Bairro")),
                    Cep = reader.GetString(reader.GetOrdinal("Cep")),
                    Cidade = reader.GetString(reader.GetOrdinal("Cidade")),
                    Estado = reader.GetString(reader.GetOrdinal("Estado"))
                };
            }

            return new Endereco();
        }

    }
}
