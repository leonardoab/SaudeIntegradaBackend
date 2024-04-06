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

        public AvaliacaoFichaController(AvaliacaoFichaService AvaliacaoFichaService)
        {
            _AvaliacaoFichaService = AvaliacaoFichaService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var result = this._AvaliacaoFichaService.ObterTodos();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAvaliacaoFichasPorId(Guid id)
        {
            var result = this._AvaliacaoFichaService.Obter(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] AvaliacaoFichaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._AvaliacaoFichaService.Criar(dto);

            return Created($"/AvaliacaoFicha/{result.Id}", result);
        }

        
    }
}
