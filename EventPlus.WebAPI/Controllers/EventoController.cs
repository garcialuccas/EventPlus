using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEvento _repository;
        private readonly Cloudinary _cloudinary;

        public EventoController(IEvento repository, IConfiguration c)
        {
            _repository = repository;
            var acc = new Account
            (
                c["Cloudinary:CloudName"],
                c["Cloudinary:ApiKey"],
                c["Cloudinary:ApiSecret"]
            );

            _cloudinary = new Cloudinary(acc);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromForm] EventoDTO dto)
        {
            try
            {
                string imgUrl = null;
                if (dto.ImagemUrl != null && dto.ImagemUrl.Length > 0)
                {
                    await using var stream = dto.ImagemUrl.OpenReadStream();
                    var upload = new ImageUploadParams
                    {
                        File = new FileDescription(dto.ImagemUrl.FileName, stream),
                        Folder = "EventPlus/Eventos"
                    };

                    var uploadResuts = await _cloudinary.UploadAsync(upload);

                    imgUrl = uploadResuts.SecureUrl.ToString();
                }

                var e = new Evento
                {
                    NomeEvento = dto.NomeEvento,
                    Descricao = dto.Descricao,
                    DataEvento = dto.DataEvento,
                    ImagemUrl = imgUrl,
                    IdTipoEvento = dto.IdTipoEvento,
                    IdInstituicao = dto.IdInstituicao
                };
                return StatusCode(201, await _repository.Cadastrar(e));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id:Guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] EdicaoEventoDTO dto)
        {

            try
            {
                var e = new Evento
                {
                    NomeEvento = dto.NomeEvento,
                    Descricao = dto.Descricao,
                    DataEvento = dto.DataEvento,
                    ImagemUrl = dto.ImagemUrl,
                    IdTipoEvento = dto.IdTipoEvento,
                    IdInstituicao = dto.IdInstituicao
                };
                await _repository.Atualizar(id, e);
                return NoContent();
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
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                return Ok(await _repository.Listar());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("ListarProximos")]
        public async Task<IActionResult> ListarProximos()
        {
            try
            {
                return Ok(await _repository.ListarProximos());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("ListarPorInscrito/{id:Guid}")]
        public async Task<IActionResult> ListarPorInscrito(Guid id)
        {
            try
            {
                return Ok(await _repository.ListarPorInscrito(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("ListarPorInstituicao/{id:Guid}")]
        public async Task<IActionResult> ListarPorInstituicao(Guid id)
        {
            try
            {
                return Ok(await _repository.ListarPorInstituicao(id));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
