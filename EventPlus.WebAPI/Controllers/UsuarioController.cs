using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _repository;

        public UsuarioController(IUsuario repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                return Ok(await _repository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] UsuarioDTO dto)
        {
            Usuario u = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha,
                IdTipoUsuario = dto.idTipoUsuatio
            };

            try
            {
                await _repository.Cadastrar(u);
                return StatusCode(201, u);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id:Guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] EdicaoUsuarioDTO dto)
        {
            var u = new Usuario
            {
                Nome = dto.nome,
                Email = dto.email,
                Senha = dto.senha,
            };

            try
            {
                await _repository.Atualizar(id, u);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            try
            {
                return Ok(await _repository.BuscarPorId(id));
            }
            catch
            {
                return StatusCode(404);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> BuscarPorEmailSenha([FromBody] LoginDTO dto)
        {
            try
            {
                return Ok(await _repository.BuscarPorEmailSenha(dto.email, dto.senha));
            }
            catch
            {
                return StatusCode(404);
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            try
            {
                await _repository.Deletar(id);
                return Ok();
            }
            catch
            {
                return StatusCode(404);
            }
        }

        [HttpPost("NovaPresenca/{id:Guid}")]
        public async Task<IActionResult> NovaPresenca(Guid idEvento, Guid id)
        {
            try
            {
                await _repository.NovaPresenca(idEvento, id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
