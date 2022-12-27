using GestaoDeProdutosAPI.Aplicacao.DTOs;
using GestaoDeProdutosAPI.Dominio.Entidades;
using GestaoDeProdutosAPI.Dominio.Modelos;
using System.Threading.Tasks;

namespace GestaoDeProdutosAPI.Aplicacao.Interfaces
{
    public interface IProdutoAplicacao
    {
        Task<Paginacao<ProdutoDto>> BuscarTodosAsync(int quantidade, int pagina);

        Task<ProdutoDto> BuscarPorCodigoAsync(int codigo);

        Task<ProdutoDto> CadastrarAsync(CadastroProdutoModel modelo);

        Task<ProdutoDto> AtualizarAsync(AtualizaProdutoModel modelo);

        Task DeletarAsync(int codigo);
    }
}
