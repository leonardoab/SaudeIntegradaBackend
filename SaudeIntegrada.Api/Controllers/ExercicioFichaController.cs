using Microsoft.AspNetCore.Mvc;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Application.Service;

namespace SaudeIntegrada.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioFichaController : ControllerBase
    {
        private readonly IExercicioFichaService _ExercicioFichaService;

        public ExercicioFichaController(ExercicioFichaService ExercicioFichaService)
        {
            _ExercicioFichaService = ExercicioFichaService;
        }

        [HttpPost]
        [Route("Criar")]
        public IActionResult Criar([FromBody] ExercicioFichaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._ExercicioFichaService.Criar(dto);

            return Created($"/ExercicioFicha/{result.Id}", result);
        }

        [HttpPatch]
        [Route("Editar")]
        public IActionResult Editar([FromBody] ExercicioFichaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._ExercicioFichaService.Editar(dto);

            return Created($"/ExercicioFicha/{result.Id}", result);
        }

        [HttpDelete]
        [Route("Apagar")]
        public IActionResult Apagar([FromBody] ExercicioFichaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._ExercicioFichaService.Apagar(dto);

            return Ok();
        }

        [HttpGet]
        [Route("ListaTodos")]
        public IActionResult ListaTodos()
        {
            var result = this._ExercicioFichaService.ObterTodos();

            return Ok(result);
        }

        [HttpGet]
        [Route("ExercicioFichasPorId")]
        public IActionResult GetExercicioFichasPorId(Guid id)
        {
            var result = this._ExercicioFichaService.Obter(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }




    }
}
