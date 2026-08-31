using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuario _repository;

        public TipoUsuarioController(ITipoUsuario repository)
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
        [Authorize]
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
        public async Task<IActionResult> Cadastrar([FromBody] TipoUsuarioDTO dto)
        {
            try
            {
                var tp = new TipoUsuario
                {
                    TituloTipoUsuario = dto.TituloTipoUsuario
                };

                return StatusCode(201, await _repository.Cadastrar(tp));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Atualzar(Guid id, [FromBody] TipoUsuarioDTO dto)
        {
            var tp = new TipoUsuario
            {
                TituloTipoUsuario = dto.TituloTipoUsuario
            };

            await _repository.Atualizar(id, tp);
            return Ok();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            await _repository.Deletar(id);
            return Ok();
        }
    }
}
