using Modulo52.Models;
using Modulo52.Repositories;

namespace Modulo52.Services
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository _airportRepository;

        public AirportService(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public Task CreateAirportAsync(Airport airport)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAirportAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Airport> GetAirportByNameAsync(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("O nome do aeroporto não pode ser vazio ou nulo!", nameof(name));
            }

            if(name.Length < 3)
            {
                throw new ArgumentException("O nome do aeroporto deve ter pelo menos 3 caracteres!", nameof(name));
            }

            return await _airportRepository.GetAirportByNameAsync(name);
        }

        public async Task<IEnumerable<Airport>> GetAirportsAsync()
        {
            return await _airportRepository.GetAirportsAsync();
        }

        public Task<bool> UpdateAirportAsync(string id, Airport airport)
        {
            throw new NotImplementedException();
        }
    }
}
