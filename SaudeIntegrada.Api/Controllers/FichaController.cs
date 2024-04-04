using Microsoft.AspNetCore.Mvc;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.Service;

namespace SaudeIntegrada.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichaController : ControllerBase
    {
        private FichaService _FichaService;

        public FichaController(FichaService FichaService)
        {
            _FichaService = FichaService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var result = this._FichaService.ObterTodos();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetFichasPorId(Guid id)
        {
            var result = this._FichaService.Obter(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] FichaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._FichaService.Criar(dto);

            return Created($"/Ficha/{result.Id}", result);
        }

        //TODO CRIAR
        //TODO EDITAR
        //TODO DELETAR
        //TODO LISTAR
    }
}
