using GestaoDeProdutosAPI.Dominio.Enumeradores;
using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeProdutosAPI.Dominio.Modelos
{
    public class CadastroProdutoModel
    {
        [Display(Name = "Descrição")]
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Descricao { get; set; }

        [Display(Name = "Situação do Produto (1=Ativo, 0=Inativo)")]
        [Required]
        public SituacaoProduto Situacao { get; set; }

        [Display(Name = "Data de Fabricação")]
        [Required]
        public DateTime DataFabricacao { get; set; }

        [Display(Name = "Data de Validade")]
        [Required]
        public DateTime DataValidade { get; set; }

        [Display(Name = "Código do Fornecedor")]
        [Required]
        public int FornecedorCodigo { get; set; }
    }
}
