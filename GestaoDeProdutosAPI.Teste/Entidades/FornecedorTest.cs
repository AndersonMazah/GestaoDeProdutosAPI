using GestaoDeProdutosAPI.Dominio.Entidades;
using GestaoDeProdutosAPI.Dominio.Exceptions;
using GestaoDeProdutosAPI.Teste.EntidadesData;

namespace GestaoDeProdutosAPI.Teste.Entidades
{
    public class FornecedorTest
    {
        [Theory(DisplayName = "Testa o construtor da entidade Fornecedor.")]
        [ClassData(typeof(FornecedorTestData))]
        public void ValidarConstrutorFornecedor(int codigo, string descricao, string cnpj, string esperado)
        {
            EntidadeInvalidaException ex = Assert.Throws<EntidadeInvalidaException>(() => new Fornecedor(codigo, descricao, cnpj));
            if (ex != null)
            {
                Assert.Equal(esperado, ex.Message);
            }
            else
            {
                Assert.Equal(esperado, string.Empty);
            }
        }
    }
}
