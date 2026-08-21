using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresencaController : ControllerBase
    {
        private readonly IPresenca _repository;

        public PresencaController(IPresenca repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] PresencaDTO dto)
        {

            try
            {
                var p = new Presenca
                {
                    IdEvento = dto.idEvento,
                    IdUsuario = dto.idUsuario,
                };
                return StatusCode(201, await _repository.Cadastrar(p));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                return StatusCode(200, await _repository.Listar());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            try
            {
                await _repository.Deletar(id);
                return StatusCode(200);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> AtualizarSituacao(Guid id)
        {
            try
            {
                await _repository.AtualizarSituacao(id);
                return StatusCode(200);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{idEvento:Guid}")]
        public async Task<IActionResult> ListarPresencasEvento(Guid idEvento)
        {
            try
            {
                return StatusCode(200, await _repository.ListarPresencasEvento(idEvento));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
