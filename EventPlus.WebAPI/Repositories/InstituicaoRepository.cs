using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class InstituicaoRepository : IInstituicao
    {
        private readonly EventContext _dbContext;

        public InstituicaoRepository(EventContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Atualizar(Instituicao i, Guid id)
        {
            Instituicao? iBuscado = await _dbContext.Instituicao.FindAsync(id);

            if (iBuscado != null)
            {
                iBuscado.Cnpj = i.Cnpj;
                iBuscado.NomeFantasia = i.NomeFantasia;
                iBuscado.Endereco = i.Endereco;
                _dbContext.Update(iBuscado);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Instituicao?> BuscarPorId(Guid id)
        {
            return await _dbContext.Instituicao.FirstOrDefaultAsync(i => i.IdInstituicao == id);
        }

        public async Task Cadastrar(Instituicao i)
        {
            await _dbContext.Instituicao.AddAsync(i);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Deletar(Guid id)
        {
            var i = await _dbContext.Instituicao.FindAsync(id);
            _dbContext.Instituicao.Remove(i);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Instituicao>> Listar()
        {
            return await _dbContext.Instituicao.AsNoTracking().ToListAsync();
        }
    }
}
