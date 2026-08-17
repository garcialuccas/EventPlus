using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces
{
    public interface IInstituicao
    {
        Task<Instituicao> Cadastrar(Instituicao i);

        Task<List<Instituicao>> Listar();

        Task Deletar(Guid id);

        Task Atualizar(Instituicao i, Guid id);

        Task<Instituicao?> BuscarPorId(Guid id);
    }
}
