using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces
{
    public interface IPresenca
    {
        Task<Presenca> Cadastrar(Presenca p);
        Task AtualizarSituacao(Guid id);

        Task Deletar(Guid id);

        Task<List<Presenca>> Listar();

        Task<List<Presenca>> ListarPresencasEvento(Guid idEvento);
    }
}
