using Microsoft.AspNetCore.Mvc;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Application.Service;

namespace SaudeIntegrada.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoFichaController : ControllerBase
    {
        private readonly IAvaliacaoFichaService _AvaliacaoFichaService;

        public AvaliacaoFichaController(IAvaliacaoFichaService AvaliacaoFichaService)
        {
            _AvaliacaoFichaService = AvaliacaoFichaService;
        }

        [HttpPost]
        [Route("Criar")]
        public IActionResult Criar(AvaliacaoFichaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._AvaliacaoFichaService.Criar(dto);

            return Created($"/AvaliacaoFicha/{result.Id}", result);
        }

        [HttpPatch]
        [Route("Editar")]
        public IActionResult Editar(AvaliacaoFichaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._AvaliacaoFichaService.Editar(dto);

            return Ok(result);
        }

        [HttpDelete]
        [Route("Apagar")]
        public IActionResult Apagar( AvaliacaoFichaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._AvaliacaoFichaService.Apagar(dto);

            return Ok();
        }

        [HttpGet]
        [Route("ListaTodos")]
        public IActionResult ListaTodos()
        {
            var result = this._AvaliacaoFichaService.ObterTodos();

            return Ok(result);
        }

        [HttpGet]
        [Route("AvaliacaoFichasPorId")]
        public IActionResult GetAvaliacaoFichasPorId(Guid id)
        {
            var result = this._AvaliacaoFichaService.Obter(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }




    }
}
