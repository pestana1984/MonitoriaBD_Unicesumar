

namespace ProjetoCep.Models
{
    public class CepResponseDTO
    {
        public string Cep { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }

        public static async Task<CepResponseDTO> FromEntityAsync(CepEntity cepEntity)
        {
            return await Task.FromResult(new CepResponseDTO
            {
                Cep = cepEntity.Cep,
                State = cepEntity.State,
                City = cepEntity.City,
                Neighborhood = cepEntity.Neighborhood,
                Street = cepEntity.Street
            });
        }
    }
}
