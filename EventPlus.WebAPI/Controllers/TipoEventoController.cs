using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEvento _repository;

        public TipoEventoController(ITipoEvento repository)
        {
            _repository = repository;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            var tp = await _repository.BuscarPorId(id);

            if (tp == null)
            {
                return NotFound("Tipo Usuário não encontrado");
            }

            return Ok(tp);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var tp = await _repository.Listar();
                return Ok(tp);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] TipoEventoDTO dto)
        {
            var tp = new TipoEvento
            {
                TituloTipoEvento = dto.TituloTipoEvento
            };

            try
            {
                await _repository.Cadastrar(tp);
                return StatusCode(201, tp);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Atualzar(Guid id, [FromBody] TipoEventoDTO dto)
        {
            var tp = new TipoEvento
            {
                TituloTipoEvento = dto.TituloTipoEvento
            };

            await _repository.Atualizar(id, tp);
            return Ok(tp);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            await _repository.Deletar(id);
            return NoContent();
        }
    }
}
