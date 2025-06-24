using WebAPIClinicas.Data;
using WebAPIClinicas.Models;
using WebAPIClinicas.Repositories;

namespace WebAPIClinicas.Services
{
    public class EnderecoService
    {
        private readonly EnderecoRepository _enderecoRepository;

        private readonly AppDbContext _context;

        public EnderecoService(EnderecoRepository enderecoRepository, AppDbContext appDbContext)
        {
            _enderecoRepository = enderecoRepository;
            _context = appDbContext;
        }

        public Endereco? GetEnderecoById(int id)
        {
            var endereco = _enderecoRepository.GetEnderecoById(id);

            if (endereco == null)
            {
                return endereco;
            }

            return endereco;
        }

        public List<Endereco> GetAllEnderecos()
        {
            return _enderecoRepository.GetAllEnderecos();
        }

        public Endereco AddEndereco(Endereco endereco)
        {
            if (endereco == null)
            {
                throw new ArgumentNullException(nameof(endereco), "Endereço não pode ser nulo.");
            }

            if (!_enderecoRepository.GetEnderecoByCEP(endereco))
                return _enderecoRepository.AddEndereco(endereco);
            else
                throw new Exception("Endereço já cadastrado com este CEP.");
        }
    }
}
