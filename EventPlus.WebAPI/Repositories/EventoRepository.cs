using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EventPlus.WebAPI.Repositories
{
    public class EventoRepository : IEvento
    {
        private readonly EventContext _context;

        public EventoRepository(EventContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Guid id, Evento eventoAtualizado)
        {
            var e = await _context.Evento.FindAsync(id);

            if (e != null)
            {
                e.NomeEvento = eventoAtualizado.NomeEvento.IsNullOrEmpty() ? e.NomeEvento : eventoAtualizado.NomeEvento;
                e.DataEvento = eventoAtualizado.DataEvento == DateTime.MinValue ? e.DataEvento : eventoAtualizado.DataEvento;
                e.Descricao = eventoAtualizado.Descricao.IsNullOrEmpty() ? e.Descricao : eventoAtualizado.Descricao;
                e.ImagemUrl = eventoAtualizado.ImagemUrl.IsNullOrEmpty() ? e.ImagemUrl : eventoAtualizado.ImagemUrl;
                e.IdTipoEvento = eventoAtualizado.IdTipoEvento == null ? e.IdTipoEvento : eventoAtualizado.IdTipoEvento;
                e.IdInstituicao = eventoAtualizado.IdInstituicao == null ? e.IdInstituicao : eventoAtualizado.IdInstituicao;

                _context.Evento.Update(e);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Evento?> BuscarPorId(Guid id)
        {
            return await _context.Evento.FindAsync(id);
        }

        public async Task<Evento> Cadastrar(Evento e)
        {
            await _context.Evento.AddAsync(e);
            await _context.SaveChangesAsync();
            return await _context.Evento.FindAsync(e);
        }

        public async Task Deletar(Guid id)
        {
            var e = await _context.Evento.FindAsync(id);

            _context.Evento.Remove(e);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Evento>> Listar()
        {
            return await _context.Evento.AsNoTracking().ToListAsync();
        }

        public async Task<List<Evento>> ListarPorInscrito(Guid idInscrito)
        {
            return await _context.Evento.Where(e => e.Presenca.Any(p => p.IdUsuario == idInscrito)).AsNoTracking().ToListAsync();
        }

        public async Task<List<Evento>> ListarPorInstituicao(Guid idInstituicao)
        {
            return await _context.Evento.Where(e => e.IdInstituicao == idInstituicao).AsNoTracking().ToListAsync();
        }

        public async Task<List<Evento>> ListarProximos()
        {
            return await _context.Evento.Where(e => e.DataEvento >= DateTime.Now).OrderBy(e => e.DataEvento).AsNoTracking().ToListAsync();
        }
    }
}
