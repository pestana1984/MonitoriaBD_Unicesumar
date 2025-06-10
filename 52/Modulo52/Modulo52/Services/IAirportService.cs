using Modulo52.Models;

namespace Modulo52.Services
{
    public interface IAirportService
    {
        Task<IEnumerable<Airport>> GetAirportsAsync();

        Task<Airport> GetAirportByNameAsync(string name);

        Task<Airport> CreateAirportAsync(Airport airport);

        Task<bool> UpdateAirportAsync(string id, Airport airport);

        Task<bool> DeleteAirportAsync(string iata);

    }
}
