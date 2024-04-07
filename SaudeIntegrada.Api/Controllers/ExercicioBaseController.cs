using Microsoft.AspNetCore.Mvc;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Application.Service;

namespace SaudeIntegrada.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioBaseController : ControllerBase
    {
        private readonly IExercicioBaseService _ExercicioBaseService;

        public ExercicioBaseController(IExercicioBaseService ExercicioBaseService)
        {
            _ExercicioBaseService = ExercicioBaseService;
        }

        [HttpPost]
        [Route("Criar")]
        public IActionResult Criar( ExercicioBaseDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._ExercicioBaseService.Criar(dto);

            return Created($"/ExercicioBase/{result.Id}", result);
        }

        [HttpPatch]
        [Route("Editar")]
        public IActionResult Editar( ExercicioBaseDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._ExercicioBaseService.Editar(dto);

            return Ok(result);
        }

        [HttpDelete]
        [Route("Apagar")]
        public IActionResult Apagar([FromBody] ExercicioBaseDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._ExercicioBaseService.Apagar(dto);

            return Ok();
        }

        [HttpGet]
        [Route("ListaTodos")]
        public IActionResult ListaTodos()
        {
            var result = this._ExercicioBaseService.ObterTodos();

            return Ok(result);
        }

        [HttpGet]
        [Route("ExercicioBasesPorId")]
        public IActionResult GetExercicioBasesPorId(Guid id)
        {
            var result = this._ExercicioBaseService.Obter(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("BuscarPorParteNome")]
        public IActionResult BuscarPorParteNome(string partenome)
        {
            var result = this._ExercicioBaseService.BuscarPorParteNome(partenome);

            return Ok(result);
        }




    }
}
