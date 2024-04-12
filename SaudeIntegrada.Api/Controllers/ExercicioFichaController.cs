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

        public ExercicioFichaController(IExercicioFichaService ExercicioFichaService)
        {
            _ExercicioFichaService = ExercicioFichaService;
        }

        [HttpPost]
        [Route("Criar")]
        public IActionResult Criar( ExercicioFichaCriarDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._ExercicioFichaService.Criar(dto);

            result.IdExercicioBase = dto.IdExercicioBase;

            return Created($"/ExercicioFicha/{result.Id}", result);
        }

        [HttpPatch]
        [Route("Editar")]
        public IActionResult Editar( ExercicioFichaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._ExercicioFichaService.Editar(dto);

            return Ok( result);
        }

        [HttpDelete]
        [Route("Apagar")]
        public IActionResult Apagar(Guid id)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._ExercicioFichaService.Apagar(id);

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


        [HttpPost]
        [Route("AssociarFichaExercicioFicha")]
        public IActionResult AssociarFichaExercicioFicha(FichaExercicioFichaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._ExercicioFichaService.AssociarFichaExercicioFicha(dto);

            return Ok(result);
        }




    }
}
