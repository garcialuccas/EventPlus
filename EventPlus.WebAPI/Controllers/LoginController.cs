using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuario _repository;
        private readonly IConfiguration _configuration;

        public LoginController(IUsuario repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> BuscarPorEmail([FromBody] LoginDTO dto)
        {
            try
            {
                var u = await _repository.BuscarPorEmail(dto.email);
                if (u == null || !CriptografiaUsuario.VerificarSenha(dto.senha, u.Senha))
                {
                    return Unauthorized("Email ou senha inválidos");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, u.IdUsuario.ToString()),
                    new Claim("NomeUsuario", u.Nome),
                    new Claim(JwtRegisteredClaimNames.Email, u.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var chaveSecreta = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

                var credenciais = new SigningCredentials(chaveSecreta, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(issuer: "EventPlus.WebAPI", audience: "EventPlus.WebAPI", claims: claims, expires: DateTime.UtcNow.AddHours(8), signingCredentials: credenciais);

                string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return StatusCode(200, new { Token = tokenString, Expiracao = token.ValidTo, Usuario = new { u.IdUsuario, u.Nome, u.Email } });
            }
            catch
            {
                return StatusCode(404);
            }
        }
    }
}
