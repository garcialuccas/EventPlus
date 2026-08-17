using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class PresencaRepository : IPresenca
    {
        private readonly EventContext _context;

        public PresencaRepository(EventContext context)
        {
            _context = context;
        }

        public async Task AtualizarSituacao(Guid id)
        {
            var p = await _context.Presenca.FindAsync(id);
            p.Situacao = !p.Situacao;
            _context.Presenca.Update(p);
            await _context.SaveChangesAsync();
        }

        public async Task<Presenca> Cadastrar(Presenca p)
        {
            await _context.Presenca.AddAsync(p);
            await _context.SaveChangesAsync();
            return await _context.Presenca.FindAsync(p.IdPresenca);
        }

        public async Task Deletar(Guid id)
        {
            _context.Presenca.Remove(await _context.Presenca.FindAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Presenca>> Listar()
        {
            return await _context.Presenca.Include(p => p.IdUsuarioNavigation).Include(p => p.IdEventoNavigation).AsNoTracking().ToListAsync();
        }

        public async Task<List<Presenca>> ListarPresencasEvento(Guid idEvento)
        {
            return await _context.Presenca.Where(p => p.IdEvento ==  idEvento).Include(p => p.IdUsuarioNavigation).AsNoTracking().ToListAsync();
        }
    }
}
