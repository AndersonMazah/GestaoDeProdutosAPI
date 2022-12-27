using GestaoDeProdutosAPI.Aplicacao.DTOs;
using GestaoDeProdutosAPI.Dominio.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoDeProdutosAPI.Aplicacao.Interfaces
{
    public interface IFornecedorAplicacao
    {
        Task<List<FornecedorDto>> BuscarTodosAsync();

        Task<FornecedorDto> BuscarPorCodigoAsync(int codigo);

        Task<FornecedorDto> CadastrarAsync(CadastroFornecedorModel modelo);

        Task<FornecedorDto> AtualizarAsync(AtualizaFornecedorModel modelo);

        Task DeletarAsync(int codigo);
    }
}
