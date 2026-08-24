using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentario _repository;
        private readonly IModerationService _moderationService;

        public ComentarioController(IComentario repository, IModerationService moderationService)
        {
            _repository = repository;
            _moderationService = moderationService;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] ComentarioDTO dto)
        {
            try
            {
                bool reprovado = await _moderationService.ModerarTexto(dto.descricao);

                var c = new Comentario
                {
                    IdUsuario = dto.idUsuario,
                    IdEvento = dto.idEvento,
                    Descricao = dto.descricao,
                    Exibe = !reprovado,
                    DataComentario = dto.DataComentario
                };
                return StatusCode(201, await _repository.Cadastrar(c));
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

        [HttpGet("Evento/{idEvento:Guid}")]
        public async Task<IActionResult> ListarPorEvento(Guid idEvento)
        {
            try
            {
                return StatusCode(200, await _repository.ListarPorEvento(idEvento));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Usuario/{idUsuario:Guid}")]
        public async Task<IActionResult> ListarPorUsuario(Guid idUsuario)
        {
            try
            {
                return StatusCode(200, await _repository.ListarPorUsuario(idUsuario));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("ComentariosOcultos")]
        public async Task<IActionResult> ListarOcultos()
        {
            try
            {
                return StatusCode(200, await _repository.ListarOcultos());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id:Guid}")]
        public async Task<IActionResult> EditarVisibilidade(Guid id)
        {
            try
            {
                await _repository.EditarVisibilidade(id);
                return StatusCode(200);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
