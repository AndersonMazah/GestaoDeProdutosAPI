using GestaoDeProdutosAPI.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoDeProdutosAPI.Infra.Interfaces
{
    public interface IFornecedorRepositorio
    {
        Task<Fornecedor> ObterPorCodigoAsync(int codigo);

        Task<List<Fornecedor>> ObterTodosAsync();

        Task CadastrarAsync(Fornecedor fornecedor);

        Task AtualizarAsync(Fornecedor fornecedor);

        Task DeletarAsync(Fornecedor fornecedor);
    }
}
