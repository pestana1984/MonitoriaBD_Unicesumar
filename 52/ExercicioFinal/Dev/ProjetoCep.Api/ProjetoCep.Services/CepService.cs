using ProjetoCep.Clients;
using ProjetoCep.Models;
using ProjetoCep.Repo;
using System.Collections.Generic;

namespace ProjetoCep.Services
{
    public class CepService : ICepService
    {
        private readonly ICepRepository _cepRepository;
        private readonly IBrasilApiClient _brasilApiClient;
        private readonly IDistributedCache _cache;

        public CepService(ICepRepository cepRepository,
            IBrasilApiClient brasilApiClient,
            IDistributedCache cache)
        {
            _cepRepository = cepRepository;
            _brasilApiClient = brasilApiClient;
            _cache = cache;
        }

        public async Task<CepResponseDTO> GetCepInfoAsync(string cep)
        {
            CepEntity cepEntity = new();

            if(cepEntity != null)
            {
                return await CepResponseDTO.FromEntityAsync(cepEntity);
            }
            
            // Insere o CEP no cache
            BrasilApiCepResponse? brasilApiCep = null;
            try
            {
                brasilApiCep = await _brasilApiClient.GetCepAsync(cep);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Falha na comunicação com a BrasilAPI para o CEP {Cep}.", cep);
                throw; // Re-lança a exceção da BrasilAPI para o Controller
            }

            if (brasilApiCep == null)
            {
                //_logger.LogWarning("CEP {Cep} não encontrado na BrasilAPI.", cep);
                throw new KeyNotFoundException($"CEP {cep} não encontrado na BrasilAPI.");
            }

            cepEntity = new CepEntity
            {
                Cep = brasilApiCep.Cep,
                State = brasilApiCep.State,
                City = brasilApiCep.City,
                Neighborhood = brasilApiCep.Neighborhood,
                Street = brasilApiCep.Street
            };

            await _cepRepository.InsertAsync(cepEntity);

            return CepResponseDTO.FromEntityAsync(cepEntity).Result;
        }
    }
}
