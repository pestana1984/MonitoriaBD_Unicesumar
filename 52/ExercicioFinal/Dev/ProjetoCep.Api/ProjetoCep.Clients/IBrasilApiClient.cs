using ProjetoCep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCep.Clients
{
    public interface IBrasilApiClient
    {
        Task<BrasilApiCepResponse> GetCepAsync(string cep);
    }
}
