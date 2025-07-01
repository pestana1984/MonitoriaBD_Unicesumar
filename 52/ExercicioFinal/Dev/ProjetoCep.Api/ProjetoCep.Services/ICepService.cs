using ProjetoCep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCep.Services
{
    public interface ICepService
    {
        Task<CepResponseDTO> GetCepInfoAsync(string cep);
    }
}
