using MongoDB.Driver;
using ProjetoCep.Models;

namespace ProjetoCep.Repo
{
    public class CepRepository : ICepRepository
    {
        private readonly IMongoCollection<CepEntity> _cepCollection;

        public CepRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Cep");
            _cepCollection = database.GetCollection<CepEntity>("Brasil");
        }

        public async Task<CepEntity> GetCepAsync(string cep)
        {
            return await _cepCollection.Find(c => c.Cep == cep).FirstOrDefaultAsync();
        }

        public Task InsertAsync(CepEntity cepEntity)
        {
            return _cepCollection.InsertOneAsync(cepEntity);
        }
    }
}
