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

        public async Task Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            var tp = await _dbContext.TipoUsuario.FindAsync(id);
            if (tp != null)
            {
                tp.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
                _dbContext.TipoUsuario.Update(tp);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<TipoUsuario?> BuscarPorId(Guid id)
        {
            return await _dbContext.TipoUsuario.FirstOrDefaultAsync(Tp => Tp.IdTipoUsuario == id);
        }

        public async Task Cadastrar(TipoUsuario tipoUsuario)
        {
            await _dbContext.TipoUsuario.AddAsync(tipoUsuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Deletar(Guid id)
        {
            var tp = await _dbContext.TipoUsuario.FindAsync(id);
            if (tp != null)
            {
                _dbContext.TipoUsuario.Remove(tp);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<TipoUsuario>> Listar()
        {
            return await _dbContext.TipoUsuario.AsNoTracking().ToListAsync();
        }
    }
}
