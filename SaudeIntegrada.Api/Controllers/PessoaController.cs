using Microsoft.AspNetCore.Mvc;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.Service;

namespace SaudeIntegrada.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private PessoaService _PessoaService;

        public PessoaController(PessoaService PessoaService)
        {
            _PessoaService = PessoaService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var result = this._PessoaService.ObterTodos();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetPessoasPorId(Guid id)
        {
            var result = this._PessoaService.Obter(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] PessoaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._PessoaService.Criar(dto);

            return Created($"/Pessoa/{result.Id}", result);
        }

        //TODO CRIAR
        //TODO EDITAR
        //TODO DELETAR
        //TODO LISTAR
    }
}
