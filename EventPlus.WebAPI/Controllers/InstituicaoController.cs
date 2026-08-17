using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicao _repository;

        public InstituicaoController(IInstituicao repository)
        {
            _repository = repository;
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

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            try
            {
                return Ok(await _repository.BuscarPorId(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] InstituicaoDTO dto)
        {

            try
            {
                var i = new Instituicao
                {
                    NomeFantasia = dto.NomeFantasia,
                    Endereco = dto.Endereco,
                    Cnpj = dto.Cnpj,
                };
                return StatusCode(201, await _repository.Cadastrar(i));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id:Guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] EdicaoInstituicaoDTO dto)
        {
            var i = new Instituicao
            {
                Cnpj = dto.Cnpj,
                NomeFantasia = dto.NomeFantasia,
                Endereco = dto.Endereco
            };

            try
            {
                await _repository.Atualizar(i, id);
                return Ok();
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
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
