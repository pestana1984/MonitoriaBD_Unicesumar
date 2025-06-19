using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIClinicas.Models;
using WebAPIClinicas.Models.olds;
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

        [HttpGet("{id}")]
        public IActionResult Get([FromQuery] int id)
        {
            var endereco = _enderecoService.GetEnderecoById(id);
            if(endereco == null)
            {
                return NotFound(new { Message = "Endereço não encontrado." });
            }
            return Ok(endereco);
        }
    }
}
