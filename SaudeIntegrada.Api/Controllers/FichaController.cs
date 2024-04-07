using Microsoft.AspNetCore.Mvc;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Application.Service;

namespace SaudeIntegrada.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichaController : ControllerBase
    {
        private readonly IFichaService _FichaService;

        public FichaController(IFichaService FichaService)
        {
            _FichaService = FichaService;
        }

        [HttpPost]
        [Route("Criar")]
        public IActionResult Criar( FichaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._FichaService.Criar(dto);

            return Created($"/Ficha/{result.Id}", result);
        }

        [HttpPatch]
        [Route("Editar")]
        public IActionResult Editar(FichaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._FichaService.Editar(dto);

            return Ok (result);
        }

        [HttpDelete]
        [Route("Apagar")]
        public IActionResult Apagar(FichaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._FichaService.Apagar(dto);

            return Ok();
        }

        [HttpGet]
        [Route("ListaTodos")]
        public IActionResult ListaTodos()
        {
            var result = this._FichaService.ObterTodos();

            return Ok(result);
        }

        [HttpGet]
        [Route("FichasPorId")]
        public IActionResult GetFichasPorId(Guid id)
        {
            var result = this._FichaService.Obter(id);

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
            var result = this._FichaService.BuscarPorParteNome(partenome);

            return Ok(result);
        }




    }
}
