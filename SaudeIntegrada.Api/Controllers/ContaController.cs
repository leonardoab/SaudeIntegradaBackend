using Microsoft.AspNetCore.Mvc;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;

namespace SaudeIntegrada.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;

        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpPost]
        [Route("Criar")]
        public IActionResult Criar(ContaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _contaService.Criar(dto);

            return Created($"/Conta/{result.Id}", result);
        }

        [HttpPatch]
        [Route("Editar")]
        public IActionResult Editar([FromBody] ContaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _contaService.Editar(dto);

            return Created($"/Conta/{result.Id}", result);
        }

        [HttpDelete]
        [Route("Apagar")]
        public IActionResult Apagar([FromBody] ContaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _contaService.Apagar(dto);

            return Ok();
        }

        [HttpGet]
        [Route("ListaTodos")]
        public IActionResult ListaTodos()
        {
            var result = _contaService.ObterTodos();

            return Ok(result);
        }

        [HttpGet]
        [Route("ContasPorId")]
        public IActionResult GetContasPorId(Guid id)
        {
            var result = _contaService.Obter(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("BuscarPorTelefone")]
        public IActionResult BuscarPorTelefone(string telefone)
        {
            var result = _contaService.BuscarPorTelefone(telefone);

            return Ok(result);
        }

        [HttpGet]
        [Route("BuscarPorEmail")]
        public IActionResult BuscarPorEmail(string email)
        {
            var result = _contaService.BuscarPorEmail(email);

            return Ok(result);
        }
    }
}
