using Microsoft.AspNetCore.Mvc;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Application.Service;

namespace SaudeIntegrada.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _PessoaService;

        public PessoaController(IPessoaService PessoaService)
        {
            _PessoaService = PessoaService;
        }

        [HttpPost]
        [Route("Criar")]
        public IActionResult Criar( PessoaCriarDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._PessoaService.Criar(dto);

            return Created($"/Pessoa/{result.Id}", result);
        }

        [HttpPatch]
        [Route("Editar")]
        public IActionResult Editar( PessoaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._PessoaService.Editar(dto);

            return Ok(result);
        }

        [HttpDelete]
        [Route("Apagar")]
        public IActionResult Apagar(Guid id)
        {            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._PessoaService.Apagar(id);

            return Ok();
        }

        [HttpGet]
        [Route("ListaTodos")]
        public IActionResult ListaTodos()
        {
            var result = this._PessoaService.ObterTodos();

            return Ok(result);
        }

        [HttpGet]
        [Route("PessoasPorId")]
        public IActionResult GetPessoasPorId(Guid id)
        {
            var result = this._PessoaService.Obter(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        



    }
}
