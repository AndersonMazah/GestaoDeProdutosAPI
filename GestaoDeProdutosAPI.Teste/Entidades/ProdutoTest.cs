using GestaoDeProdutosAPI.Dominio.Entidades;
using GestaoDeProdutosAPI.Dominio.Enumeradores;
using GestaoDeProdutosAPI.Dominio.Exceptions;
using GestaoDeProdutosAPI.Teste.EntidadesData;
using System;

namespace GestaoDeProdutosAPI.Teste.Entidades
{
    public class ProdutoTest
    {
        [Theory(DisplayName = "Testa o construtor da entidade Produto.")]
        [ClassData(typeof(ProdutoTestData))]
        public void ValidarConstrutorProduto(int codigo, string descricao, SituacaoProduto situacao, DateTime dataFabricacao, DateTime dataValidade, int fornecedorCodigo, string esperado)
        {
            EntidadeInvalidaException ex = Assert.Throws<EntidadeInvalidaException>(() => new Produto(codigo, descricao, situacao, dataFabricacao, dataValidade, fornecedorCodigo));
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
