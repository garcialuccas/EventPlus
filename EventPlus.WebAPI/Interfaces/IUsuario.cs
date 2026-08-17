using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces
{
    public interface IUsuario
    {
        Task<Usuario> Cadastrar(Usuario u);

        Task<List<Usuario>> Listar();

        Task Deletar(Guid id);

        Task Atualizar(Guid id, Usuario u);

        Task<Usuario?> BuscarPorId(Guid id);

        Task<Usuario?> BuscarPorEmail(string email);

        Task NovaPresenca(Guid idEvento, Guid idUsuario);
    }
}
