using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces
{
    public interface IUsuario
    {
        Task Cadastrar(Usuario u);

        Task<List<Usuario>> Listar();

        Task Deletar(Guid id);

        Task Atualizar(Guid id, Usuario u);

        Task<Usuario?> BuscarPorId(Guid id);

        Task<Usuario?> BuscarPorEmailSenha(string email, string senha);

        Task NovaPresenca(Guid idEvento, Guid idUsuario);
    }
}
