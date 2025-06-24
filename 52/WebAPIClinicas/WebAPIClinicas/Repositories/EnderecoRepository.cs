using Npgsql;
using WebAPIClinicas.Data;
using WebAPIClinicas.Models;
using WebAPIClinicas.Models.olds;

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
        public Endereco? GetEnderecoById(int id)
        {
            _connection.Open();
            using var cmd = _connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM \"Enderecos\" WHERE \"enderecoid\" = @id";
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                _connection.Close();
                return null; // Retorna um nulo se não encontrar nenhum endereço
            }

            if (reader.Read())
            {
                return new Endereco
                {
                    Enderecoid = reader.GetInt32(reader.GetOrdinal("enderecoid")),
                    Logradouro = reader.GetString(reader.GetOrdinal("Logradouro")),
                    Numero = reader.GetInt32(reader.GetOrdinal("Numero")),
                    Bairro = reader.GetString(reader.GetOrdinal("Bairro")),
                    Cep = reader.GetString(reader.GetOrdinal("Cep")),
                    Cidade = reader.GetString(reader.GetOrdinal("Cidade")),
                    Estado = reader.GetString(reader.GetOrdinal("Estado"))
                };
            }
            _connection.Close();
            return new Endereco();
        }

        public bool GetEnderecoByCEP(Endereco endereco)
        {
            _connection.Open();
            if (_context.Enderecos.Any(e => e.Cep == endereco.Cep))
            {
                return true;
            }
            _connection.Close();
            return false;
        }
        public List<Endereco> GetAllEnderecos()
        {
            _connection.Open();
            var enderecos = new List<Endereco>();
            using var cmd = _connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM \"Enderecos\"";

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                enderecos.Add(new Endereco
                {
                    Enderecoid = reader.GetInt32(reader.GetOrdinal("enderecoid")),
                    Logradouro = reader.GetString(reader.GetOrdinal("Logradouro")),
                    Numero = reader.GetInt32(reader.GetOrdinal("Numero")),
                    Bairro = reader.GetString(reader.GetOrdinal("Bairro")),
                    Cep = reader.GetString(reader.GetOrdinal("Cep")),
                    Cidade = reader.GetString(reader.GetOrdinal("Cidade")),
                    Estado = reader.GetString(reader.GetOrdinal("Estado"))
                });
            }
            _connection.Close();
            return enderecos;
        }
        public Endereco AddEndereco(Endereco endereco)
        {
            _connection.Open();
            //using var cmd = _connection.CreateCommand();
            //cmd.CommandText = "INSERT INTO \"Enderecos\" (\"logradouro\", \"numero\", \"bairro\", \"cep\", \"cidade\", \"estado\") " +
            //                  "VALUES (@logradouro, @numero, @bairro, @cep, @cidade, @estado) RETURNING \"enderecoid\"";

            //cmd.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
            //cmd.Parameters.AddWithValue("@numero", endereco.Numero);
            //cmd.Parameters.AddWithValue("@bairro", endereco.Bairro);
            //cmd.Parameters.AddWithValue("@cep", endereco.Cep);
            //cmd.Parameters.AddWithValue("@cidade", endereco.Cidade);
            //cmd.Parameters.AddWithValue("@estado", endereco.Estado);

            //var newId = (int)cmd.ExecuteScalar();

            //endereco.Enderecoid = newId;

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            _connection.Close();

            return endereco;
        }
    }
}
