using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using ProjetoCep.Models;

namespace ProjetoCep.Clients
{
    public class BrasilApiClient : IBrasilApiClient
    {
        private readonly HttpClient _httpClient;

        public BrasilApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://brasilapi.com.br/api/cep/v1/");
        }

        public Task<BrasilApiCepResponse> GetCepAsync(string cep)
        {
            try
            {
                var busca = _httpClient.BaseAddress + cep;
                var response = _httpClient.GetAsync(busca).Result;

                var converted = response.ToBsonDocument();
                if (converted != null)
                {
                    return Task.FromResult<BrasilApiCepResponse>(
                        BsonSerializer.Deserialize<BrasilApiCepResponse>(converted));
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception($"Error fetching CEP data: {ex.Message}", ex);
            }

            return Task.FromResult<BrasilApiCepResponse>(null);

        }
    }
}
