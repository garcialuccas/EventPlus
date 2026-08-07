using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuario
    {
        private readonly EventContext _dbContext;

        public TipoUsuarioRepository(EventContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<TipoUsuario> BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Cadastrar(TipoUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TipoUsuario>> Listar()
        {
            return await _dbContext.TipoUsuario.AsNoTracking().ToListAsync();
        }
    }
}
