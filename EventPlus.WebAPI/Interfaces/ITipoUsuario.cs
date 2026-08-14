using EventPlus.WebAPI.Models;
using System.Runtime.CompilerServices;

namespace EventPlus.WebAPI.Interfaces
{
    public interface ITipoUsuario
    {
        Task Cadastrar(TipoUsuario tipoUsuario);

        Task<List<TipoUsuario>> Listar();

        Task Deletar(Guid id);

        Task Atualizar(Guid id, TipoUsuario tipoUsuario);

        Task<TipoUsuario?> BuscarPorId(Guid id);
    }
}
