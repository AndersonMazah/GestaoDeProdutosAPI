using GestaoDeProdutosAPI.Dominio.Enumeradores;
using System;

namespace GestaoDeProdutosAPI.Aplicacao.DTOs
{
    public class ProdutoDto
    {
        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public SituacaoProduto Situacao { get; set; }

        public DateTime DataFabricacao { get; set; }

        public DateTime DataValidade { get; set; }

        public int FornecedorCodigo { get; set; }
    }
}
