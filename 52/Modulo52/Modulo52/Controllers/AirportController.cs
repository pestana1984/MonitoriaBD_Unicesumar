using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modulo52.Models;
using Modulo52.Services;

namespace Modulo52.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IAirportService _airportService;
        public AirportController(IAirportService airportService)
        {
            _airportService = airportService;
        }

        [HttpGet("All")]
        public async Task<IEnumerable<Airport>> GetAirports()
        {
            return await _airportService.GetAirportsAsync();
        }

        [HttpGet("ByName/{name}")]
        public async Task<ActionResult<Airport>> GetAirportByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("O nome do aeroporto não pode ser vazio ou nulo.");
            }

            var airport = await _airportService.GetAirportByNameAsync(name);
            
            if (airport == null)
            {
                return NotFound($"O aeroporto '{name}' não foi encontrado.");
            }
            return Ok(airport);
        }

    }
}
