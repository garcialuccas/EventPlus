using EventPlus.WebAPI.Models;
using System.Runtime.CompilerServices;

namespace EventPlus.WebAPI.Interfaces
{
    public interface ITipoEvento
    {
        Task Cadastrar(TipoEvento TipoEvento);

        Task<List<TipoEvento>> Listar();

        Task Deletar(Guid id);

        Task Atualizar(Guid id, TipoEvento TipoEvento);

        Task<TipoEvento?> BuscarPorId(Guid id);
    }
}
