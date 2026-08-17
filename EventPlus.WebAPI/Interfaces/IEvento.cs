using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces
{
    public interface IEvento
    {
        Task<Evento> Cadastrar(Evento e);

        Task<List<Evento>> Listar();

        Task Deletar(Guid id);

        Task Atualizar(Guid id, Evento eventoAtualizado);

        Task<Evento?> BuscarPorId(Guid id);

        Task<List<Evento>> ListarPorInstituicao(Guid idInstituicao);

        Task<List<Evento>> ListarPorInscrito(Guid idInscrito);

        Task<List<Evento>> ListarProximos();
    }
}
