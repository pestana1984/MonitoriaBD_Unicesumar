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

        public Endereco GetEnderecoById(int id)
        {
            var endereco = _enderecoRepository.GetEnderecoById(id);

            if (endereco == null)
            {
                throw new ArgumentException("Endereço não encontrado.");
            }
            
            return endereco;

        }
    }
}
