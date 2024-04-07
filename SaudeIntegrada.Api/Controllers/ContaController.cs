using Microsoft.AspNetCore.Mvc;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Application.Service;

namespace SaudeIntegrada.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _ContaService;

        public ContaController(ContaService ContaService)
        {
            _ContaService = ContaService;
        }

        [HttpPost]
        [Route("Criar")]
        public IActionResult Criar([FromBody] ContaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._ContaService.Criar(dto);

            return Created($"/Conta/{result.Id}", result);
        }

        [HttpPatch]
        [Route("Editar")]
        public IActionResult Editar([FromBody] ContaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._ContaService.Editar(dto);

            return Created($"/Conta/{result.Id}", result);
        }

        [HttpDelete]
        [Route("Apagar")]
        public IActionResult Apagar([FromBody] ContaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._ContaService.Apagar(dto);

            return Ok();
        }

        [HttpGet]
        [Route("ListaTodos")]
        public IActionResult ListaTodos()
        {
            var result = this._ContaService.ObterTodos();

            return Ok(result);
        }

        [HttpGet]
        [Route("ContasPorId")]
        public IActionResult GetContasPorId(Guid id)
        {
            var result = this._ContaService.Obter(id);

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
            var result = this._ContaService.BuscarPorTelefone(telefone);

            return Ok(result);
        }

        [HttpGet]
        [Route("BuscarPorEmail")]
        public IActionResult BuscarPorEmail(string email)
        {
            var result = this._ContaService.BuscarPorEmail(email);

            return Ok(result);
        }




    }
}
