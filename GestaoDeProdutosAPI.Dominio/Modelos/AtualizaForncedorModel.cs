using System.ComponentModel.DataAnnotations;

namespace GestaoDeProdutosAPI.Dominio.Modelos
{
    public class AtualizaForncedorModel
    {
        [Display(Name = "Código")]
        [Required]
        public int Codigo { get; set; }

        [Display(Name = "Descrição")]
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Descricao { get; set; }

        [Display(Name = "CNPJ")]
        [Required]
        [MinLength(18)]
        [MaxLength(18)]
        public string CNPJ { get; set; }
    }
}
