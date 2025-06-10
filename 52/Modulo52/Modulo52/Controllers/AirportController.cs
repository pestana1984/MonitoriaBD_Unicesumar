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

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAirport([FromBody] Airport airport)
        {
            if (airport == null)
            {
                return BadRequest("Dados do aeroporto não podem ser nulos.");
            }

            await _airportService.CreateAirportAsync(airport);

            return CreatedAtAction(nameof(GetAirportByName), new { name = airport.Name }, airport);
        }

        [HttpDelete("Delete/{iata}")]
        public async Task<IActionResult> DeleteAirportByIata(string iata)
        {
            if (string.IsNullOrEmpty(iata))
            {
                return BadRequest("A IATA do aeroporto não pode ser vazia ou nula.");
            }

            var deleted = await _airportService.DeleteAirportAsync(iata);
            
            if (!deleted) // if(deleted == false)
            {
                return NotFound($"O aeroporto com a IATA '{iata}' não foi encontrado.");
            }

            return Ok($"O aeroport com a IATA '{iata}' foi excluido com sucesso!");
        }

        [HttpPut("Update/{icao}")]
        public async Task<IActionResult> UpdateAirport(string icao, [FromBody] Airport airport)
        {
            if (string.IsNullOrEmpty(icao) || airport == null)
            {
                return BadRequest("Dados inválidos para atualização do aeroporto.");
            }
            var updated = await _airportService.UpdateAirportAsync(icao, airport);
            
            if (!updated)
            {
                return NotFound($"O aeroporto com o ICAO '{icao}' não foi encontrado.");
            }
            return NoContent(); // 204 No Content
        }

    }
}
