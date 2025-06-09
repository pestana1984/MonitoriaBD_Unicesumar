using Modulo52.Models;

namespace Modulo52.Repositories
{
    public interface IAirportRepository
    {
        Task<IEnumerable<Airport>> GetAirportsAsync();
        Task<Airport> GetAirportByNameAsync(string name);
        Task CreateAirportAsync(Airport airport);
        Task<bool> UpdateAirportAsync(string id, Airport airport);
        Task<bool> DeleteAirportAsync(string id);
    }
}
