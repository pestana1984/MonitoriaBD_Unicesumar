using Microsoft.AspNetCore.Mvc;
using Modulo52.Models;
using MongoDB.Driver;

namespace Modulo52.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly MongoDBSettings _mongoDBSettings;

        private readonly IMongoCollection<Airport> _airportsCollection;

        public AirportRepository(IConfiguration mongoDBSettings)
        {
            _mongoDBSettings = new MongoDBSettings();

            var client = new MongoClient(_mongoDBSettings.ConnectionString);
            var database = client.GetDatabase(_mongoDBSettings.DatabaseName);
            var collection = database.GetCollection<Airport>(_mongoDBSettings.CollectionName);

            _airportsCollection = database.GetCollection<Airport>(_mongoDBSettings.CollectionName);
        }

        public async Task<IEnumerable<Airport>> GetAirportsAsync()
        {
            return await _airportsCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Airport> CreateAirportAsync(Airport airport)
        {
            await _airportsCollection.InsertOneAsync(airport);

            return airport;
        }

        public Task<bool> DeleteAirportAsync(string iata)
        {
            return _airportsCollection.DeleteOneAsync(a => a.Iata.Equals(iata, StringComparison.OrdinalIgnoreCase))
                .ContinueWith(task => task.Result.DeletedCount > 0);
        }

        public async Task<Airport> GetAirportByNameAsync(string name)
        {
            return await _airportsCollection.Find(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefaultAsync();
        }

        public Task<bool> UpdateAirportAsync(string icao, Airport airport)
        {
            return _airportsCollection.ReplaceOneAsync(a => a.Icao.Equals(icao, StringComparison.OrdinalIgnoreCase), airport)
                .ContinueWith(task => task.Result.ModifiedCount > 0);
        }
    }
}
