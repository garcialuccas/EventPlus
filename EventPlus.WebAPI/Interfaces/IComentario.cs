using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces
{
    public interface IComentario
    {
        Task<Comentario> Cadastrar(Comentario c);

        Task<List<Comentario>> ListarPorEvento(Guid idEvento);

        Task<List<Comentario>> ListarPorUsuario(Guid idUsuario);

        Task<List<Comentario>> Listar();

        Task Deletar(Guid id);

        Task EditarVisibilidade(Guid id);

        Task<List<Comentario>> ListarOcultos();
    }
}
