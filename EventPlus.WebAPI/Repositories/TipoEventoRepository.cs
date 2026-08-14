using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class TipoEventoRepository : ITipoEvento
    {
        private readonly EventContext _dbContext;

        public TipoEventoRepository(EventContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Atualizar(Guid id, TipoEvento TipoEvento)
        {
            var te = await _dbContext.TipoEvento.FindAsync(id);
            if (te != null)
            {
                te.TituloTipoEvento = TipoEvento.TituloTipoEvento;
                _dbContext.TipoEvento.Update(te);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<TipoEvento?> BuscarPorId(Guid id)
        {
            return await _dbContext.TipoEvento.FirstOrDefaultAsync(te => te.IdTipoEvento == id);
        }

        public async Task Cadastrar(TipoEvento TipoEvento)
        {
            await _dbContext.TipoEvento.AddAsync(TipoEvento);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Deletar(Guid id)
        {
            var te = await _dbContext.TipoEvento.FindAsync(id);
            if (te != null)
            {
                _dbContext.TipoEvento.Remove(te);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task<List<TipoEvento>> Listar()
        {
            return await _dbContext.TipoEvento.AsNoTracking().ToListAsync();
        }
    }
}
