using GestaoDeProdutosAPI.Aplicacao.DTOs;
using GestaoDeProdutosAPI.Dominio.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoDeProdutosAPI.Aplicacao.Interfaces
{
    public interface IProdutoAplicacao
    {
        Task<List<ProdutoDto>> BuscarTodosAsync();

        Task<ProdutoDto> BuscarPorCodigoAsync(int codigo);

        Task<ProdutoDto> CadastrarAsync(CadastroProdutoModel modelo);

        Task<ProdutoDto> AtualizarAsync(AtualizaProdutoModel modelo);

        Task DeletarAsync(int codigo);
    }
}
