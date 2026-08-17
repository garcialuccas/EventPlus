using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EventPlus.WebAPI.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly EventContext _dbContext;

        public UsuarioRepository(EventContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Atualizar(Guid id, Usuario u)
        {
            var usuarioBuscado = await _dbContext.Usuario.FindAsync(id);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Nome = u.Nome.IsNullOrEmpty() ? usuarioBuscado.Nome : u.Nome;
                usuarioBuscado.Email = u.Email.IsNullOrEmpty()? usuarioBuscado.Email: u.Email;
                usuarioBuscado.Senha = u.Senha.IsNullOrEmpty() ? usuarioBuscado.Senha : CriptografiaUsuario.CriptografarSenha(u.Senha);
                usuarioBuscado.IdTipoUsuario = u.IdTipoUsuario == null ? usuarioBuscado.IdTipoUsuario : u.IdTipoUsuario;

                _dbContext.Usuario.Update(usuarioBuscado);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Usuario?> BuscarPorEmail(string email)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario?> BuscarPorId(Guid id)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        public async Task<Usuario> Cadastrar(Usuario u)
        {
            u.Senha = CriptografiaUsuario.CriptografarSenha(u.Senha);
            await _dbContext.Usuario.AddAsync(u);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Usuario.FindAsync(u);
        }

        public async Task Deletar(Guid id)
        {
            var usuarioBuscado = await _dbContext.Usuario.FindAsync(id);
            if (usuarioBuscado != null)
            {
                _dbContext.Usuario.Remove(usuarioBuscado);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Usuario>> Listar()
        {
            return await _dbContext.Usuario.Include(u => u.IdTipoUsuarioNavigation).AsNoTracking().ToListAsync();
        }

        public async Task NovaPresenca(Guid idEvento, Guid idUsuario)
        {
            var evento = await _dbContext.Evento.FindAsync(idEvento);

            Presenca p = new Presenca
            {
                IdEvento = idEvento,
                IdUsuario = idUsuario,
                Situacao = true
            };

            await _dbContext.Presenca.AddAsync(p);
            await _dbContext.SaveChangesAsync();
        }
    }
}
