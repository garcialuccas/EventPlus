using EventPlus.WebAPI.Interfaces;
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
    }
}
