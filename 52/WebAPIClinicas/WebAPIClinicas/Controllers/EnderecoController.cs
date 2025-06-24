using Microsoft.AspNetCore.Mvc;
using WebAPIClinicas.Models;
using WebAPIClinicas.Services;

namespace WebAPIClinicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public IActionResult HeartBeat()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O id deve ser maior que zero!");
            }

            var endereco = _enderecoService.GetEnderecoById(id);

            if (endereco is null)
            {
                return NotFound(new { Message = "Endereço não encontrado." });
            }
            return Ok(endereco);
        }

        [HttpGet("All")]
        public IActionResult GetAllAddress()
        {
            var enderecos = _enderecoService.GetAllEnderecos();
            if (enderecos.Count == 0)
                return NoContent();
            else
                return Ok(_enderecoService.GetAllEnderecos());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Endereco endereco)
        {
            if (endereco == null)
            {
                return BadRequest(new { Message = "Dados inválidos." });
            }

            try
            {
                _enderecoService.AddEndereco(endereco);
                return CreatedAtAction(nameof(Get), new { id = endereco.Enderecoid }, endereco);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}
