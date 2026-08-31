using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class ComentarioRepository : IComentario
    {
        private readonly EventContext _context;

        public ComentarioRepository(EventContext context)
        {
            _context = context;
        }

        public async Task<Comentario?> Cadastrar(Comentario c)
        {
            if (await _context.Presenca.FirstOrDefaultAsync(x => x.IdUsuario == c.IdUsuario && x.IdEvento == c.IdEvento && x.Situacao) != null)
            {
                await _context.Comentario.AddAsync(c);
                await _context.SaveChangesAsync();
                return await _context.Comentario.FindAsync(c.IdComentario);
            }

            return null;
        }

        public async Task Deletar(Guid id)
        {
            var c = await _context.Comentario.FindAsync(id);
            _context.Comentario.Remove(c);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comentario>> Listar()
        {
            return await _context.Comentario.Where(c => c.Exibe == true).Include(c => c.IdUsuarioNavigation).Include(c => c.IdEventoNavigation).AsNoTracking().ToListAsync();
        }

        public async Task<List<Comentario>> ListarPorEvento(Guid idEvento)
        {
            return await _context.Comentario.Where(c => c.IdEvento == idEvento && c.Exibe == true).Include(c => c.IdUsuarioNavigation).AsNoTracking().ToListAsync();
        }

        public async Task<List<Comentario>> ListarPorUsuario(Guid idUsuario)
        {
            return await _context.Comentario.Where(c => c.IdUsuario == idUsuario && c.Exibe == true).Include(c => c.IdEventoNavigation).AsNoTracking().ToListAsync();
        }

        public async Task EditarVisibilidade(Guid id)
        {
            var c = await _context.Comentario.FindAsync(id);

            if (c != null)
            {
                c.Exibe = !c.Exibe;

                _context.Comentario.Update(c);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<Comentario>> ListarOcultos()
        {
            return await _context.Comentario.Where(c => c.Exibe == false).Include(c => c.IdUsuarioNavigation).Include(c => c.IdEventoNavigation).AsNoTracking().ToListAsync();
        }
    }
}
