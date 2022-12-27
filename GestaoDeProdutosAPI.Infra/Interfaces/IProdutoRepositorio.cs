using GestaoDeProdutosAPI.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoDeProdutosAPI.Infra.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<Produto> ObterPorCodigoAsync(int codigo);

        Task<List<Produto>> ObterTodosNoTrackingAsync(int quantidade, int pagina);

        Task CadastrarAsync(Produto produto);

        Task AtualizarAsync(Produto produto);

        Task DeletarAsync(Produto produto);
    }
}
